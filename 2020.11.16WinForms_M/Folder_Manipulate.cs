using System;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._11._16WinForms_M
{
    public static class Folder_Manipulate
    {
        /// <summary>
        /// 删除文件夹中的txt文件
        /// </summary>
        /// <param name="dirs">文件夹路径</param>
        /// <param pattern="*.txt">删除文件类型</param>
        public static void DeleteFolder_txt(string dirs, string pattern)
        {
            string[] strFileName = Directory.GetFiles(dirs, pattern);
            foreach (var item in strFileName)
            {
                File.Delete(item);
                Console.WriteLine("{0}文件被删除了", item);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// 获取文件夹中.txt文件的名字
        /// </summary>
        /// <param name="dirs"></param>
        /// 要先定义一个全局变量  List<string> filenames = new List<string>();
        public static void Get_txt_Names(string dirs, List<string> filenames)
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
                    Get_txt_Names(fsinfo.FullName, filenames);  // 这一段还要测试一下
                }
                else
                {
                    Console.WriteLine(fsinfo.FullName);
                    //将得到的文件全路径放入到集合中
                    filenames.Add(fsinfo.FullName);
                }
            }
        }
    }
}
