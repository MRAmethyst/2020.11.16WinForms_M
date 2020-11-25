using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Drawing;

namespace _2020._11._16WinForms_M
{
    public static class Save_as_Text
    {
        /// <summary>
        /// 将DataTable里面的内容写入txt文件并保存
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <returns></returns>
        public static void dt_Save_txt(DataTable dt)
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

                if (i < dt.Rows.Count - 1)
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

        /// <summary>
        /// 将List里面的内容写入txt文件并保存
        /// </summary>
        /// <param dirs>文件路径
        /// <param filename>文件名，建议".txt"
        /// <param List<string>>数据链表</param>
        /// <returns></returns>
        public static void List_Save_txt(string dirs, string filename, List<string> list)
        {
            DirectoryInfo di = new DirectoryInfo(dirs);
            FileInfo fi = new FileInfo(dirs + filename);
            if (fi.Exists) fi.Delete();
            StreamWriter swList = File.CreateText(dirs + filename);
            foreach (string a in list)
            {
                swList.WriteLine(a);
            }
            swList.Close();
        }

        public static void SayHello()
        {
            MessageBox.Show("Hello!", "提示", MessageBoxButtons.OK);
        }
    }
}
