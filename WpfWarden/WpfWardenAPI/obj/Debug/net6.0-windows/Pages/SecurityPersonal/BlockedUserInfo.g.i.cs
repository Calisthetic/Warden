﻿#pragma checksum "..\..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "69937587AE465725D618B10D53C997F08E43E1A7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using WpfWardenAPI.Pages.SecurityPersonal;


namespace WpfWardenAPI.Pages.SecurityPersonal {
    
    
    /// <summary>
    /// BlockedUserInfo
    /// </summary>
    public partial class BlockedUserInfo : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer ScrollMessages;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LVMessages;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbActions;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbMessageText;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSendMessage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfWardenAPI;component/pages/securitypersonal/blockeduserinfo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml"
            ((WpfWardenAPI.Pages.SecurityPersonal.BlockedUserInfo)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.Page_IsVisibleChanged);
            
            #line default
            #line hidden
            
            #line 9 "..\..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml"
            ((WpfWardenAPI.Pages.SecurityPersonal.BlockedUserInfo)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Page_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ScrollMessages = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 3:
            this.LVMessages = ((System.Windows.Controls.ListView)(target));
            
            #line 32 "..\..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml"
            this.LVMessages.PreviewMouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.LVMessages_PreviewMouseWheel);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cmbActions = ((System.Windows.Controls.ComboBox)(target));
            
            #line 104 "..\..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml"
            this.cmbActions.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbActions_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txbMessageText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnSendMessage = ((System.Windows.Controls.Button)(target));
            
            #line 110 "..\..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml"
            this.btnSendMessage.Click += new System.Windows.RoutedEventHandler(this.btnSendMessage_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

