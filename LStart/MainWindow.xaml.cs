using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IWshRuntimeLibrary;
using Application = System.Windows.Application;
using Binding = System.Windows.Data.Binding;
using ContextMenu = System.Windows.Controls.ContextMenu;
using DataFormats = System.Windows.DataFormats;
using DragEventArgs = System.Windows.DragEventArgs;
using MenuItem = System.Windows.Controls.MenuItem;
using Point = System.Windows.Point;
using TextBox = System.Windows.Controls.TextBox;
using System.Diagnostics;

namespace LStart
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private NotifyIcon notifyIcon;
        public MainWindow()
        {
            Console.WriteLine("aaaaaa");
            UserConfig.InitConfig();
            this.DataContext = UserConfig.windowConfig;
            InitializeComponent();
            this.MoreButton.Click += MoreButton_Click;
            this.CloseButton.Click += CloseButton_Click;
            this.SearchButton.Click += SearchButton_Click;
            this.TitlePanel.MouseLeftButtonDown += TitlePanel_MouseLeftButtonDown;
            //搜索事件
            this.PreviewKeyDown += MainWindow_KeyDown;
            Console.WriteLine("bbbbbb");

            //若数据不为空，则加载第一个分组
            if (UserConfig.userGroups.Count>0) this.RightList.ItemsSource = UserConfig.userGroups[0].shortcuts;
            //添加分组改变事件
            this.LeftList.SelectionChanged += LeftList_SelectionChanged;
            //拖拽事件
            this.Drop += MainWindow_Drop;

            
            //通知栏菜单
            var notifyMenu = new System.Windows.Forms.ContextMenu();
            var ExitItem = new System.Windows.Forms.MenuItem("退出");
            ExitItem.Click += ExitItem_Click; ;
            var openItem = new System.Windows.Forms.MenuItem("打开");
            openItem.Click += OpenItem_Click; ;
            notifyMenu.MenuItems.Add(openItem);
            notifyMenu.MenuItems.Add(ExitItem);

            notifyIcon =new NotifyIcon();
            notifyIcon.ContextMenu = notifyMenu;
            this.notifyIcon.BalloonTipText = "Hello, LStart"; //设置程序启动时显示的文本
            this.notifyIcon.Text = "LStart";//最小化到托盘时，鼠标点击时显示的文本
            this.notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.ExecutablePath);//程序图标
            this.notifyIcon.Visible = true;
            notifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;

            //全局快捷键
            this.Loaded += MainWindow_Loaded;
            this.Unloaded += MainWindow_Unloaded;

            this.IsVisibleChanged += MainWindow_IsVisibleChanged;
        }

        private void MainWindow_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.SearchBox.Visibility == Visibility.Visible)
            {
                this.SearchBox.Clear();
                this.SearchBox.Visibility = Visibility.Collapsed;
                
            }
            if (this.Popup.IsOpen) this.Popup.IsOpen = false;
            
            if(this.IsVisible)
            {
                this.Focus();
            }
            else
            {
                UserConfig.UpdateConfig();
            }
        }

        #region 全局快捷键
        public int id = 100;
        private void MainWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            MainWindow_UnregisterHotKey();
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //无论是否要注册快捷键，都指定回调函数
            IntPtr handle = new WindowInteropHelper(this).Handle;
            System.Windows.Interop.HwndSource source = System.Windows.Interop.HwndSource.FromHwnd(handle);
            source.AddHook(HotKeyHook);
            //注册快捷键
            if (!UserConfig.windowConfig.hotkey.isHotKey) return;
            while (Hotkey.RegisterHotKey(handle, id, UserConfig.windowConfig.hotkey.keyModifiers, (int)UserConfig.windowConfig.hotkey.userKey) == false)
            {
                id++;
            };
            Console.WriteLine("id:" + id);
            //获得消息源

        }
        private IntPtr HotKeyHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
            //热键处理过程
        {
            const int WM_HOTKEY = 0x0312;//如果m.Msg的值为0x0312那么表示用户按下了热键
            if (msg == WM_HOTKEY)
            {
                if (wParam.ToInt32() == id)
                {
                    if (this.Visibility == Visibility.Hidden)
                    {
                        this.Visibility = Visibility.Visible;
                        this.Activate();
                    }
                    else
                    {
                        this.Hide();
                    }
                }
            }
            return IntPtr.Zero;
        }

        public void MainWindow_RegisterHotKey()
        {
            if (!UserConfig.windowConfig.hotkey.isHotKey) return;
            IntPtr handle = new WindowInteropHelper(this).Handle;
            MainWindow_UnregisterHotKey();
            Hotkey.RegisterHotKey(handle, id, UserConfig.windowConfig.hotkey.keyModifiers,
                    (int) UserConfig.windowConfig.hotkey.userKey);
            Console.WriteLine("id:" + id);
        }

        public void MainWindow_UnregisterHotKey()
        {
            IntPtr handle = new WindowInteropHelper(this).Handle;
            bool r = Hotkey.UnregisterHotKey(handle, id);
        }

        #endregion

        #region 任务栏图标

        private void ExitItem_Click(object sender, EventArgs e)
        {
            UserConfig.UpdateConfig();
            this.notifyIcon.Dispose();
            Application.Current.Shutdown();
        }

        private void OpenItem_Click(object sender, EventArgs e)
        {
            this.Visibility = Visibility.Visible;
            this.Activate();
        }

        private void NotifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.Visibility = Visibility.Visible;
            this.Activate();
        }

        #endregion


        #region 搜索事件
        /// <summary>
        /// 直接在主窗口按键进行搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Console.WriteLine("aaaaaaaaaaaaaa");
            var tmp=Keyboard.FocusedElement as TextBox;
            if (tmp!=null) return;
            if (e.Key < Key.D0 || e.Key > Key.Z) return;
            Console.WriteLine("main windows key down");
            this.Popup.Height = this.Height - 32-2;//减2，保留边框
            this.Popup.Width = this.Width-2;
            this.SearchBox.Visibility = Visibility.Visible;
            
            this.SearchBox.Focus();
        }
        /// <summary>
        /// 点击搜索按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.SearchBox.Visibility == Visibility.Visible)
            {
                this.Popup.IsOpen = false;
                this.SearchBox.Clear();
                this.SearchBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.Popup.Height = this.Height - 32-2;
                this.Popup.Width = this.Width-2;
                this.SearchBox.Visibility = Visibility.Visible;
                this.SearchBox.Focus();
            }

        }
        /// <summary>
        /// 响应文本变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchBox.Text;
            if (searchText.Equals("")) return;
            var groups = UserConfig.userGroups;
            List<Shortcut> searchResult = new List<Shortcut>();
            for (int i = 0; i < groups.Count; i++)
            {
                var shortcuts = groups[i].shortcuts;
                for (int j = 0; j < shortcuts.Count; j++)
                {
                    if (shortcuts[j].name.ToLower().Contains(searchText))
                    {
                        searchResult.Add(shortcuts[j]);
                    }
                }
            }
            
            if (searchResult.Count!=0) searchResult=new List<Shortcut>(searchResult.OrderByDescending(tmp => tmp.startTimes));
            this.PopupList.SelectedIndex = -1;
            
            this.PopupList.ItemsSource = searchResult;
            
            if (!this.Popup.IsOpen) this.Popup.IsOpen = true;
            
        }
        /// <summary>
        /// 处理取消按键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (this.PopupList.Items.Count != 0)
            {
                if (KeyInterop.VirtualKeyFromKey(e.Key) == 40)//Down
                {
                    this.PopupList.SelectedIndex = (this.PopupList.SelectedIndex + 1) % this.PopupList.Items.Count;
                }
                if (KeyInterop.VirtualKeyFromKey(e.Key) == 38)//Up
                {
                    if (this.PopupList.SelectedIndex == -1) this.PopupList.SelectedIndex++;
                    this.PopupList.SelectedIndex = (this.PopupList.SelectedIndex - 1 + this.PopupList.Items.Count) % this.PopupList.Items.Count;
                }
                this.PopupList.ScrollIntoView(this.PopupList.SelectedItem);
                Console.WriteLine(this.PopupList.SelectedIndex);
            }
            if (e.Key == Key.Enter)
            {
                if (this.PopupList.SelectedIndex == -1) return;
                var shortcut = this.PopupList.SelectedItem as Shortcut;
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
                return;
            }
            if (e.Key == Key.Escape)
            {
                this.Popup.IsOpen = false;
                this.SearchBox.Clear();
                this.SearchBox.Visibility = Visibility.Collapsed;
                return;
            }

        }


        #endregion


        #region 标题事件

        private void MoreButton_Click(object sender, RoutedEventArgs e)
        {
            var moreMenu=new ContextMenu();
            var setItem=new MenuItem();
            setItem.Header = "设置";
            setItem.Click += SetItem_Click;
            var groupImport=new MenuItem();
            groupImport.Header = "批量导入";
            groupImport.Click += GroupImport_Click;
            moreMenu.Items.Add(setItem);
            moreMenu.Items.Add(groupImport);
            moreMenu.IsOpen = true;

        }

        private void SetItem_Click(object sender, RoutedEventArgs e)
        {
            var settingWindow=new SettingWindow();
            settingWindow.Owner = this;
            settingWindow.Show();
        }

        private void GroupImport_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(UserConfig.windowConfig.openFolderPath!=null) fbd.SelectedPath=UserConfig.windowConfig.openFolderPath;
            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            UserConfig.windowConfig.openFolderPath = fbd.SelectedPath;
            DirectoryInfo folderInfo = new DirectoryInfo(fbd.SelectedPath);
            var files = folderInfo.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                if (!files[i].Extension.Equals(".exe") && !files[i].Extension.Equals(".lnk")) continue;
                AddFromFile(files[i]);
            }
            var directories = folderInfo.GetDirectories();
            for (int i = 0; i < directories.Length; i++)
            {
                var folderFiles = directories[i].GetFiles();
                for (int j = 0; j < folderFiles.Length; j++)
                {
                    if (!folderFiles[j].Extension.Equals(".exe") && !folderFiles[j].Extension.Equals(".lnk")) continue;
                    AddFromFile(folderFiles[j]);
                }
            }
        }

        private void TitlePanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.Popup.IsOpen)
            {
                this.Popup.IsOpen = false;
                this.SearchBox.Clear();
                this.SearchBox.Visibility = Visibility.Collapsed;
            }
            this.DragMove();


        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }


        #endregion

        #region 拖拽事件
        private void MainWindow_Drop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length == 0) return;
            for (int i = 0; i < files.Length; i++)
            {
                AddFromFile(new FileInfo(files[i]));
            }
        }

        private void AddFromFile(FileInfo fileInfo)
        {
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
            var shortcut = new Shortcut(name, path);
            UserConfig.userGroups[UserConfig.selectedGroup].shortcuts.Add(shortcut);
        }
        #endregion


        private void LeftList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.LeftList.SelectedItem != null)
            {
                this.RightList.ItemsSource= (this.LeftList.SelectedItem as UserGroup).shortcuts;
                UserConfig.selectedGroup = this.LeftList.SelectedIndex;
            }
        }
        #region Resize
        private const int WM_NCHITTEST = 0x0084;
        private readonly int agWidth = 8; //拐角宽度  
        private readonly int bThickness = 2; // 边框宽度  
        private Point mousePoint; //鼠标坐标
        private enum HitTest : int
        {
            HTERROR = -2,
            HTTRANSPARENT = -1,
            HTNOWHERE = 0,
            HTCLIENT = 1,
            HTCAPTION = 2,
            HTSYSMENU = 3,
            HTGROWBOX = 4,
            HTSIZE = HTGROWBOX,
            HTMENU = 5,
            HTHSCROLL = 6,
            HTVSCROLL = 7,
            HTMINBUTTON = 8,
            HTMAXBUTTON = 9,
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17,
            HTBORDER = 18,
            HTREDUCE = HTMINBUTTON,
            HTZOOM = HTMAXBUTTON,
            HTSIZEFIRST = HTLEFT,
            HTSIZELAST = HTBOTTOMRIGHT,
            HTOBJECT = 19,
            HTCLOSE = 20,
            HTHELP = 21,
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;
            if (hwndSource != null)
            {
                hwndSource.AddHook(new HwndSourceHook(this.WndProc));
            }
        }
        protected virtual IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case WM_NCHITTEST:
                    #region 测试鼠标位置  
                    if (WindowState == WindowState.Normal)
                    {
                        this.mousePoint.X = (lParam.ToInt32() & 0xFFFF);
                        this.mousePoint.Y = (lParam.ToInt32() >> 16);
                        // 窗口左上角  
                        if (this.mousePoint.Y - this.Top <= this.agWidth
                            && this.mousePoint.X - this.Left <= this.agWidth)
                        {
                            handled = true;
                            return new IntPtr((int)MainWindow.HitTest.HTTOPLEFT);

                        }
                        // 窗口左下角      
                        else if (this.ActualHeight + this.Top - this.mousePoint.Y <= this.agWidth
                                 && this.mousePoint.X - this.Left <= this.agWidth)
                        {
                            handled = true;
                            return new IntPtr((int)MainWindow.HitTest.HTBOTTOMLEFT);
                        }
                        // 窗口右上角  
                        else if (this.mousePoint.Y - this.Top <= this.agWidth
                                 && this.ActualWidth + this.Left - this.mousePoint.X <= this.agWidth)
                        {
                            handled = true;
                            return new IntPtr((int)MainWindow.HitTest.HTTOPRIGHT);
                        }
                        // 窗口右下角  
                        else if (this.ActualWidth + this.Left - this.mousePoint.X <= this.agWidth
                                 && this.ActualHeight + this.Top - this.mousePoint.Y <= this.agWidth)
                        {
                            handled = true;
                            return new IntPtr((int)MainWindow.HitTest.HTBOTTOMRIGHT);
                        }
                        // 窗口左侧  
                        else if (this.mousePoint.X - this.Left <= this.bThickness)
                        {
                            handled = true;
                            return new IntPtr((int)MainWindow.HitTest.HTLEFT);
                        }
                        // 窗口右侧  
                        else if (this.ActualWidth + this.Left - this.mousePoint.X <= this.bThickness)
                        {
                            handled = true;
                            return new IntPtr((int)MainWindow.HitTest.HTRIGHT);
                        }
                        // 窗口上方  
                        else if (this.mousePoint.Y - this.Top <= this.bThickness)
                        {
                            handled = true;
                            return new IntPtr((int)MainWindow.HitTest.HTTOP);
                        }
                        // 窗口下方  
                        else if (this.ActualHeight + this.Top - this.mousePoint.Y <= this.bThickness)
                        {
                            handled = true;
                            return new IntPtr((int)MainWindow.HitTest.HTBOTTOM);
                        }
                    }
                    //else // 窗口移动  
                    //{
                    //    handled = true;
                    //    return new IntPtr((int)HitTest.HTCAPTION);
                    //}
                    break;

                #endregion
            }
            return IntPtr.Zero;
        }
        #endregion
    }
}
