using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtRegister
{
    internal  class Utility
    {
       public bool NullValidator(string input,string message)
        {

            if (string.IsNullOrEmpty(input))
            {
                Exception ex = new();
                throw new NullException(message, ex);
                return false;

            }
            else
            {
                return true;
            }

        }
    }
}
