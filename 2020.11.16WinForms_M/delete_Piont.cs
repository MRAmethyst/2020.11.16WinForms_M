using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace _2020._11._16WinForms_M
{
    public partial class delete_Piont : Form
    {
        public delete_Piont()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 获取文件夹中.txt文件的名字
        /// </summary>
        /// <param name="dirs"></param>
        List<string> filenames = new List<string>();

        /*
        public void director(string dirs)
        {
            //绑定到指定的文件夹目录
            DirectoryInfo dir = new DirectoryInfo(dirs);
            //检索表示当前目录的文件和子目录
            FileSystemInfo[] fsinfos = dir.GetFileSystemInfos();
            //遍历检索的文件夹和子目录的.txt文件名
            foreach (FileSystemInfo fsinfo in dir.GetFiles("*.txt"))
            {
                //判断是否为空文件夹　　
                if (fsinfo is DirectoryInfo)
                {
                    //递归调用
                    director(fsinfo.FullName);
                }
                else
                {
                    Console.WriteLine(fsinfo.FullName);
                    //将得到的文件全路径放入到集合中
                    filenames.Add(fsinfo.FullName);
                }
            }
        }
        */

        /// <summary>
        /// 清空文件夹
        /// </summary>
        /// <param name="dirs">文件夹路径</param>
        public void DeleteFolder(string dirs)
        {
            foreach (string d in Directory.GetFileSystemEntries(dirs))
            {
                if (File.Exists(d))
                {
                    FileInfo fi = new FileInfo(d);
                    if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        fi.Attributes = FileAttributes.Normal;
                    File.Delete(d);//直接删除其中的文件 
                }
                else
                {
                    DirectoryInfo d1 = new DirectoryInfo(d);
                    if (d1.GetFiles().Length != 0)
                    {
                        DeleteFolder(d1.FullName);////递归删除子文件夹
                    }
                    Directory.Delete(d);
                }
            }
        }

        /// <summary>
        /// 删除文件夹中的txt文件
        /// </summary>
        /// <param name="dirs">文件夹路径</param>
        /// <param pattern="*.txt">删除文件类型</param>
        public void DeleteFolder_txt(string dirs, string pattern)
        {
            string[] strFileName = Directory.GetFiles(dirs, pattern);
            foreach (var item in strFileName)
            {
                File.Delete(item);
                Console.WriteLine("{0}文件被删除了", item);
            }
            Console.ReadLine();
        }

        private void btnyes_Click(object sender, EventArgs e)
        {
            int count = 0;  //  定义文件个数变量count

            try
            {
                //Folder_Manipulate.Get_txt_Names("c:\\users\\amethyst\\desktop\\11.16", filenames);  //  调用函数
                //count = filenames.Count;
                //MessageBox.Show("共有" + count.ToString() + "个txt文件");
            }
            catch
            {
                MessageBox.Show("错误");
                //break;
            }

            /*
            while (true)
            {
                //  获得文件数量
                try
                {
                    director("C:\\Users\\Amethyst\\Desktop\\11.16");  //  调用函数
                    count = filenames.Count;
                    MessageBox.Show("共有" + count.ToString() + "个txt文件");

                    if (count < 2)
                    {
                        System.Threading.Thread.Sleep(500);
                    }
                    else
                    {
                        break;
                    }

                }
                catch
                {
                    MessageBox.Show("错误");
                    break;
                }
            }
            */

            //string path = "C:\\Users\\Amethyst\\Desktop\\11.16";
            //string pattern = "*.txt";
            //string[] strFileName = Directory.GetFiles(path, pattern);
            //foreach (var item in strFileName)
            //{
            //    File.Delete(item);
            //    Console.WriteLine("{0}文件被删除了", item);
            //}
            //Console.ReadLine();

            List<string> point_num = new List<string>();
            if (chkpoint1.Checked)
            {
                point_num.Add(chkpoint1.Text + ",");
            }
            if (chkpoint2.Checked)
            {
                point_num.Add(chkpoint2.Text + ",");
            }
            if (chkpoint3.Checked)
            {
                point_num.Add(chkpoint3.Text + ",");
            }
            if (chkpoint4.Checked)
            {
                point_num.Add(chkpoint4.Text + ",");
            }

            Save_as_Text.List_Save_txt("C:\\Users\\Amethyst\\Desktop\\11.17\\", "Delete_Point.txt", point_num);

            //MessageBox.Show("共有" + point_num.Count.ToString() + "个txt文件");
        }
    }
}
