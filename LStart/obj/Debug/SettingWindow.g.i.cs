﻿#pragma checksum "..\..\SettingWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F33A28B99575F61C1C5E6CF4D7F47A46"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using LStart;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace LStart {
    
    
    /// <summary>
    /// SettingWindow
    /// </summary>
    public partial class SettingWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 156 "..\..\SettingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel TitlePanel;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\SettingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseButton;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\SettingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox StartBox;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\SettingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox HotkeyToggle;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\SettingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox HotKeyBox;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\SettingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox TopMostBox;
        
        #line default
        #line hidden
        
        
        #line 170 "..\..\SettingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox IsRelativeBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/LStart;component/settingwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SettingWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.TitlePanel = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 2:
            this.CloseButton = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.StartBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 166 "..\..\SettingWindow.xaml"
            this.StartBox.Checked += new System.Windows.RoutedEventHandler(this.StartBox_OnChecked);
            
            #line default
            #line hidden
            
            #line 166 "..\..\SettingWindow.xaml"
            this.StartBox.Unchecked += new System.Windows.RoutedEventHandler(this.StartBox_OnUnchecked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.HotkeyToggle = ((System.Windows.Controls.CheckBox)(target));
            
            #line 167 "..\..\SettingWindow.xaml"
            this.HotkeyToggle.Checked += new System.Windows.RoutedEventHandler(this.HotkeyToggle_OnChecked);
            
            #line default
            #line hidden
            
            #line 167 "..\..\SettingWindow.xaml"
            this.HotkeyToggle.Unchecked += new System.Windows.RoutedEventHandler(this.HotkeyToggle_OnUnchecked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.HotKeyBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 168 "..\..\SettingWindow.xaml"
            this.HotKeyBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.HotKeyBox_OnKeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TopMostBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 7:
            this.IsRelativeBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 170 "..\..\SettingWindow.xaml"
            this.IsRelativeBox.Checked += new System.Windows.RoutedEventHandler(this.IsRelativeBox_Checked);
            
            #line default
            #line hidden
            
            #line 170 "..\..\SettingWindow.xaml"
            this.IsRelativeBox.Unchecked += new System.Windows.RoutedEventHandler(this.IsRelativeBox_Unchecked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

