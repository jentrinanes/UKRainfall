﻿using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;

namespace UKRainfall.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> ValdationErrors { get; set; }

        public ValidationException(FluentValidation.Results.ValidationResult validationResult)
        {
            ValdationErrors = new List<string>();

            foreach (var validationError in validationResult.Errors)
            {
                ValdationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
