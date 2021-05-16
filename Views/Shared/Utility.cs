using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Views.Shared
{
    public class Utility
    {
        public static DataSet getData(string select, string connStr)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {

                using (SqlCommand cmd = new SqlCommand(select, con))
                {

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {

                        using (DataSet ds = new DataSet())
                        {
                            da.Fill(ds);
                            return ds;
                        }
                    }
                }
            }

        }
    }
}
