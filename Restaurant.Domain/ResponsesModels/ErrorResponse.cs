using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.ResponsesModels
{
    public class ErrorResponse
    {
        private string type = $"Error";
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

        private  string message = $"An Error Occured!";
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

        //Default Constructor
        public ErrorResponse() 
        {
        }

        //Customized Response
        public ErrorResponse(string type, string message)
        {
            Type = $"{this.type} : {type} ";
            Message = $"{this.message} {message}";
        }

        public override string ToString()
        {
            return $"Error Type : {Type} || Error Message : {Message}";
        }
    }
}
