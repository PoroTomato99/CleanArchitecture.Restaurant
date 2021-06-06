using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.ResponsesModels
{
    public class NoUser_Excepetion
    {
        private string type = $"Not Found Exception";
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
        private string message = $"No User Found!";
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
        public NoUser_Excepetion(string x, string y)
        {
            Type = x;
            Message = y;
        }

        public override string ToString()
        {
            return $"{Type} : {Message}";
        }
    }
}
