using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// RightList.xaml 的交互逻辑
    /// </summary>
    public partial class RightList : ListView
    {
        private ContextMenu emptyMenu;
        public RightList()
        {
            InitializeComponent();
            //空白区域右键菜单
            this.emptyMenu = new ContextMenu();
            var addItem = new MenuItem();
            addItem.Header = "新建启动项";
            addItem.Click += AddItem_Click; ;
            emptyMenu.Items.Add(addItem);
            this.MouseRightButtonDown += RightList_MouseRightButtonDown;
            

        }

        private void RightList_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.emptyMenu.IsOpen = true;
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            var editWindow=new EditWindow();
            editWindow.ShowDialog();
        }


        /// <summary>
        /// 单击打开应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                Application.Current.MainWindow.Hide();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }
        }
        /// <summary>
        /// 拖拽Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewItem_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var box = sender as Border;
                DataObject dataObject = new DataObject(typeof(Shortcut), box.DataContext);
                DragDrop.DoDragDrop(box, dataObject, DragDropEffects.Move);
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

        private void Item_OnDrop(object sender, DragEventArgs e)
        {
            var shortcut = e.Data.GetData(typeof(Shortcut)) as Shortcut;
            var shortcuts = this.ItemsSource as ObservableCollection<Shortcut>;
            

            if (shortcut != null)
            {
                var index = shortcuts.IndexOf(shortcut);

                var currentShortcut = (sender as Border).DataContext as Shortcut;

                shortcuts.Move(index,shortcuts.IndexOf(currentShortcut));
            }
        }
    }
}
