﻿namespace TestAspNet.Domain.Validators
{
    public class ValidationFailure
    {
        public ValidationFailure()
        {
            
        }

        public ValidationFailure(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }

        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}