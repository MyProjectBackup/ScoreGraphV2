using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Visifire.Charts;

namespace ScoreGraphV2
{
    /// <summary>
    /// ScoreGraph.xaml 的交互逻辑
    /// </summary>
    public partial class ScoreGraph : Window
    {
        //private static ScoreGraph _instance;
        //private static readonly object ObjLok = new object();

        static string connectionString = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString.ToString();
        SqlConnection mycon = new SqlConnection(connectionString);

        private List<string> strListx = new List<string>();
        private List<string> strListy = new List<string>();
        private List<DateTime> LsTime = new List<DateTime>();

        public ScoreGraph()
        {
            InitializeComponent();
            GetProjectData();
        }

        public ScoreGraph(string name, string project)
        {
            InitializeComponent();

            GetProjectData();
            this.Users_Name.Text = name;
            this.ProjectComboBox.Text = project;
            SeleteWhere(name, project);
            ButColumn_Click(null, null);
        }

        //public static ScoreGraph Instance()
        //{
        //    lock (ObjLok)
        //    {
        //        return _instance ?? (_instance = new ScoreGraph());
        //    }
        //}

        //protected override void OnClosing(CancelEventArgs e)
        //{
        //    Hide();
        //    e.Cancel = true;
        //}

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
        private void SeleteWhere(string Name, string Project)
        {
            if (Name == "" || Name == null)
            {
                MessageBox.Show("请输入姓名后再次查询 \n 窗口将返回到上一查询结果的柱状图！");
                return;
            }

            if (Project == "汉字输入" )
            {
                MessageBox.Show("尚无汉字输入评分标准 \n 请回主页面查看相关详细训练数据！");
                return;
            }

            SqlCommand cmd = mycon.CreateCommand();
            string sql = string.Format("select top 10 * from tb_score where user_name='{0}' and project='{1}' order by time desc", Name, Project);
            //string sql = "select top 10 * from tb_score where user_name='B' and project='BB' order by time asc";
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

            strListy.Clear();
            strListx.Clear();
            LsTime.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strListy.Add(dt.Rows[i][3].ToString());
                var temp = dt.Rows[i][4].ToString();
                strListx.Add(temp);
                var tempTime = Convert.ToDateTime(dt.Rows[i][4]);
                LsTime.Add(tempTime);
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

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SeleteWhere(GetName(), GetProject());
            //Simon.Children.Clear();
            ButColumn_Click(null, null);
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

        private void ButColumn_Click(object sender, RoutedEventArgs e)
        {
            //Simon.Children.Clear();
            var tempName = GetName();
            var tempProjece = GetProject();
            string tempTitle = string.Format("{0} 近十次 {1} 训练成绩", tempName, tempProjece);
            CreateChartColumn(tempTitle, strListx, strListy);
        }

        private void ButPie_Click(object sender, RoutedEventArgs e)
        {
            Simon.Children.Clear();
            var tempName = GetName();
            var tempProjece = GetProject();
            string tempTitle = string.Format("{0} 近十次 {1} 训练成绩", tempName, tempProjece);
            CreateChartPie(tempTitle, strListx, strListy);
        }
        private void ButSpline_Click(object sender, RoutedEventArgs e)
        {
            Simon.Children.Clear();
            var tempName = GetName();
            var tempProjece = GetProject();
            string tempTitle = string.Format("{0} 近十次 {1} 训练成绩", tempName, tempProjece);
            CreateChartSpline(tempTitle, LsTime, strListy);
        }

        #region 柱状图
        public void CreateChartColumn(string name, List<string> valuex, List<string> valuey)
        {
            //创建一个图标
            Chart chart = new Chart();

            //设置图标的宽度和高度
            chart.Width = 580;
            chart.Height = 380;
            chart.Margin = new Thickness(100, 5, 10, 5);

            //是否启用打印和保持图片
            chart.ToolBarEnabled = false;

            //设置图标的属性
            chart.ScrollingEnabled = false;//是否启用或禁用滚动
            chart.View3D = true;//3D效果显示

            //创建一个标题的对象
            Title title = new Title();

            //设置标题的名称
            title.Text = name;
            title.Padding = new Thickness(0, 10, 5, 0);

            //向图标添加标题
            chart.Titles.Add(title);

            Axis yAxis = new Axis();
            //设置图标中Y轴的最小值永远为0           
            yAxis.AxisMinimum = 0;
            //设置图表中Y轴的后缀          
            yAxis.Suffix = "分";
            chart.AxesY.Add(yAxis);

            //创建一个新的数据线。               
            DataSeries dataSeries = new DataSeries();

            //设置数据线的格式
            dataSeries.RenderAs = RenderAs.StackedColumn;//柱状Stacked

            //设置数据点              
            DataPoint dataPoint;
            for (int i = 0; i < valuex.Count; i++)
            {
                //创建一个数据点的实例。                   
                dataPoint = new DataPoint();
                //设置X轴点                    
                dataPoint.AxisXLabel = valuex[i];
                //设置Y轴点                   
                dataPoint.YValue = double.Parse(valuey[i]);
                //添加一个点击事件        
                dataPoint.MouseLeftButtonDown += new MouseButtonEventHandler(dataPoint_MouseLeftButtonDown);
                //添加数据点                   
                dataSeries.DataPoints.Add(dataPoint);
            }

            // 添加数据线到数据序列。                
            chart.Series.Add(dataSeries);

            //将生产的图表增加到Grid，然后通过Grid添加到上层Grid.           
            Grid gr = new Grid();
            gr.Children.Add(chart);
            Simon.Children.Add(gr);
        }
        #endregion

        #region 饼状图
        public void CreateChartPie(string name, List<string> valuex, List<string> valuey)
        {
            //创建一个图标
            Chart chart = new Chart();

            //设置图标的宽度和高度
            chart.Width = 580;
            chart.Height = 380;
            chart.Margin = new Thickness(100, 5, 10, 5);

            //是否启用打印和保持图片
            chart.ToolBarEnabled = false;

            //设置图标的属性
            chart.ScrollingEnabled = false;//是否启用或禁用滚动
            chart.View3D = true;//3D效果显示

            //创建一个标题的对象
            Title title = new Title();

            //设置标题的名称
            title.Text = name;
            title.Padding = new Thickness(0, 10, 5, 0);

            //向图标添加标题
            chart.Titles.Add(title);

            //创建一个新的数据线。               
            DataSeries dataSeries = new DataSeries();

            // 设置数据线的格式
            dataSeries.RenderAs = RenderAs.Pie;

            // 设置数据点              
            DataPoint dataPoint;
            for (int i = 0; i < valuex.Count; i++)
            {
                // 创建一个数据点的实例。                   
                dataPoint = new DataPoint();
                // 设置X轴点                    
                dataPoint.AxisXLabel = valuex[i];
                dataPoint.LegendText = "##" + valuex[i];
                //设置Y轴点                   
                dataPoint.YValue = double.Parse(valuey[i]);
                //添加一个点击事件        
                dataPoint.MouseLeftButtonDown += new MouseButtonEventHandler(dataPoint_MouseLeftButtonDown);
                //添加数据点                   
                dataSeries.DataPoints.Add(dataPoint);
            }

            //添加数据线到数据序列。                
            chart.Series.Add(dataSeries);

            //将生产的图表增加到Grid，然后通过Grid添加到上层Grid.           
            Grid gr = new Grid();
            gr.Children.Add(chart);
            Simon.Children.Add(gr);
        }
        #endregion

        #region 折线图
        public void CreateChartSpline(string name, List<DateTime> lsTime, List<string> cherry)
        {
            //创建一个图标
            Chart chart = new Chart();

            //设置图标的宽度和高度
            chart.Width = 580;
            chart.Height = 380;
            chart.Margin = new Thickness(100, 5, 10, 5);

            //是否启用打印和保持图片
            chart.ToolBarEnabled = false;

            //设置图标的属性
            chart.ScrollingEnabled = false;//是否启用或禁用滚动
            chart.View3D = true;//3D效果显示

            //创建一个标题的对象
            Title title = new Title();

            //设置标题的名称
            title.Text = name;
            title.Padding = new Thickness(0, 10, 5, 0);

            //向图标添加标题
            chart.Titles.Add(title);

            //初始化一个新的Axis
            Axis xaxis = new Axis();

            //设置Axis的属性
            //图表的X轴坐标按什么来分类，如时分秒
            xaxis.IntervalType = IntervalTypes.Months;
            //图表的X轴坐标间隔如2,3,20等，单位为xAxis.IntervalType设置的时分秒。
            xaxis.Interval = 1;
            //设置X轴的时间显示格式为7-10 11：20           
            xaxis.ValueFormatString = "MM月";
            //给图标添加Axis            
            chart.AxesX.Add(xaxis);

            Axis yAxis = new Axis();
            //设置图标中Y轴的最小值永远为0           
            yAxis.AxisMinimum = 0;
            //设置图表中Y轴的后缀          
            yAxis.Suffix = "分";
            chart.AxesY.Add(yAxis);

            //创建一个新的数据线。               
            DataSeries dataSeries = new DataSeries();
            //设置数据线的格式。               
            dataSeries.LegendText = "训练科目";

            dataSeries.RenderAs = RenderAs.Spline;//折线图

            dataSeries.XValueType = ChartValueTypes.DateTime;

            // 设置数据点              
            DataPoint dataPoint;
            for (int i = 0; i < lsTime.Count; i++)
            {
                //创建一个数据点的实例。                   
                dataPoint = new DataPoint();
                //设置X轴点                    
                dataPoint.XValue = lsTime[i];
                //设置Y轴点                   
                dataPoint.YValue = double.Parse(cherry[i]);
                dataPoint.MarkerSize = 8;
                dataPoint.MouseLeftButtonDown += new MouseButtonEventHandler(dataPoint_MouseLeftButtonDown);
                //添加数据点                   
                dataSeries.DataPoints.Add(dataPoint);
            }

            // 添加数据线到数据序列。                
            chart.Series.Add(dataSeries);

            //将生产的图表增加到Grid，然后通过Grid添加到上层Grid.           
            Grid gr = new Grid();
            gr.Children.Add(chart);

            Simon.Children.Add(gr);
        }
        #endregion

        #region 点击事件
        //点击事件
        private void dataPoint_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //DataPoint dp = sender as DataPoint;
            //MessageBox.Show(dp.YValue.ToString());
        }
        #endregion
    }
}