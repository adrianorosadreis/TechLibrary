﻿using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TechLibrary.Exception
{
    public class ErrorOnValidationException : TechLibraryException
    {
        private readonly List<string> _errors;

        public ErrorOnValidationException(List<string> errorMessages)
        {
            _errors = errorMessages;
        }

        public override List<string> GetErrorMessages() => _errors; 

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.BadRequest;
        
    }
}
