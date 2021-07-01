using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Xero.BankFeeds.Base;
using Testing.Xero.BankFeeds.Contexts;

namespace Testing.Xero.BankFeeds.Helpers
{
    public class CodeHelper: BaseHelper
    {
        public CodeHelper(DriverContext driverContext) : base(driverContext)
        {

        }

        // Generate random string
        public string RandomString(string randType, int length)
        {
            string chars = "TEST";
            switch (randType)
            {
                case "Alphabet":
                    chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    break;
                case "Numeric":
                    chars = "0123456789";
                    break;
                case "AlphaNumeric":
                    chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    break;
                default:
                    chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                    break;
            }

            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        // Get Input data - generate random string if string contains "RandomString-"
        public string GetDataInput(string data, string randomType)
        {
            string dataOverride = "";

            //overide Login(for regression)
            if (data.Contains("RandomString-"))
            {
                int length = Int32.Parse(data.Split('-')[1]);
                dataOverride = RandomString(randomType, length);
            }
            else
            {
                dataOverride = data;
            }
            return dataOverride;
        }
    }
}
