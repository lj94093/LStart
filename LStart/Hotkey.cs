﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using MessageBox = System.Windows.MessageBox;

namespace LStart
{
    [Serializable]
    public class Hotkey
    {
        /// <summary>
        /// 如果函数执行成功，返回值不为0。
        /// 如果函数执行失败，返回值为0。要得到扩展错误信息，调用GetLastError。.NET方法:Marshal.GetLastWin32Error()
        /// </summary>
        /// <param name="hWnd">要定义热键的窗口的句柄</param>
        /// <param name="id">定义热键ID（不能与其它ID重复） </param>
        /// <param name="fsModifiers">标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效</param>
        /// <param name="vk">定义热键的内容,WinForm中可以使用Keys枚举转换，
        /// WPF中Key枚举是不正确的,应该使用System.Windows.Forms.Keys枚举，或者自定义正确的枚举或int常量</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
            IntPtr hWnd,
            int id,
            KeyModifiers fsModifiers,
            int vk
        );

        /// <summary>
        /// 取消注册热键
        /// </summary>
        /// <param name="hWnd">要取消热键的窗口的句柄</param>
        /// <param name="id">要取消热键的ID</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
            IntPtr hWnd,
            int id
        );

        /// <summary>
        /// 向全局原子表添加一个字符串，并返回这个字符串的唯一标识符,成功则返回值为新创建的原子ID,失败返回0
        /// </summary>
        /// <param name="lpString"></param>
        /// <returns></returns>
        [DllImport("kernel32", SetLastError = true)]
        public static extern short GlobalAddAtom(string lpString);

        [DllImport("kernel32", SetLastError = true)]
        public static extern short GlobalDeleteAtom(short nAtom);

        /// <summary>
        /// 定义了辅助键的名称（将数字转变为字符以便于记忆，也可去除此枚举而直接使用数值）
        /// </summary>
        [ComVisible(true)]
        [Flags]
        [TypeConverter(typeof(KeysConverter))]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }
        /// <summary>
        /// 非修饰键
        /// </summary>
        public Keys userKey { get; set; }
        /// <summary>
        /// 是否启用快捷键
        /// </summary>
        public bool isHotKey { get; set; }
        /// <summary>
        /// 修饰键
        /// </summary>
        public KeyModifiers keyModifiers { get; set; }

        public override String ToString()
        {
            StringBuilder result=new StringBuilder();
            if ((this.keyModifiers & KeyModifiers.Alt)!=0) result.Append("Alt+");
            if ((this.keyModifiers & KeyModifiers.Shift)!=0) result.Append("Shift+");
            if ((this.keyModifiers & KeyModifiers.Ctrl)!=0) result.Append("Ctrl+");
            result.Append(this.userKey);
            return result.ToString();
        }
    }
}
