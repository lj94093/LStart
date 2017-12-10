using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IWshRuntimeLibrary;

namespace LStart
{
    /// <summary>
    /// EditWindow.xaml 的交互逻辑
    /// </summary>
    public partial class EditWindow : Window
    {
        private int clickedIndex = -1;
        public EditWindow()
        {
            InitializeComponent();
            this.SubmitButton.Click += AddButton_Click; ;
        }
        public EditWindow(int selctedIndex)
        {
            InitializeComponent();
            clickedIndex = selctedIndex;
            this.SubmitButton.Click += EditButton_Click; ;
        }

        #region 确定按钮
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            //            this.DialogResult = true;
            var shortcut = new Shortcut(nameBox.Text, pathBox.Text, parameterBox.Text);
            if (adminBox.IsChecked == true) shortcut.isAdmin = true;
            UserConfig.userGroups[UserConfig.selectedGroup].shortcuts[clickedIndex] = shortcut;
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //            this.DialogResult = true;
            var shortcut = new Shortcut(nameBox.Text, pathBox.Text, parameterBox.Text);
            if (adminBox.IsChecked == true) shortcut.isAdmin = true;

            UserConfig.userGroups[UserConfig.selectedGroup].shortcuts.Add(shortcut);
            this.Close();
        }


        #endregion


        #region 标题事件
        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TitlePanel_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        #endregion


        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void EditWindow_OnDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length != 1)
            {
                MessageBox.Show(this, "只接受一个文件", "提醒");
                return;
            }
            for (int i = 0; i < files.Length; i++)
            {
                var fileInfo = new FileInfo(files[i]);
                var name = fileInfo.Name.Replace(fileInfo.Extension, "");
                String path;
                Console.WriteLine(name);
                if (fileInfo.Extension.Equals(".lnk"))
                {
                    WshShell shell = new WshShell();
                    IWshShortcut iWshShortcut = (IWshShortcut)shell.CreateShortcut(fileInfo.FullName);
                    path = iWshShortcut.TargetPath;
                }
                else path = fileInfo.FullName;
                this.nameBox.Text= name;
                this.pathBox.Text = path;
            }
        }
    }
}
