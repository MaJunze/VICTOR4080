using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace VICTOR4080
{
    /// <summary>高精度定时发生器，基于Stopwatch</summary>
    public class HighPrecisionTimer
    {
        // 定时周期 毫秒
        private readonly int _intervalMs;
        private Stopwatch _stopwatch;
        private CancellationTokenSource _cts;
        private Task _runTask;

        /// <summary>定时触发回调，参数：当前高精度时间戳</summary>
        public Action<DateTime> OnTick { get; set; }

        public HighPrecisionTimer(int intervalMs)
        {
            _intervalMs = intervalMs;
        }

        /// <summary>启动定时器</summary>
        public void Start()
        {
            if (_cts != null && !_cts.IsCancellationRequested)
                return;

            _cts = new CancellationTokenSource();
            _stopwatch = Stopwatch.StartNew();
            long lastElapsedMs = _stopwatch.ElapsedMilliseconds;

            _runTask = Task.Run(async () =>
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    long nowMs = _stopwatch.ElapsedMilliseconds;
                    // 达到间隔则执行回调
                    if (nowMs - lastElapsedMs >= _intervalMs)
                    {
                        lastElapsedMs = nowMs;
                        // 触发回调，把当前真实系统时间传给你
                        OnTick?.Invoke(DateTime.Now);
                    }
                    // 极小休眠，降低CPU占用
                    await Task.Delay(1, _cts.Token);
                }
            }, _cts.Token);
        }

        /// <summary>停止定时器并释放资源</summary>
        public void Stop()
        {
            _cts?.Cancel();
            try
            {
                _runTask?.Wait(300);
            }
            catch
            {
                // 忽略取消异常
            }
            _cts?.Dispose();
            _cts = null;
            _stopwatch?.Stop();
        }

        /// <summary>是否正在运行</summary>
        public bool IsRunning => _cts != null && !_cts.IsCancellationRequested;
    }
}
