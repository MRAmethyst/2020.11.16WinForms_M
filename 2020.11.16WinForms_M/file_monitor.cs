using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020._11._16WinForms_M
{
    /*
    public class file_monitor
    {
        /// <summary>
        /// 文件监控类，用于监控指定目录下文件以及文件夹的变化
        /// </summary>
        public class FileWatcher
        {
            private FileSystemWatcher _watcher = null;
            private string _path = string.Empty;
            private string _filter = string.Empty;
            private bool _isWatch = false;
            private CustomQueue<FileChangeInformation> _queue = null;

            /// <summary>
            /// 监控是否正在运行
            /// </summary>
            public bool IsWatch
            {
                get
                {
                    return _isWatch;
                }
            }

            /// <summary>
            /// 文件变更信息队列
            /// </summary>
            public CustomQueue<FileChangeInformation> FileChangeQueue
            {
                get
                {
                    return _queue;
                }
            }

            /// <summary>
            /// 初始化FileWatcher类
            /// </summary>
            /// <param name="path">监控路径</param>
            public FileWatcher(string path)
            {
                _path = path;
                _queue = new CustomQueue<FileChangeInformation>();
            }
            /// <summary>
            /// 初始化FileWatcher类，并指定是否持久化文件变更消息
            /// </summary>
            /// <param name="path">监控路径</param>
            /// <param name="isPersistence">是否持久化变更消息</param>
            /// <param name="persistenceFilePath">持久化保存路径</param>
            public FileWatcher(string path, bool isPersistence, string persistenceFilePath)
            {
                _path = path;
                _queue = new CustomQueue<FileChangeInformation>(isPersistence, persistenceFilePath);
            }

            /// <summary>
            /// 初始化FileWatcher类，并指定是否监控指定类型文件
            /// </summary>
            /// <param name="path">监控路径</param>
            /// <param name="filter">指定类型文件，格式如:*.txt,*.doc,*.rar</param>
            public FileWatcher(string path, string filter)
            {
                _path = path;
                _filter = filter;
                _queue = new CustomQueue<FileChangeInformation>();
            }

            /// <summary>
            /// 初始化FileWatcher类，并指定是否监控指定类型文件，是否持久化文件变更消息
            /// </summary>
            /// <param name="path">监控路径</param>
            /// <param name="filter">指定类型文件，格式如:*.txt,*.doc,*.rar</param>
            /// <param name="isPersistence">是否持久化变更消息</param>
            /// <param name="persistenceFilePath">持久化保存路径</param>
            public FileWatcher(string path, string filter, bool isPersistence, string persistenceFilePath)
            {
                _path = path;
                _filter = filter;
                _queue = new CustomQueue<FileChangeInformation>(isPersistence, persistenceFilePath);
            }

            /// <summary>
            /// 打开文件监听器
            /// </summary>
            public void Open()
            {
                if (!Directory.Exists(_path))
                {
                    Directory.CreateDirectory(_path);
                }

                if (string.IsNullOrEmpty(_filter))
                {
                    _watcher = new FileSystemWatcher(_path);
                }
                else
                {
                    _watcher = new FileSystemWatcher(_path, _filter);
                }
                //注册监听事件
                _watcher.Created += new FileSystemEventHandler(OnProcess);
                _watcher.Changed += new FileSystemEventHandler(OnProcess);
                _watcher.Deleted += new FileSystemEventHandler(OnProcess);
                _watcher.Renamed += new RenamedEventHandler(OnFileRenamed);
                _watcher.IncludeSubdirectories = true;
                _watcher.EnableRaisingEvents = true;
                _isWatch = true;
            }

            /// <summary>
            /// 关闭监听器
            /// </summary>
            public void Close()
            {
                _isWatch = false;
                _watcher.Created -= new FileSystemEventHandler(OnProcess);
                _watcher.Changed -= new FileSystemEventHandler(OnProcess);
                _watcher.Deleted -= new FileSystemEventHandler(OnProcess);
                _watcher.Renamed -= new RenamedEventHandler(OnFileRenamed);
                _watcher.EnableRaisingEvents = false;
                _watcher = null;
            }

            /// <summary>
            /// 获取一条文件变更消息
            /// </summary>
            /// <returns></returns>
            public FileChangeInformation Get()
            {
                FileChangeInformation info = null;
                if (_queue.Count > 0)
                {
                    lock (_queue)
                    {
                        info = _queue.Dequeue();
                    }
                }
                return info;
            }

            /// <summary>
            /// 监听事件触发的方法
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void OnProcess(object sender, FileSystemEventArgs e)
            {
                try
                {
                    FileChangeType changeType = FileChangeType.Unknow;
                    if (e.ChangeType == WatcherChangeTypes.Created)
                    {
                        if (File.GetAttributes(e.FullPath) == FileAttributes.Directory)
                        {
                            changeType = FileChangeType.NewFolder;
                        }
                        else
                        {
                            changeType = FileChangeType.NewFile;
                        }
                    }
                    else if (e.ChangeType == WatcherChangeTypes.Changed)
                    {
                        //部分文件创建时同样触发文件变化事件，此时记录变化操作没有意义
                        //如果
                        if (_queue.SelectAll(
                            delegate (FileChangeInformation fcm)
                            {
                                return fcm.NewPath == e.FullPath && fcm.ChangeType == FileChangeType.Change;
                            }).Count<FileChangeInformation>() > 0)
                        {
                            return;
                        }

                        //文件夹的变化，只针对创建，重命名和删除动作，修改不做任何操作。
                        //因为文件夹下任何变化同样会触发文件的修改操作，没有任何意义.
                        if (File.GetAttributes(e.FullPath) == FileAttributes.Directory)
                        {
                            return;
                        }

                        changeType = FileChangeType.Change;
                    }
                    else if (e.ChangeType == WatcherChangeTypes.Deleted)
                    {
                        changeType = FileChangeType.Delete;
                    }

                    //创建消息，并压入队列中
                    FileChangeInformation info = new FileChangeInformation(Guid.NewGuid().ToString(), changeType, e.FullPath, e.FullPath, e.Name, e.Name);
                    _queue.Enqueue(info);
                }
                catch
                {
                    Close();
                }
            }

            /// <summary>
            /// 文件或目录重命名时触发的事件
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void OnFileRenamed(object sender, RenamedEventArgs e)
            {
                try
                {
                    //创建消息，并压入队列中
                    FileChangeInformation info = new FileChangeInformation(Guid.NewGuid().ToString(), FileChangeType.Rename, e.OldFullPath, e.FullPath, e.OldName, e.Name);
                    _queue.Enqueue(info);
                }
                catch
                {
                    Close();
                }
            }
        }


        public static void file_monitor_init(string path, string filter)
        {

        }

        //  监视文件
        public class FileListenerServer
        {
            private FileSystemWatcher _watcher;  //  定义FileSystemWatcher类型的变量
            public FileListenerServer(string path)
            {

                try
                {
                    this._watcher = new FileSystemWatcher();  //  新建FileSystemWatcher类型的变量_watcher
                    _watcher.Path = path;  //  要监视的路径
                    _watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size | NotifyFilters.DirectoryName;
                    _watcher.IncludeSubdirectories = true;
                    _watcher.Created += new FileSystemEventHandler(FileWatcher_Created);  //  创建
                    _watcher.Changed += new FileSystemEventHandler(FileWatcher_Changed);  //  变更
                    _watcher.Deleted += new FileSystemEventHandler(FileWatcher_Deleted);  //  删除
                    _watcher.Renamed += new RenamedEventHandler(FileWatcher_Renamed);     //  重命名

                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error:" + ex.Message);
                    MessageBox.Show("错误");
                }
            }

            //  启动监控
            public void Start()
            {

                this._watcher.EnableRaisingEvents = true;
                Console.WriteLine("文件监控已经启动...");

            }

            //  结束监控
            public void Stop()
            {

                this._watcher.EnableRaisingEvents = false;
                this._watcher.Dispose();
                this._watcher = null;

            }

            //  监视新创建的文件
            protected void FileWatcher_Created(object sender, FileSystemEventArgs e)
            {
                Console.WriteLine("新增:" + e.ChangeType + ";" + e.FullPath + ";" + e.Name);

            }

            //  监视文件类型、路径、名称变更
            protected void FileWatcher_Changed(object sender, FileSystemEventArgs e)
            {
                Console.WriteLine("变更:" + e.ChangeType + ";" + e.FullPath + ";" + e.Name);
            }

            //  监视文件是否被删除
            protected void FileWatcher_Deleted(object sender, FileSystemEventArgs e)
            {
                Console.WriteLine("删除:" + e.ChangeType + ";" + e.FullPath + ";" + e.Name);
            }

            //  监视文件是否被重命名
            protected void FileWatcher_Renamed(object sender, RenamedEventArgs e)
            {

                Console.WriteLine("重命名: OldPath:{0} NewPath:{1} OldFileName{2} NewFileName:{3}", e.OldFullPath, e.FullPath, e.OldName, e.Name);

            }

        }

       
    }
    */
}
