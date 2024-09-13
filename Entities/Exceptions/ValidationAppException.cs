using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class ValidationAppException : Exception
    {
        public IReadOnlyDictionary<string, string[]> Errors { get; }
        public ValidationAppException(IReadOnlyDictionary<string, string[]> errors) : base("One or more validation errors occurred")
        => Errors = errors;
    }
}