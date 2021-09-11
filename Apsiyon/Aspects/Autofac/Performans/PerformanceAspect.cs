using Apsiyon.Utilities.Interceptors;
using Apsiyon.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Apsiyon.Aspects.Autofac.Performans
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        protected override void OnBefore(IInvocation ınvocation) => _stopwatch.Start();

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
                Debug.WriteLine($"{invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}" + " Methodunun çalışma süresi: " + $"{_stopwatch.Elapsed.TotalSeconds}" + " sn");
            _stopwatch.Reset();
        }
    }
}
