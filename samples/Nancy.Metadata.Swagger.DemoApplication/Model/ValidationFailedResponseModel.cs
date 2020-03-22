﻿using Nancy.Validation;
using System.Collections.Generic;

namespace Nancy.Metadata.Swagger.DemoApplication.Model
{
    public class ValidationFailedResponseModel
    {
        public IEnumerable<string> Messages { get; set; }

        public ValidationFailedResponseModel(string message)
        {
            Messages = new List<string>() { message };
        }

        public ValidationFailedResponseModel(ModelValidationResult validationResult)
        {
            var messages = new List<string>();

            foreach (var errorGroup in validationResult.Errors)
            {
                foreach (var error in errorGroup.Value)
                {
                    messages.Add(error.ErrorMessage);
                }
            }

            Messages = messages;
        }
    }
}
