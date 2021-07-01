using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Xero.BankFeeds.Contexts;

namespace Testing.Xero.BankFeeds.Base
{
    public abstract class BaseHelper
    {
        public DriverContext _driverContext;

        public BaseHelper(DriverContext driverContext)
        {
            _driverContext = driverContext;
        }
    }
}
