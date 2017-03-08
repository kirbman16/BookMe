using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace Web.ViewModels
{
    public class ErrorViewModel
    {
        public string ErrorMessage { get; set; }

        public ErrorViewModel(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

    }
}