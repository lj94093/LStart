using System;
using System.Collections.Generic;
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
    /// LeftList.xaml 的交互逻辑
    /// </summary>
    public partial class LeftList : ListBox
    {
        private ContextMenu itemMenu;
        private ContextMenu emptyMenu;
        private TextBox renameBox=new TextBox();
        public LeftList()
        {
            InitializeComponent();

            //空白区域右键菜单
            this.emptyMenu = new ContextMenu();
            var addItem = new MenuItem();
            addItem.Header = "新建分组";
            addItem.Click += AddItem_Click;
            emptyMenu.Items.Add(addItem);
            this.MouseRightButtonDown += LeftList_MouseRightButtonDown;
            this.MouseLeftButtonDown += LeftList_MouseLeftButtonDown;
            this.Drop += LeftList_Drop;
            //初始选中第0组
            this.SelectedIndex = 0;
        }
        /// <summary>
        /// 使重命名框失去焦点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftList_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Focus();
        }



        /// <summary>
        /// 添加新分组功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            UserConfig.userGroups.Add(new UserGroup("新分组"));
//            
//            var addedIndex=this.Items.Count-1;
//            ListBoxItem item = (ListBoxItem) (this.ItemContainerGenerator.ContainerFromIndex(addedIndex-1));
////            Console.WriteLine(item);
//            DependencyObject tmp=item;
//            while (!(tmp is TextBox))
//            {
//                tmp= VisualTreeHelper.GetChild(tmp, 0);
//            }
//            var box = tmp as TextBox;
//            box.Focusable = true;
//            box.Focus();
//            box.SelectAll();
//            box.Background = Brushes.White;
//            box.Foreground = Brushes.Black;

        }
        /// <summary>
        /// 删除分组功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            var group = menuItem.DataContext as UserGroup;
            var index=UserConfig.userGroups.IndexOf(group);
            if (UserConfig.userGroups.Count == 1) return;
            if (index == this.SelectedIndex&& index == UserConfig.userGroups.Count - 1) this.SelectedIndex -= 1;
            UserConfig.userGroups.Remove(group);
            this.SelectedIndex = index;
        }
        /// <summary>
        /// 打开右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LeftList_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            emptyMenu.IsOpen = true;
        }

        #region 重命名功能 
        private void RenameItem_OnClick(object sender, RoutedEventArgs e)
        {
            var box = ContextMenuService.GetPlacementTarget(
                LogicalTreeHelper.GetParent(sender as MenuItem)) as TextBox;
            box.Focusable = true;
            box.Focus();
            box.SelectAll();

            box.Background = Brushes.White;
            box.Foreground = Brushes.Black;
        }
        

        private void TextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("aaaaaaaaaaaaa");
            if (e.Key != Key.Enter) return;
            //按下回车键
            var box = sender as TextBox;
            box.Focusable = false;
        }
        private void TextBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            var box = sender as TextBox;
            box.Focusable = false;
            box.Background = null;
            box.Foreground = Brushes.White;
        }
        #endregion

        private void TextBox_OnLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var box = sender as TextBox;
            box.Focusable = false;
            box.Background = null;
            box.Foreground = Brushes.White;
        }

        #region 拖动事件
        private void LeftList_Drop(object sender, DragEventArgs e)
        {
            var group = e.Data.GetData(typeof(UserGroup)) as UserGroup;
            if (group != null)
            {
                //拖动组
                var index = UserConfig.userGroups.IndexOf(group);
                UserConfig.userGroups.Move(index, UserConfig.userGroups.Count - 1);
                this.SelectedIndex = index;
            }
            
        }
        private void Item_OnDrop(object sender, DragEventArgs e)
        {
            var currentGroup = (sender as TextBox).DataContext as UserGroup;
            var shortcut = e.Data.GetData(typeof(Shortcut)) as Shortcut;
            var group = e.Data.GetData(typeof(UserGroup)) as UserGroup;
            e.Handled = true;
            if (group != null)
            {
                //拖动组
                var currentIndex = UserConfig.userGroups.IndexOf(currentGroup);
                UserConfig.userGroups.Remove(group);
                UserConfig.userGroups.Insert(currentIndex, group);
                this.SelectedIndex = currentIndex;
            }
            if (shortcut != null)
            {
                //拖动Item
                UserConfig.userGroups[UserConfig.selectedGroup].shortcuts.Remove(shortcut);
                currentGroup.shortcuts.Add(shortcut);

            }
            
        }

        private void Drag_OnMouseDown(object sender, MouseButtonEventArgs e)
        {

            var box = sender as Border;
            DataObject dataObject = new DataObject(typeof(UserGroup), box.DataContext);
            DragDrop.DoDragDrop(box, dataObject, DragDropEffects.Move);
            
        }

        private void Item_OnPreviewDragOver(object sender, DragEventArgs e)
        {
            var group = e.Data.GetData(typeof(UserGroup)) as UserGroup;
            var shortcut = e.Data.GetData(typeof(Shortcut)) as Shortcut;
            var box = sender as TextBox;
            if (group != null)
            {
                if (group != (box.DataContext as UserGroup))
                {
                    e.Handled = true;
                }
            }
            if (shortcut != null)
            {
                var currentGroup = box.DataContext as UserGroup;
                if (UserConfig.userGroups.IndexOf(currentGroup) != UserConfig.selectedGroup)
                {
                    //如果不是当前选中的组
                    e.Handled = true;
                    
                }
            }
            
            
            
        }


        #endregion
    }
}
