using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PMS.Helper
{
    public class HelperClass
    {
        public string hashPassword(string pass)
        {
            var hasher = new SHA1Managed();
            var data = hasher.ComputeHash(Encoding.UTF8.GetBytes(pass));

            return BitConverter.ToString(data).Replace("-", String.Empty);

        }

    }
}