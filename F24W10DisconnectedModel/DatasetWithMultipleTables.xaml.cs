using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace F24W10DisconnectedModel
{
    /// <summary>
    /// Interaction logic for DatasetWithMultipleTables.xaml
    /// </summary>
    public partial class DatasetWithMultipleTables : Window
    {
        public DatasetWithMultipleTables()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            string query = "select * from Categories; select * from Products";

            SqlConnection conn = new SqlConnection(Data.GetConnectionString());
            SqlDataAdapter adp = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();

            adp.Fill(ds);

            ds.Tables[0].TableName = "Categories";
            ds.Tables[1].TableName = "Products";

            grdCategories.ItemsSource = ds.Tables[0].DefaultView;
            grdProducts.ItemsSource = ds.Tables["Products"].DefaultView;
        }
    }
}
