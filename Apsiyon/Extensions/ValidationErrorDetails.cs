using FluentValidation.Results;
using System.Collections.Generic;

namespace Apsiyon.Extensions
{
    public class ValidationErrorDetails : ErrorDetails
    {
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
