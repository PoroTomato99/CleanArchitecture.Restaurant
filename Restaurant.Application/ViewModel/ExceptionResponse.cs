using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.ViewModel
{
    public class ExceptionResponse
    {
        private string type = $"Exception Error";
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        private string message = $"An Exception Error Occurred While Attemping to make changes to Database.";
        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }

        public ExceptionResponse()
        {
        }
        public ExceptionResponse(string x, string y)
        {
            Type = x;
            Message = y;
        }

        public override string ToString()
        {
            return $"{Message}";
        }
    }
}
