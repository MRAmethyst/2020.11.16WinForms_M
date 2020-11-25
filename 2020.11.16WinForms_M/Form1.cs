using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace _2020._11._16WinForms_M
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public DataTable Elc_Point = new DataTable();  // 定义数据表格Elc_Point
        List<string> filenames = new List<string>();

        // 调用MATLAB
        private void btnMATLAB_Click(object sender, EventArgs e)
        {
            Process proc = null;
           
            try
            {
                Folder_Manipulate.DeleteFolder_txt("C:\\Users\\Amethyst\\Desktop\\11.16", "*.txt");

                System.Threading.Thread.Sleep(500);

                // 生成需要时间，不能和显示放在一起
                // 利用.bat文件，运行MATLAB，生成数据txt文件
                string targetDir = string.Format(@"C:\Users\Amethyst\Desktop\11.16\");//this is where testChange.bat lies
                proc = new Process();
                proc.StartInfo.WorkingDirectory = targetDir;
                proc.StartInfo.FileName = "1.bat";
                proc.StartInfo.Arguments = string.Format("10");//this is argument
                //proc.StartInfo.CreateNoWindow = true;
                //proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;//这里设置DOS窗口不显示，经实践可行
                proc.Start();
                proc.WaitForExit();

                int count = 0;

                while(true)
                {
                    Folder_Manipulate.Get_txt_Names("c:\\users\\amethyst\\desktop\\11.16", filenames);  //  调用函数
                    count = filenames.Count;
                    //MessageBox.Show("共有" + count.ToString() + "个txt文件");

                    if (count < 6)
                    {
                        labstate.Text = "运行中";
                        System.Threading.Thread.Sleep(500);
                    }
                    else
                    {
                        labstate.Text = "运行结束";
                        //MessageBox.Show("运行结束。");
                        break;
                    }

                    count = 0;
                }

                MessageBox.Show("运行结束");

                //MessageBox.Show("共有" + count.ToString() + "个txt文件");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
                MessageBox.Show("错误");
            }
        }

        // 作图按钮
        private void btnPicture_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                DataTable table = new DataTable();
                this.chartEBus.Series.Clear();   // 清空图表中的内容

                chartEBus.DataSource = Elc_Point;  // 选择数据来源

                this.chartEBus.Titles.Add("数据波形图");// 添加标题
                Series series = this.chartEBus.Series.Add("电压");// 添加电压列
                series.XValueMember = "";  // x轴为时间
                series.YValueMembers = "电压";  // y轴为数据
                Series series1 = this.chartEBus.Series.Add("相角");// 添加相角列
                series1.XValueMember = "";
                series1.YValueMembers = "相角";
                Series series2 = this.chartEBus.Series.Add("有功注入");// 添加有功注入列
                series2.XValueMember = "";
                series2.YValueMembers = "有功注入";
                Series series3 = this.chartEBus.Series.Add("无功注入");// 添加无功注入列
                series3.XValueMember = "";
                series3.YValueMembers = "无功注入";

                this.chartEBus.Series[0].ChartType = SeriesChartType.Column;//指定图表的类型，这里是折线图 column是柱形图  
                this.chartEBus.Series[0].Color = Color.Blue;
                this.chartEBus.Series[1].ChartType = SeriesChartType.Column;
                this.chartEBus.Series[1].Color = Color.Red;
                this.chartEBus.Series[2].ChartType = SeriesChartType.Column;
                this.chartEBus.Series[2].Color = Color.Yellow;
                */

                //var frm = new Form2();
                //frm.Show();



            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
                MessageBox.Show("错误");
            }
        }

        // 读取txt文件，显示数据表格
        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                //List<Profive_Para> datalist = null;  // 创建数据list
                //datalist = new List<Profive_Para>(); // 初始化
                //Profive_Para ParaFive = null;        // 循环用的单个对象  

                // 读取生成的txt文件
                //DataTable Elc_Point = new DataTable();  // 定义数据表格Elc_Point
                DataRow row;  // 定义Elc_Point行；
                DataColumn column;  // 定义Elc_Point列；
                DataView view;  // 定义Elc_Point显示；

                // 读文件用的。参数1：文件绝对路径……
                FileStream fs = new FileStream("C:\\Users\\Amethyst\\Desktop\\11.16\\EBusResult.txt", FileMode.Open, FileAccess.Read, FileShare.None); 
                StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding(936));                  // 读文件用的

                // datatable列命名
                Elc_Point.Columns.Add(new DataColumn("序号", typeof(int)));
                Elc_Point.Columns.Add(new DataColumn("电压", typeof(float)));
                Elc_Point.Columns.Add(new DataColumn("相角", typeof(float)));
                Elc_Point.Columns.Add(new DataColumn("有功注入", typeof(float)));
                Elc_Point.Columns.Add(new DataColumn("无功注入", typeof(float)));
                Elc_Point.Columns.Add(new DataColumn("有功生成", typeof(float)));
                Elc_Point.Columns.Add(new DataColumn("无功生成", typeof(float)));
                Elc_Point.Columns.Add(new DataColumn("节点负荷", typeof(float)));
                Elc_Point.Columns.Add(new DataColumn("CHP机组功率", typeof(float)));
                Elc_Point.Columns.Add(new DataColumn("压缩机功率", typeof(float)));
                Elc_Point.Columns.Add(new DataColumn("循环泵功率", typeof(float)));
                Elc_Point.Columns.Add(new DataColumn("电锅炉功率", typeof(float)));

                string str = "";  // 用于储存一行文字
                int count = 0;

                while (true)
                {
                    // 读一行
                    str = sr.ReadLine();

                    // 读完5行，就不读了
                    if (str == null)  //count == 6
                    {
                        break;
                    }

                    // 忽略第一行
                    if (count > 0)
                    {
                        // 把读到的一行数据按照逗号分隔
                        string[] data = str.Split(',');

                        row = Elc_Point.NewRow();  // Elc_Point表创建一行
                        // 向row中写入数据
                        row["序号"] = Convert.ToInt32(data[0]);   // 字符串转int
                        row["电压"] = Convert.ToSingle(data[1]);  // 字符串转float，下同。  Convert.ToDouble(numStr);这个可以转为double
                        row["相角"] = Convert.ToSingle(data[2]);
                        row["有功注入"] = Convert.ToSingle(data[3]);
                        row["无功注入"] = Convert.ToSingle(data[4]);
                        row["有功生成"] = Convert.ToSingle(data[5]);
                        row["无功生成"] = Convert.ToSingle(data[6]);
                        row["节点负荷"] = Convert.ToSingle(data[7]);
                        row["CHP机组功率"] = Convert.ToSingle(data[8]);
                        row["压缩机功率"] = Convert.ToSingle(data[9]);
                        row["循环泵功率"] = Convert.ToSingle(data[10]);
                        row["电锅炉功率"] = Convert.ToSingle(data[11]);

                        Elc_Point.Rows.Add(row);  //添加到表中
                    }

                    count++;

                    dgvElc_P.DataSource = Elc_Point;
                    dgvElc_P.Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
                MessageBox.Show("错误");
            }

        }

        /// <summary>
        /// 将DataTable里面的内容写入txt文件并保存，不美观，无法改文件名和路径
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="columnNames">要写的字段列表</param>
        /// <param name="fileName">文件名，全路径，建议以.txt为后缀</param>
        /// <param name="encoding">文件编码格式</param>
        /// <param name="fieldsTerminated">字段分隔符，默认为\t制表符</param>
        /// <returns></returns>
        public void WriteDataTableIntoFile(DataTable dt, List<string> columnNames, string fileName, Encoding encoding, string fieldsTerminated = "\t")
        {
            if (dt == null)
            {
                return;
            }

            //写数据文件
            using (StreamWriter streamWriter = new StreamWriter(fileName, false, encoding))
            {
                int col = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    col = 0;
                    foreach (string column in columnNames)
                    {
                        if (col > 0)
                        {
                            streamWriter.Write(fieldsTerminated);
                        }
                        if (dt.Columns[column].DataType == typeof(DateTime))
                        {
                            if (dr[column] == DBNull.Value)
                            {
                                //streamWriter.Write("0000-00-00 00:00:00");
                            }
                            else
                            {
                                streamWriter.Write(((DateTime)dr[column]).ToString("yyyy-MM-dd HH:mm:ss"));
                            }
                        }
                        else
                        {

                            streamWriter.Write(Convert.ToString(dr[column]).Replace('\t', ' ').Replace('\r', ' ').Replace('\n', ' '));
                        }
                        col++;
                    }
                    streamWriter.WriteLine();
                    streamWriter.Flush();
                }
                streamWriter.Close();
                streamWriter.Dispose();
            }
        }

        /// <summary>
        /// 将DataTable里面的内容写入txt文件并保存
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <returns></returns>
        public void dt_Save_txt (DataTable dt)
        {
            var tb = new TextBox();  // 新建一个TextBox作为数据载体 (不显示)
            tb.Text = null;  // 初始化为null

            // 将DataTable的数据写入TextBox
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    tb.Text += dt.Rows[i][j].ToString() + "\t";  // 写入一个数据并对齐
                }

                if(i < dt.Rows.Count - 1)
                {
                    tb.Text += "\r\n";// 最后一行不再换行
                }
            }

            // 创建保存对话框，美观保存，需要控件载体
            SaveFileDialog saveDataSend = new SaveFileDialog();
            // Environment.SpecialFolder.MyDocuments 表示在我的文档中
            saveDataSend.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);   // 获取文件路径
            saveDataSend.Filter = "*.txt|txt file";   // 设置文件类型为文本文件
            saveDataSend.DefaultExt = ".txt";   // 默认文件的拓展名
            saveDataSend.FileName = "Data.txt";   // 文件默认名

            if (saveDataSend.ShowDialog() == DialogResult.OK)   // 显示文件框，并且选择文件
            {
                string fName = saveDataSend.FileName;   // 获取文件名

                // 参数1：写入文件的文件名；参数2：写入文件的内容                                        
                System.IO.File.WriteAllText(fName, tb.Text);   // 向文件中写入内容

                MessageBox.Show("保存成功！", "提示");
            }
        }

        // 保存按钮
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                dt_Save_txt(Elc_Point);

                /*
                // 将DataTable里面的内容写入txt文件并保存，不美观，无法改文件名和路径
                List<string> namelist = null;  // 创建名称list
                namelist = new List<string>() { "序号", "电压", "相角", "有功注入", "无功注入",
                                                "有功生成", "无功生成", "节点负荷", "CHP机组功率", 
                                                "压缩机功率","循环泵功率","电锅炉功率"};  // 这个定义方法要记一下
                WriteDataTableIntoFile(Elc_Point, namelist, "C:\\Users\\Amethyst\\Desktop\\11.16\\Data.txt", Encoding.UTF8,"\t");
                MessageBox.Show("保存成功！", "提示");
                

                //var tb = new TextBox();
                //tb.Text = null;
                //tb.Text += Elc_Point.Rows[0][1].ToString() + "\r\n";

                
                // 创建保存对话框，美观保存，需要控件载体
                SaveFileDialog saveDataSend = new SaveFileDialog();
                // Environment.SpecialFolder.MyDocuments 表示在我的文档中
                saveDataSend.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);   // 获取文件路径
                saveDataSend.Filter = "*.txt|txt file";   // 设置文件类型为文本文件
                saveDataSend.DefaultExt = ".txt";   // 默认文件的拓展名
                saveDataSend.FileName = "Data.txt";   // 文件默认名

                if (saveDataSend.ShowDialog() == DialogResult.OK)   // 显示文件框，并且选择文件
                {
                    string fName = saveDataSend.FileName;   // 获取文件名
                                                            // 参数1：写入文件的文件名；参数2：写入文件的内容
                                                            // 字符串"Hello"是文件保存的内容，可以根据需求进行修改
                    System.IO.File.WriteAllText(fName, tb.Text);   // 向文件中写入内容

                    MessageBox.Show("保存成功！", "提示");
                }
                */
            }
            catch
            {
                MessageBox.Show("错误！！！");
            }
        }

        private void btndelete_Point_Click(object sender, EventArgs e)
        {
            var frm = new delete_Piont();
            frm.ShowDialog();
        }
    }
}
