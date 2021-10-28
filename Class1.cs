using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace İnternet_Cafe_Otomasyonu
{
    class sqlbaglanti
    {
        
        public SqlConnection sqlbaglan()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=LAPTOP-4ATMOO8A;Initial Catalog=İnternetCafeOtomasyonu;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
