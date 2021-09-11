using Apsiyon.CrossCuttingConcerns.Validation;
using Apsiyon.Utilities.Interceptors;
using Apsiyon.Utilities.Messages;
using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Linq;

namespace Apsiyon.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
                throw new System.Exception(AspectMessages.WrongValidationType);

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entites = invocation.Arguments.Where(type => type.GetType() == entityType);

            foreach (var entity in entites)
                ValidationTool.Validate(validator, entity);
        }
    }
}
