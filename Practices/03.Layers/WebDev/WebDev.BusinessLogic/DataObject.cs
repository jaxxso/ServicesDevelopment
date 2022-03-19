using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDev.DataAccess.Context;

namespace WebDev.BusinessLogic
{
    internal class DataObject
    {

        public DataObject()
        {
            
        }

        public AppDBContext GetDataObject()
        {
            return new AppDBContext();
        }
    }
}
