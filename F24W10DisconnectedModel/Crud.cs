using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace F24W10DisconnectedModel
{
    public class Crud
    {
        SqlConnection conn;
        SqlDataAdapter adp;
        SqlCommandBuilder cmdBuilder;
        DataSet ds;
        DataTable tbl;

        public Crud()
        {
            string query = "select ProductID, ProductName, UnitPrice, UnitsInStock from Products";

            conn = new SqlConnection(Data.GetConnectionString());
            adp = new SqlDataAdapter(query, conn);
            cmdBuilder = new SqlCommandBuilder(adp);

            FillDataSet();
        }

        private void FillDataSet()
        {
            ds = new DataSet();
            adp.Fill(ds);
            tbl = ds.Tables[0];

            // define the primary key

        }

        public DataTable GetAllProducts()
        {
            FillDataSet();
            return tbl;
        }
    }
}
