using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.SqlClient;

namespace ScoreGraphV2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //string connectionString = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString.ToString();
            //string sql = "select user_name, project,score,time from tb_score";
            //SqlConnection mycon = new SqlConnection(connectionString);
            //mycon.Open();
            //SqlDataAdapter myda = new SqlDataAdapter(sql, connectionString);
            //DataTable dt = new DataTable();
            //myda.Fill(dt);
            //ScoreDataGrid.ItemsSource = dt.DefaultView;
            //mycon.Close();
        }
    }
}