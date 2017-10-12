using System;
using System.Collections.Generic;
using System.Linq;

namespace TestAspNet.Domain.Validators
{
    public class MethodResult
    {
        private readonly List<ValidationFailure> _failures = new List<ValidationFailure>();

        public MethodResult()
        {
        }

        public MethodResult(ValidationFailure validationFailure)
        {
            Add(validationFailure);
        }

        public MethodResult(string propertyName, string errorMessage)
        {
            Add(propertyName, errorMessage);
        }

        public MethodResult(string errorMessage)
        {
            Add(errorMessage);
        }

        public MethodResult(object data)
        {
            Data = data;
        }

        public IReadOnlyCollection<ValidationFailure> Failures => _failures;

        public object Data { get; set; }

        public void Add(ValidationFailure validationFailure)
        {
            if (string.IsNullOrEmpty(validationFailure?.ErrorMessage?.Trim()))
                return;

            if (_failures.Contains(validationFailure) || Exists(validationFailure.PropertyName, validationFailure.ErrorMessage))
                return;   

            _failures.Add(validationFailure);
        }

        public void Add(string propertyName, string errorMessage)
        {
            propertyName = propertyName?.Trim();

            if (string.IsNullOrEmpty(errorMessage?.Trim()))
                return;

            _failures.Add(new ValidationFailure(propertyName, errorMessage));
        }

        public void Add(string errorMessage)
        {
            if (string.IsNullOrEmpty(errorMessage?.Trim()))
                return;

            _failures.Add(new ValidationFailure("", errorMessage));
        }

        private bool Exists(string propertyName, string errorMessage)
        {
            return _failures.Any(v =>
                v.PropertyName.Equals(propertyName, StringComparison.OrdinalIgnoreCase) &&
                v.ErrorMessage.Equals(errorMessage, StringComparison.OrdinalIgnoreCase));
        }
    }
}