using Apsiyon.CrossCuttingConcerns.Logging;
using Apsiyon.CrossCuttingConcerns.Logging.Log4Net;
using Apsiyon.Utilities.Interceptors;
using Apsiyon.Utilities.Messages;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;

namespace Apsiyon.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;
        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
                throw new System.Exception(AspectMessages.WrongLoggerType);

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }

        protected override void OnBefore(IInvocation invocation) =>  _loggerServiceBase.Info(GetLogDetail(invocation));
        protected override void OnAfter(IInvocation invocation) =>  _loggerServiceBase.Info(GetLogDetail(invocation));
        protected override void OnException(IInvocation invocation, System.Exception e) =>  _loggerServiceBase.Error(GetLogDetail(invocation));
        protected override void OnSuccess(IInvocation invocation) =>  _loggerServiceBase.Info(GetLogDetail(invocation));

        private LogDetail GetLogDetail(IInvocation invocation)
        {
            List<LogParameter> logParameters = new();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }          

            LogDetail logDetail = new()
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return logDetail;
        }
    }
}
