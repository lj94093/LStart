using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LStart.Controls
{
    /// <summary>
    /// PopupList.xaml 的交互逻辑
    /// </summary>
    public partial class PopupList : ListView
    {
        public PopupList()
        {
            InitializeComponent();
        }
        private void ListViewItem_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var shortcut = (sender as Border).DataContext as Shortcut;
            shortcut.startTimes++;
            try
            {
                var process = new Process();
                process.StartInfo.FileName = Config.WindowConfig.Relative2Absolute(shortcut.path);
                process.StartInfo.Arguments = shortcut.parameter;
                process.Start();
                (Application.Current.MainWindow as MainWindow).Popup.Visibility = Visibility.Collapsed;
                Application.Current.MainWindow.Hide();
                
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }
        }
        #region Item右键菜单
        /// <summary>
        /// 以管理员运行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AdminRun_OnClick(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            var shortcut = menuItem.DataContext as Shortcut;
            Console.WriteLine("aaaaaaaaa");
            if (shortcut == null) return;
            try
            {
                var process = new Process();
                process.StartInfo.FileName = Config.WindowConfig.Relative2Absolute(shortcut.path);
                process.StartInfo.Arguments = shortcut.parameter;
                process.StartInfo.Verb = "runas";
                process.Start();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }
        }
        /// <summary>
        /// 打开文件位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFolder_OnClick(object sender, RoutedEventArgs e)
        {
            var shortcut = (sender as MenuItem).DataContext as Shortcut;
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + Config.WindowConfig.Relative2Absolute(shortcut.path);
            System.Diagnostics.Process.Start(psi);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditItem_OnClick(object sender, RoutedEventArgs e)
        {

            var shortcut = (sender as MenuItem).DataContext as Shortcut;
            int index = UserConfig.userGroups[UserConfig.selectedGroup].shortcuts.IndexOf(shortcut);
            var editWindow = new EditWindow(index);
            editWindow.nameBox.Text = shortcut.name;
            editWindow.pathBox.Text = shortcut.path;
            editWindow.parameterBox.Text = shortcut.parameter;
            editWindow.adminBox.IsChecked = shortcut.isAdmin;
            editWindow.ShowDialog();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteItem_OnClick(object sender, RoutedEventArgs e)
        {
            var shortcut = (sender as MenuItem).DataContext as Shortcut;
            UserConfig.userGroups[UserConfig.selectedGroup].shortcuts.Remove(shortcut);
        }


        #endregion
    }
}
