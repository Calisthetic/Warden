﻿#pragma checksum "..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1E0D68E03969AAAA0609B6B9DD9723BAF679FE762E2A7B9FD34A6CE2C4EEF849"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfWarden.Pages.SecurityPersonal;


namespace WpfWarden.Pages.SecurityPersonal {
    
    
    /// <summary>
    /// BlockedUserInfo
    /// </summary>
    public partial class BlockedUserInfo : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtFIO;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtBlockedUserFIO;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LVMessages;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbMessageText;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSendMessage;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfWarden;component/pages/securitypersonal/blockeduserinfo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml"
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
            
            #line 9 "..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml"
            ((WpfWarden.Pages.SecurityPersonal.BlockedUserInfo)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.Page_IsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtFIO = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.txtBlockedUserFIO = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.LVMessages = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.txbMessageText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnSendMessage = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\Pages\SecurityPersonal\BlockedUserInfo.xaml"
            this.btnSendMessage.Click += new System.Windows.RoutedEventHandler(this.btnSendMessage_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

