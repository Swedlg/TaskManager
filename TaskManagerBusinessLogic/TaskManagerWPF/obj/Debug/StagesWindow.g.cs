﻿#pragma checksum "..\..\StagesWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FD8F30218469DE6CD2CB286166D1543BC5A35C532671E4C33A1E0C0DC7D9FA60"
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
using TaskManagerWPF;


namespace TaskManagerWPF {
    
    
    /// <summary>
    /// StagesWindow
    /// </summary>
    public partial class StagesWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\StagesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonCreate;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\StagesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonUpdate;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\StagesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonDelete;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\StagesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonRefresh;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\StagesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridStages;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\StagesWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_link_developer;
        
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
            System.Uri resourceLocater = new System.Uri("/TaskManagerWPF;component/stageswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\StagesWindow.xaml"
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
            this.buttonCreate = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\StagesWindow.xaml"
            this.buttonCreate.Click += new System.Windows.RoutedEventHandler(this.buttonCreate_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.buttonUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\StagesWindow.xaml"
            this.buttonUpdate.Click += new System.Windows.RoutedEventHandler(this.buttonUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.buttonDelete = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\StagesWindow.xaml"
            this.buttonDelete.Click += new System.Windows.RoutedEventHandler(this.buttonDelete_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.buttonRefresh = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\StagesWindow.xaml"
            this.buttonRefresh.Click += new System.Windows.RoutedEventHandler(this.buttonRefresh_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dataGridStages = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.button_link_developer = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\StagesWindow.xaml"
            this.button_link_developer.Click += new System.Windows.RoutedEventHandler(this.button_link_developer_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

