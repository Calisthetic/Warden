﻿#pragma checksum "..\..\..\..\Pages\SecurityPersonal\InfoSecurerPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0C4D1B111AD5467D376F2C6E02678BBFC44F7245CABBAA9BA6F60659F38DAF76"
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
    /// InfoSecurerPage
    /// </summary>
    public partial class InfoSecurerPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\Pages\SecurityPersonal\InfoSecurerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DGUsersForVerify;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Pages\SecurityPersonal\InfoSecurerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridComboBoxColumn CmbRole;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\Pages\SecurityPersonal\InfoSecurerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConfirm;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Pages\SecurityPersonal\InfoSecurerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DGPermissions;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Pages\SecurityPersonal\InfoSecurerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\Pages\SecurityPersonal\InfoSecurerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSave;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Pages\SecurityPersonal\InfoSecurerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAdd;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Pages\SecurityPersonal\InfoSecurerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LVBlockedUsers;
        
        #line default
        #line hidden
        
        
        #line 151 "..\..\..\..\Pages\SecurityPersonal\InfoSecurerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtFIO;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfWarden;component/pages/securitypersonal/infosecurerpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\SecurityPersonal\InfoSecurerPage.xaml"
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
            
            #line 9 "..\..\..\..\Pages\SecurityPersonal\InfoSecurerPage.xaml"
            ((WpfWarden.Pages.SecurityPersonal.InfoSecurerPage)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.Page_IsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DGUsersForVerify = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 3:
            this.CmbRole = ((System.Windows.Controls.DataGridComboBoxColumn)(target));
            return;
            case 4:
            this.btnConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\..\Pages\SecurityPersonal\InfoSecurerPage.xaml"
            this.btnConfirm.Click += new System.Windows.RoutedEventHandler(this.btnConfirm_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DGPermissions = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\..\Pages\SecurityPersonal\InfoSecurerPage.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.btnDelete_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnSave = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\..\Pages\SecurityPersonal\InfoSecurerPage.xaml"
            this.btnSave.Click += new System.Windows.RoutedEventHandler(this.btnSave_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnAdd = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\..\Pages\SecurityPersonal\InfoSecurerPage.xaml"
            this.btnAdd.Click += new System.Windows.RoutedEventHandler(this.btnAdd_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.LVBlockedUsers = ((System.Windows.Controls.ListView)(target));
            
            #line 69 "..\..\..\..\Pages\SecurityPersonal\InfoSecurerPage.xaml"
            this.LVBlockedUsers.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LVBlockedUsers_Selected);
            
            #line default
            #line hidden
            return;
            case 10:
            this.txtFIO = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

