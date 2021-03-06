﻿using System.Diagnostics;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.Intercepters;
using Core.Utilities.IoC;

namespace Core.Aspects.AutoFac.Performance
{
    public class PerformanceInterceptionAspect : MethodInterception
    {
        private readonly int _interval;
        private readonly Stopwatch _stopwatch;

        public PerformanceInterceptionAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }


        protected override void OnBefore(IInvocation invocation)
        { _stopwatch.Start(); }


        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
                Debug.WriteLine("Performans : {0}.{1} ->> {2}",
                    invocation.Method.DeclaringType.FullName,
                    invocation.Method.Name, _stopwatch.Elapsed.TotalSeconds);

            _stopwatch.Reset();
        }
    }
}