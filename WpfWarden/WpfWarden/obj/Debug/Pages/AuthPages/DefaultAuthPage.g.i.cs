﻿#pragma checksum "..\..\..\..\Pages\AuthPages\DefaultAuthPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D0CFA39990FF9D2822D36C102FE50A8F9002689FA521D550380D112C1F290BF7"
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
using WpfWarden.Pages.AuthPages;


namespace WpfWarden.Pages.AuthPages {
    
    
    /// <summary>
    /// DefaultAuthPage
    /// </summary>
    public partial class DefaultAuthPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\..\Pages\AuthPages\DefaultAuthPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbLogin;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Pages\AuthPages\DefaultAuthPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txbPassword;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\Pages\AuthPages\DefaultAuthPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEntry;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\Pages\AuthPages\DefaultAuthPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnForgotPassword;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfWarden;component/pages/authpages/defaultauthpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\AuthPages\DefaultAuthPage.xaml"
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
            this.txbLogin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txbPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.btnEntry = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\..\Pages\AuthPages\DefaultAuthPage.xaml"
            this.btnEntry.Click += new System.Windows.RoutedEventHandler(this.btnEntry_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnForgotPassword = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\..\Pages\AuthPages\DefaultAuthPage.xaml"
            this.btnForgotPassword.Click += new System.Windows.RoutedEventHandler(this.btnForgotPassword_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
