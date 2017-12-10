using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using TextBox = System.Windows.Controls.TextBox;
using System.Reflection;

namespace LStart
{
    /// <summary>
    /// SettingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SettingWindow : Window
    {
        public SettingWindow()
        {
            InitializeComponent();
            this.DataContext = UserConfig.windowConfig;
            this.CloseButton.Click += CloseButton_Click;
            this.TitlePanel.MouseDown += TitlePanel_MouseDown;
            this.HotKeyBox.Text = UserConfig.windowConfig.hotkey.ToString();
        }

        private void TitlePanel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void HotKeyBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            var box = sender as TextBox;
            if (e.Key == Key.Escape)
            {
                box.Clear();
                return;
            }

            Console.WriteLine("system:" + e.SystemKey);
            Console.WriteLine("key:" + e.Key);
            Console.WriteLine();
            if (e.Key == Key.System) //只按了alt键
            {
                if (e.SystemKey >= Key.D0 && e.SystemKey <= Key.Z || e.SystemKey >= Key.F1 && e.SystemKey <= Key.F12)
                {
                    box.Text = "Alt+" + e.SystemKey;
                    UserConfig.windowConfig.hotkey.keyModifiers=Hotkey.KeyModifiers.Alt;
                    UserConfig.windowConfig.hotkey.userKey = (Keys)KeyInterop.VirtualKeyFromKey(e.SystemKey);
                    var mainWindow = this.Owner as MainWindow;
                    mainWindow.MainWindow_RegisterHotKey();
                }
            }
            else
            {
                //没按alt或alt和其他的组合
                if (e.Key >= Key.D0 && e.Key <= Key.Z || e.Key >= Key.F1 && e.Key <= Key.F12)
                {
                    box.Clear();
                    if ((Keyboard.Modifiers & ModifierKeys.Alt) != 0)
                    {
                        box.Text += "Alt+";
                        UserConfig.windowConfig.hotkey.keyModifiers |= Hotkey.KeyModifiers.Alt;
                    }
                    if ((Keyboard.Modifiers & ModifierKeys.Shift) != 0)
                    {
                        box.Text += "Shift+";
                        UserConfig.windowConfig.hotkey.keyModifiers |= Hotkey.KeyModifiers.Shift;
                    }
                    if ((Keyboard.Modifiers & ModifierKeys.Control) != 0)
                    {
                        box.Text += "Ctrl+";
                        UserConfig.windowConfig.hotkey.keyModifiers |= Hotkey.KeyModifiers.Ctrl;
                    }
                    if (box.Text.Equals(""))
                    {
                        if (e.Key >= Key.F1 && e.Key <= Key.F12) //如果为空，则该单键必须是f1~f12
                        {
                            box.Text += e.Key;
                            UserConfig.windowConfig.hotkey.userKey = (Keys)KeyInterop.VirtualKeyFromKey(e.Key);
                            var mainWindow = this.Owner as MainWindow;
                            mainWindow.MainWindow_RegisterHotKey();
                        }
                    }
                    else
                    {
                        box.Text += e.Key;
                        UserConfig.windowConfig.hotkey.userKey = (Keys)KeyInterop.VirtualKeyFromKey(e.Key);
                        var mainWindow = this.Owner as MainWindow;
                        mainWindow.MainWindow_RegisterHotKey();
                    }
                }
            }
        }
        #region 设置程序开机自动运行(+注册表项)
       
      
        private void StartBox_OnChecked(object sender, RoutedEventArgs e)
        {
            RegistryKey rgkRun = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rgkRun == null)
            {
                rgkRun = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            }
            rgkRun.SetValue("LStart", System.Windows.Forms.Application.ExecutablePath);
            rgkRun.Close();
        }

        private void StartBox_OnUnchecked(object sender, RoutedEventArgs e)
        {
            RegistryKey rgkRun = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rgkRun == null) return;
            rgkRun.DeleteValue("LStart");
        }
        #endregion

        private void HotkeyToggle_OnChecked(object sender, RoutedEventArgs e)
        {
            var mainWindow = this.Owner as MainWindow;
            mainWindow.MainWindow_RegisterHotKey();
        }

        private void HotkeyToggle_OnUnchecked(object sender, RoutedEventArgs e)
        {
            var mainWindow = this.Owner as MainWindow;
            mainWindow.MainWindow_UnregisterHotKey();
        }

        private void IsRelativeBox_Checked(object sender, RoutedEventArgs e)
        {
            var currentDirectory = System.Windows.Forms.Application.StartupPath;
            if (currentDirectory[currentDirectory.Length - 1] == '\\') currentDirectory = currentDirectory.Substring(0, currentDirectory.Length - 1);
            for (int i = 0; i < UserConfig.userGroups.Count; i++)
            {
                var userGroup = UserConfig.userGroups[i];
                for(int j = 0; j < userGroup.shortcuts.Count; j++)
                {
                    var shortcut = userGroup.shortcuts[j];
                    Console.WriteLine(shortcut.path);
                    Console.WriteLine(currentDirectory);
                    if (shortcut.path[0]== currentDirectory[0])
                    {
                        //如果在同一盘符

                        if (shortcut.path.IndexOf(currentDirectory) == 0)
                        {
                            //如果在当前目录下
                            shortcut.path = Config.WindowConfig.Absolute2Relative(shortcut.path);
                        }
                    }
                    
                    
                }
                
            }
            Console.WriteLine(currentDirectory);
        }
        private void IsRelativeBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var currentDirectory = System.Windows.Forms.Application.StartupPath;
            if (currentDirectory[currentDirectory.Length - 1] == '\\') currentDirectory = currentDirectory.Substring(0, currentDirectory.Length - 1);
            for (int i = 0; i < UserConfig.userGroups.Count; i++)
            {
                var userGroup = UserConfig.userGroups[i];
                for (int j = 0; j < userGroup.shortcuts.Count; j++)
                {
                    var shortcut = userGroup.shortcuts[j];
                    
                    shortcut.path = Config.WindowConfig.Relative2Absolute(shortcut.path);
                }
            }
        }
    }
}
