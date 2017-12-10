using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace LStart.Config
{
    [Serializable]
    public class WindowConfig
    {
        public double width { get; set; }
        public double height { get; set; }
        public double left { get; set; }
        public double top { get; set; }
        /// <summary>
        /// 导入文件夹时的初始位置
        /// </summary>
        public String openFolderPath { get; set; }
        /// <summary>
        /// 左右栏分割线位置
        /// </summary>
        public double leftListWidth { get; set; }
        /// <summary>
        /// 是否开机启动
        /// </summary>
        public bool isStart { get; set; }
        /// <summary>
        /// 是否窗口置顶
        /// </summary>
        public bool isTopMost { get; set; }
        /// <summary>
        /// 激活、隐藏窗口快捷键
        /// </summary>
        public Hotkey hotkey { get; set; }
        /// <summary>
        /// 图标大小
        /// </summary>
        public String IconWeight { get; set; }
        /// <summary>
        /// 是否使用相对地址
        /// </summary>
        public bool isRelativePath { get; set; }

        public WindowConfig(double _width,double _height,double _left,double _top)
        {
            this.width = _width;
            this.height = _height;
            this.left = _left;
            this.top = _top;
        }
        public static string Absolute2Relative(string path)
        {
            var currentDirectory = System.Windows.Forms.Application.StartupPath;
            if (currentDirectory[currentDirectory.Length - 1] == '\\') currentDirectory = currentDirectory.Substring(0, currentDirectory.Length - 1);
            return path.Replace(currentDirectory, "%root%");
        }
        public static string Relative2Absolute(string path)
        {
            var currentDirectory = System.Windows.Forms.Application.StartupPath;
            if (currentDirectory[currentDirectory.Length - 1] == '\\') currentDirectory = currentDirectory.Substring(0, currentDirectory.Length - 1);
            return path.Replace("%root%", currentDirectory);
        }
    }
}
