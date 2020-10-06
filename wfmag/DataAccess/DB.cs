using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public partial class DB : DbContext
    {
        public List<ANALIZA_ILOSCIOWA_ARTYKULOW_ZAM_V> GetStanyMagazynowe()
        {
            using (var db = new WAPRO_DEMO_Entities())
            {
                return db.ANALIZA_ILOSCIOWA_ARTYKULOW_ZAM_V.ToList();
            }
        }

        public List<WIDOK_ZAMOWIENIE> GetOrders()
        {
            using (var db = new WAPRO_DEMO_Entities())
            {
                return db.WIDOK_ZAMOWIENIE.ToList();
            }
        }
    }
}
