using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Results.Bases
{
    public abstract class Result
    {

        public bool IsSuccessful { get;} //Sadece constructer'da set edilebilecek.

        public string Message { get; set; }

        public Result(bool isSuccessful, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }


    }
}
