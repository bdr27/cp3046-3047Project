﻿#pragma checksum "..\..\ModalPlayerEditDelete.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "48F8160BC45105AA779DB6ABBF32C6D9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
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


namespace NerfWarsLeaderboard {
    
    
    /// <summary>
    /// ModalPlayerEditDelete
    /// </summary>
    public partial class ModalPlayerEditDelete : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\ModalPlayerEditDelete.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblSearchAPlayer;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\ModalPlayerEditDelete.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbLastName;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\ModalPlayerEditDelete.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbPlayerNames;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ModalPlayerEditDelete.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlayerModalEdit;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ModalPlayerEditDelete.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlayerModalCancel;
        
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
            System.Uri resourceLocater = new System.Uri("/NerfWarsPrototype;component/modalplayereditdelete.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ModalPlayerEditDelete.xaml"
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
            this.tblSearchAPlayer = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.tbLastName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.cmbPlayerNames = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.btnPlayerModalEdit = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.btnPlayerModalCancel = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

