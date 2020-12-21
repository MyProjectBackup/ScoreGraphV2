using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace ScoreGraphV2
{
    /// <summary>
    /// ChineseCharacterInput.xaml 的交互逻辑
    /// </summary>
    public partial class ChineseCharacterInput : Window
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString.ToString();
        SqlConnection mycon = new SqlConnection(connectionString);

        public ChineseCharacterInput()
        {
            //InitializeComponent();
        }

        public ChineseCharacterInput(string Name)
        {
            InitializeComponent();
            //if (this.IsLoaded)
            //{
                GetProjectData(Name);
            //}            
        }

        public void GetProjectData(string Name)
        {
            string sql = string.Format("select top 10 Name,CountPerMinutes,CorrectPercentage,FinishedPercentage,StartAt,LastUpdate from History where Name='{0}' order by LastUpdate desc", Name);
            SqlCommand cmd = mycon.CreateCommand();
            cmd.CommandText = sql;
            ConnOpen();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();

            if (dr.HasRows)
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    dt.Columns.Add(dr.GetName(i));
                }
                dt.Rows.Clear();
            }
            while (dr.Read())
            {
                DataRow row = dt.NewRow();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    row[i] = dr[i];
                }
                dt.Rows.Add(row);
            }
            cmd.Dispose();
            ConnClose();

            TimeSpan interval;

            List<History> lus1 = new List<History>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                interval = Convert.ToDateTime(dt.Rows[i][5]) - Convert.ToDateTime(dt.Rows[i][4]);

                
                lus1.Add(new History { Name = Convert.ToString(dt.Rows[i][0]), CountPerMinutes = Convert.ToInt32(dt.Rows[i][1]), CorrectPercentage = Convert.ToInt32(dt.Rows[i][2]), FinishedPercentage = Convert.ToInt32(dt.Rows[i][3]), StartAt = Convert.ToDateTime(dt.Rows[i][4]), LastUpdate = Convert.ToDateTime(dt.Rows[i][5]), Interval= Convert.ToInt32(interval.TotalSeconds) });

                
            }
            this.dataGrid2.ItemsSource = lus1;
        }

        public void ConnOpen()
        {
            if (mycon.State == ConnectionState.Closed)
            {
                mycon.Open();
            }
        }
        public void ConnClose()
        {
            if (mycon.State == ConnectionState.Open)
            {
                mycon.Close();
            }
        }
    }
}
