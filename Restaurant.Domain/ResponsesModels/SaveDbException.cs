using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.ResponsesModels
{
    public class SaveDbException : Exception
    {
        public SaveDbException()
        {
        }
        public SaveDbException(string type, string error) : base(String.Format($"{type} : {error}"))
        {
        }
    }
}
