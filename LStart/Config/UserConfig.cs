using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LStart.Config;

namespace LStart
{
    static class UserConfig
    {
        public static ObservableCollection<UserGroup> userGroups { get; set; }
        public static String filename;
        public static int selectedGroup = 0;
        public static WindowConfig windowConfig { get; set; }

        static UserConfig()
        {
            filename = System.AppDomain.CurrentDomain.BaseDirectory + "\\" + "data";
            userGroups = new ObservableCollection<UserGroup>();
        }

        public static void InitConfig()
        {
            //存在用户数据文件
            if (File.Exists(filename)) LoadConfig();
            else CreateConfig();
        }
        public static void LoadConfig()
        {
            Console.WriteLine("base:"+System.AppDomain.CurrentDomain.BaseDirectory);
            BinaryFormatter binFormat = new BinaryFormatter();//创建二进制序列化器
            var userDataStream = new FileStream(filename, FileMode.Open);
            try
            {
                userGroups = (ObservableCollection<UserGroup>)binFormat.Deserialize(userDataStream);
                windowConfig = (WindowConfig) binFormat.Deserialize(userDataStream);
//                var tmp = windowConfig;
                Console.WriteLine("加载用户数据成功:");
                foreach (var group in userGroups)
                {
                    Console.WriteLine(group.name);
                }
                userDataStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(null, "数据文件加载错误", "加载用户数据错误,将创建新的配置文件");
                CreateConfig();
                Console.WriteLine(e.StackTrace);
            }
        }

        public static void CreateConfig()
        {
            BinaryFormatter binFormat = new BinaryFormatter();//创建二进制序列化器
            var group = new UserGroup("新分组");
            var shortCut = new Shortcut("百度云",
                @"C:\Users\Administrator\AppData\Roaming\Baidu\BaiduNetdisk\BaiduNetdisk.exe",
                "");
            group.shortcuts.Add(shortCut);
            userGroups = new ObservableCollection<UserGroup>();
            userGroups.Add(group);
            userGroups.Add(new UserGroup("另一个新分组"));
            Stream fStream = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite);
            binFormat.Serialize(fStream, userGroups);
            windowConfig=new WindowConfig(350,500,1000,500);
            windowConfig.openFolderPath = Directory.GetCurrentDirectory();
            windowConfig.leftListWidth = 80;
            windowConfig.isStart = false;
            windowConfig.isTopMost = true;
            windowConfig.hotkey=new Hotkey();
            windowConfig.IconWeight = "大图标(32*32)";
            windowConfig.hotkey.keyModifiers = Hotkey.KeyModifiers.None;
            windowConfig.isRelativePath = false;
            binFormat.Serialize(fStream, windowConfig);
            Console.WriteLine("创建新配置文件成功");
            fStream.Close();
        }

        public static void UpdateConfig()
        {
            Stream fStream = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite);
            BinaryFormatter binFormat = new BinaryFormatter();//创建二进制序列化器
            Console.WriteLine("更新后的用户数据:");
            foreach (var group in userGroups)
            {
                Console.WriteLine(group.name);
            }
            binFormat.Serialize(fStream, userGroups);
            binFormat.Serialize(fStream, windowConfig);
            fStream.Close();
        }
    }
}
