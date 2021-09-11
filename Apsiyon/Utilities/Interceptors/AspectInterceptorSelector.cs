using Apsiyon.Aspects.Autofac.Exception;
using Apsiyon.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;

namespace Apsiyon.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptorBaseAttribute>
                (true).ToList();

            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptorBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new ExceptionLogAspect(typeof(DatabaseLogger)));

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
