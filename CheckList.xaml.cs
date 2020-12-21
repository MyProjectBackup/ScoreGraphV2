using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.SqlClient;

namespace ScoreGraphV2
{
    public partial class CheckList : UserControl
    {
        private int Currentpage = 1;
        private int pageRecord = 5;
        static string connectionString = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString.ToString();
        SqlConnection mycon = new SqlConnection(connectionString);
        public double countSet = 1.0;
        public string projectName = "";

        public CheckList()
        {
            InitializeComponent();

            this.count.Content = "共" + conns().Count() + "条数据";
            countSet = conns().Count();
            SetCurrentPage(Currentpage.ToString());
            this.MaxPage.Content = MaxPaging();
            this.Page.Text = Currentpage.ToString();

            GetProjectData();
            Paging(pageRecord, 1);
        }

        //获取下拉框绑定值
        public void GetProjectData()
        {
            string sql = "select * from tb_score";
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

            List<ComboBoxProject> lus1 = new List<ComboBoxProject>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string temp = dt.Rows[i][2].ToString();
                var model = lus1.Where(c => c.Project == temp).FirstOrDefault();
                if (model == null)
                {
                    lus1.Add(new ComboBoxProject { ID = Convert.ToInt32(dt.Rows[i][0]), Project = dt.Rows[i][2].ToString() });
                }
            }

            this.ProjectComboBox.DisplayMemberPath = "Project";
            this.ProjectComboBox.SelectedValuePath = "ID";
            this.ProjectComboBox.SelectedIndex = 0;
            this.ProjectComboBox.ItemsSource = lus1;
        }

        //条件查询事件
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SeleteWhere(GetName(), GetProject());

            projectName = GetProject().ToString();

            Paging(pageRecord, 1);

            if (Currentpage != 1)
            {
                Setpage("1");
                SetCurrentPage("1");
                Paging(pageRecord, 1);
                Currentpage = 1;
            }
        }

        //全部查询事件
        private void Border_MouseLeftButtonDownAll(object sender, MouseButtonEventArgs e)
        {
            projectName = "";

            Paging(pageRecord, 1);

            this.count.Content = "共" + conns().Count() + "条数据";
            countSet = conns().Count();
            SetCurrentPage(Currentpage.ToString());
            this.MaxPage.Content = MaxPaging();
            this.Page.Text = Currentpage.ToString();

            if (Currentpage != 1)
            {
                Setpage("1");
                SetCurrentPage("1");
                Paging(pageRecord, 1);
                Currentpage = 1;
            }
        }

        //页数跳转
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var page = this.Page.Text;
            var maxpage = MaxPaging();
            if (Convert.ToDouble(page) > maxpage)
            {
                Paging(pageRecord, Convert.ToInt32(maxpage));
                SetCurrentPage(maxpage.ToString());
                Currentpage = Convert.ToInt32(maxpage);
                Setpage(maxpage.ToString());
            }
            if (Convert.ToDouble(page) < 0)
            {
                Paging(pageRecord, 1);
                SetCurrentPage("1");
                Currentpage = 1;
                Setpage("1");
            }
            else if (Convert.ToDouble(page) <= maxpage && Convert.ToDouble(page) > 0)
            {
                Paging(pageRecord, Convert.ToInt32(page));
                SetCurrentPage(page);
                Currentpage = Convert.ToInt32(page);
                Setpage(page);
            }
        }

        private void Page_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");
            e.Handled = re.IsMatch(e.Text);
        }

        // 第一页       
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (Currentpage != 1)
            {
                Setpage("1");
                SetCurrentPage("1");
                Paging(pageRecord, 1);
                Currentpage = 1;
            }
        }

        // 上一页        
        private void Image_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            if (Currentpage != 1 && (Currentpage - 1) >= 1)
            {
                Setpage((Currentpage - 1).ToString());
                SetCurrentPage((Currentpage - 1).ToString());
                Paging(pageRecord, --Currentpage);
            }
        }

        // 最后一页
        private void Image_MouseUp_2(object sender, MouseButtonEventArgs e)
        {
            double MaxPage = MaxPaging();
            if (Currentpage != MaxPage)
            {
                Setpage(MaxPage.ToString());
                SetCurrentPage(MaxPage.ToString());
                Paging(pageRecord, (int)MaxPage);
                Currentpage = (int)MaxPage;
            }
        }

        // 下一页
        private void Image_MouseUp_3(object sender, MouseButtonEventArgs e)
        {
            double MaxPage = MaxPaging();
            if (Currentpage != MaxPage && (Currentpage + 1) <= MaxPage)
            {
                Setpage((Currentpage + 1).ToString());
                SetCurrentPage((Currentpage + 1).ToString());
                Paging(pageRecord, ++Currentpage);
            }
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

        // 设置当前页
        public void SetCurrentPage(string page)
        {
            this.CurrentPage.Content = page;
            int max = Convert.ToInt32(MaxPaging());
            if (Convert.ToInt32(page) <= max - 1)
            {
                this.CurrentPage2.Content = Convert.ToInt32(page) + 1;
            }
            else
            {
                this.CurrentPage2.Content = "";
            }
            if (Convert.ToInt32(page) <= max - 2)
            {
                this.CurrentPage3.Content = Convert.ToInt32(page) + 2;
            }
            else
            {
                this.CurrentPage3.Content = "";
            }
        }

        // 设置文本框当前页数值
        public void Setpage(string page)
        {
            this.Page.Text = page;
        }

        // 获取最大页数
        public double MaxPaging()
        {
            //double count = conns().Count();
            double count = countSet;
            return Math.Ceiling(count / pageRecord);
        }

        public string GetName()
        {
            return this.Users_Name.Text;
        }

        public string GetProject()
        {
            var bl = this.ProjectComboBox.Text.ToString();
            if (bl == null)
                return null;
            else
                return bl;
        }

        // 查询全部数据       
        public List<UsersScore> conns()
        {
            SqlCommand cmd = mycon.CreateCommand();
            cmd.CommandText = "select * from tb_score";
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

            List<UsersScore> lus1 = new List<UsersScore>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lus1.Add(new UsersScore { Id = Convert.ToInt32(dt.Rows[i][0]), Name = dt.Rows[i][1].ToString(), Project = dt.Rows[i][2].ToString(), Score = dt.Rows[i][3].ToString(), Time = Convert.ToDateTime(dt.Rows[i][4]) });
            }
            return lus1;
            //this.dataGrid1.ItemsSource = lus1;
        }

        //分页查询
        public void Paging(int pageSize, int currentPage)
        {
            string Name = GetName();
            int pages = pageSize * (currentPage - 1) + 1;
            string sql1 = string.Format("select top {0} * from tb_score where student_id>=(select max(student_id) from (select top {1} student_id from tb_score order by student_id asc ) t ) order by student_id asc", pageSize, pages);
            string sql2 = string.Format("select top {0} * from tb_score where student_id>=(select max(student_id) from (select top {1} student_id from tb_score where project='{2}'order by student_id asc ) t ) and project='{2}' order by student_id asc", pageSize, pages, projectName);
            string sql3 = string.Format("select top {0} * from tb_score where student_id>=(select max(student_id) from (select top {1} student_id from tb_score where project='{2}'and user_name='{3}' order by student_id asc ) t ) and project='{2}' and user_name='{3}' order by student_id asc", pageSize, pages, projectName, Name);
            SqlCommand cmd = mycon.CreateCommand();
            if (projectName == "")
                cmd.CommandText = sql1;
            if (projectName != "" && Name == "")
            {
                cmd.CommandText = sql2;
            }
            if (projectName != "" && Name != "")
            {
                cmd.CommandText = sql3;
            }

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

            List<UsersScore> lus1 = new List<UsersScore>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lus1.Add(new UsersScore { Id = Convert.ToInt32(dt.Rows[i][0]), Name = dt.Rows[i][1].ToString(), Project = dt.Rows[i][2].ToString(), Score = dt.Rows[i][3].ToString(), Time = Convert.ToDateTime(dt.Rows[i][4]) });
            }
            this.dataGrid1.ItemsSource = lus1;
        }

        //条件查询
        private void SeleteWhere(string Name, string Project)
        {
            SqlCommand cmd = mycon.CreateCommand();
            string sql1 = string.Format("select * from tb_score where user_name='{0}' and project='{1}' order by student_id asc", Name, Project);
            string sql2 = string.Format("select * from tb_score where user_name='{0}' order by student_id asc", Name);
            string sql3 = string.Format("select * from tb_score where project='{0}' ", Project);
            if (Project != null && Name != "")
            { cmd.CommandText = sql1; }

            if (Project == null && Name != "")
            { cmd.CommandText = sql2; }

            if (Project != null && Name == "")
            { cmd.CommandText = sql3; }

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

            List<UsersScore> lus1 = new List<UsersScore>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lus1.Add(new UsersScore { Id = Convert.ToInt32(dt.Rows[i][0]), Name = dt.Rows[i][1].ToString(), Project = dt.Rows[i][2].ToString(), Score = dt.Rows[i][3].ToString(), Time = Convert.ToDateTime(dt.Rows[i][4]) });
            }
            this.dataGrid1.ItemsSource = lus1;

            countSet = lus1.Count();
            this.count.Content = "共" + countSet + "条数据";
            SetCurrentPage(Currentpage.ToString());
            this.MaxPage.Content = Math.Ceiling(countSet / pageRecord);
            this.Page.Text = Currentpage.ToString();
        }

        //删除一条用户数据
        private void DeleteUserScore(int Id)
        {
            try
            {
                ConnOpen();
                string strSql = string.Format("delete from tb_score where [student_id]={0}", Id);
                SqlCommand cmd = new SqlCommand(strSql, mycon);
                int a = cmd.ExecuteNonQuery();
                ConnClose();
                if (a > 0)
                {
                    conns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // 删除一条数据
        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("请确认删除此条数据？", "", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                if (SubRowsId() == null)
                {
                    MessageBox.Show("请先鼠标单击选定要删除的数据所在行！");
                }
                else
                {
                    DeleteUserScore(SubRowsId().Id);
                    Paging(pageRecord, Currentpage);
                    this.MaxPage.Content = MaxPaging();
                    this.Page.Text = MaxPaging().ToString();
                    this.count.Content = conns().Count();
                }
            }
        }

        // 获取选中行的原始值    
        private UsersScore SubRowsId()
        {
            return (UsersScore)dataGrid1.SelectedItem;
        }

        private DataRowView GetSelectedRow()
        {
            if (dataGrid1 != null && dataGrid1.SelectedCells.Count != 0)
            {
                return dataGrid1.SelectedCells[0].Item as DataRowView;
            }
            return null;
        }

        // 调取用户曲线图
        private void s_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (SubRowsId() == null)
            {
                MessageBox.Show("请先鼠标单击选定的数据所在行！");
            }
            else
            {
                GetSelectedRow();
                var name = SubRowsId().Name;
                var project = SubRowsId().Project;

                if (project == "汉字输入")
                {
                    ChineseCharacterInput c = new ChineseCharacterInput(name);
                    c.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    c.Show();
                    c.Activate();
                }
                else
                {
                    ScoreGraph uu = new ScoreGraph(name, project);
                    uu.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    uu.Show();
                    uu.Activate();
                }
            }
        }
    }

    public class ComboBoxProject
    {
        public int ID { get; set; }
        public string Project { get; set; }
    }
}