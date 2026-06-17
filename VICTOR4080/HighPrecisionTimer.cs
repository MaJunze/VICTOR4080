using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace VICTOR4080
{
    /// <summary>
    /// WinForm 高精度定时器，支持运行时动态修改定时周期
    /// </summary>
    public class HighPrecisionTimer
    {
        #region 私有字段
        private int _intervalMs;
        private readonly object _lockObj = new object();
        private CancellationTokenSource _cts;
        private Task _timerTask;
        private readonly Action _tickAction;

        private Stopwatch _stopwatch;
        private long _nextTick;
        #endregion

        #region 公开属性
        /// <summary>
        /// 当前定时间隔（毫秒）
        /// </summary>
        public int IntervalMs
        {
            get
            {
                lock (_lockObj)
                {
                    return _intervalMs;
                }
            }
        }

        /// <summary>
        /// 定时器是否正在运行
        /// </summary>
        public bool IsRunning { get; private set; }
        #endregion

        #region 构造函数
        /// <summary>
        /// 初始化高精度定时器
        /// </summary>
        /// <param name="initialIntervalMs">初始定时间隔(ms)</param>
        /// <param name="tickAction">定时触发回调</param>
        public HighPrecisionTimer(int initialIntervalMs, Action tickAction)
        {
            if (initialIntervalMs <= 0)
                throw new ArgumentException("定时间隔必须大于0毫秒");
            _intervalMs = initialIntervalMs;
            _tickAction = tickAction ?? throw new ArgumentNullException(nameof(tickAction));
        }
        #endregion

        #region 动态修改间隔
        /// <summary>
        /// 修改定时间隔：下一个周期生效（平滑切换，当前周期继续走完）
        /// </summary>
        /// <param name="newIntervalMs">新间隔(ms)</param>
        public void SetInterval(int newIntervalMs)
        {
            if (newIntervalMs <= 0)
                throw new ArgumentException("定时间隔必须大于0毫秒");
            lock (_lockObj)
            {
                _intervalMs = newIntervalMs;
            }
        }

        /// <summary>
        /// 修改定时间隔：立即生效，从当前时刻重新开始计时
        /// </summary>
        /// <param name="newIntervalMs">新间隔(ms)</param>
        public void SetIntervalImmediate(int newIntervalMs)
        {
            SetInterval(newIntervalMs);
            if (IsRunning)
            {
                lock (_lockObj)
                {
                    _nextTick = _stopwatch.ElapsedTicks;
                }
            }
        }
        #endregion

        #region 启停与释放
        public void Start()
        {
            if (IsRunning) return;

            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            _timerTask = Task.Run(() =>
            {
                _stopwatch = Stopwatch.StartNew();
                _nextTick = _stopwatch.ElapsedTicks;

                while (!token.IsCancellationRequested)
                {
                    long currentTickInterval;
                    lock (_lockObj)
                    {
                        currentTickInterval = Stopwatch.Frequency * _intervalMs / 1000;
                    }

                    // 高精度自旋等待到下一个节拍
                    while (_stopwatch.ElapsedTicks < _nextTick && !token.IsCancellationRequested)
                    {
                        Thread.SpinWait(10);
                    }

                    if (token.IsCancellationRequested)
                        break;

                    // 执行定时任务
                    _tickAction.Invoke();

                    // 更新下一次触发时间
                    lock (_lockObj)
                    {
                        _nextTick += currentTickInterval;
                    }
                }
            }, token);

            IsRunning = true;
        }

        public void Stop()
        {
            if (!IsRunning) return;

            _cts?.Cancel();
            try
            {
                _timerTask?.Wait(200);
            }
            catch
            {
                // 捕获取消异常，无需处理
            }

            _cts?.Dispose();
            _cts = null;
            _timerTask = null;
            _stopwatch = null;
            IsRunning = false;
        }

        public void Dispose()
        {
            Stop();
        }
        #endregion
    }
}