﻿#pragma checksum "..\..\..\..\..\Pages\AuthPages\DefaultAuthPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BB661B7308C967AB9CFD23504A25BD0475D573F8"
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
using WpfWardenAPI.Pages.AuthPages;


namespace WpfWardenAPI.Pages.AuthPages {
    
    
    /// <summary>
    /// DefaultAuthPage
    /// </summary>
    public partial class DefaultAuthPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\..\Pages\AuthPages\DefaultAuthPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbLogin;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\..\Pages\AuthPages\DefaultAuthPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox psbPassword;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\Pages\AuthPages\DefaultAuthPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbDivisions;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\Pages\AuthPages\DefaultAuthPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEntry;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\..\Pages\AuthPages\DefaultAuthPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnForgotPassword;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfWardenAPI;V1.0.0.0;component/pages/authpages/defaultauthpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Pages\AuthPages\DefaultAuthPage.xaml"
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
            
            #line 9 "..\..\..\..\..\Pages\AuthPages\DefaultAuthPage.xaml"
            ((WpfWardenAPI.Pages.AuthPages.DefaultAuthPage)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.Page_IsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txbLogin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.psbPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 4:
            this.cmbDivisions = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.btnEntry = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\..\Pages\AuthPages\DefaultAuthPage.xaml"
            this.btnEntry.Click += new System.Windows.RoutedEventHandler(this.btnEntry_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnForgotPassword = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\..\Pages\AuthPages\DefaultAuthPage.xaml"
            this.btnForgotPassword.Click += new System.Windows.RoutedEventHandler(this.btnForgotPassword_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

