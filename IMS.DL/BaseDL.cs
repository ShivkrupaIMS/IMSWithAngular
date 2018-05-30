using IMS.DB;
using System.Data.Entity.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DL
{
    public class BaseDL
    {
        protected IMSEntities IMSDB;
        public BaseDL()
        {
            // ReSharper disable once InconsistentNaming
            var ensureDLLIsCopied = SqlProviderServices.Instance;
            IMSDB = new IMSEntities();
        }

        public void SaveChangesToDb()
        {
            IMSDB.SaveChanges();
        }
    }
}
