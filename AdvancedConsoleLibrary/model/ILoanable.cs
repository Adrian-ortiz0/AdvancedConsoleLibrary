using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedConsoleLibrary.model
{
    interface ILoanable
    {
        void Loan(User user);
        void Return();
    }
}
