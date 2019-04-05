using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.Repository
{
    public class Product_Check_Out_Repository
    {
        private Context DB = new Context();
        
        public bool Product_Create(Product_Check_Out pdt)
        {
            if(pdt.Id!=0)
            {

            }
            return true;
        }
    }
}
