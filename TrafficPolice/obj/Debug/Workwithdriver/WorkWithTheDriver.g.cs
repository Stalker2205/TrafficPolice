﻿#pragma checksum "..\..\..\Workwithdriver\WorkWithTheDriver.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "00CA52A541DB904F55576C3B49C9B2D9EF8572D072FAE04EFED6659DB528F4F9"
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
using TrafficPolice;


namespace TrafficPolice {
    
    
    /// <summary>
    /// WorkWithTheDriver
    /// </summary>
    public partial class WorkWithTheDriver : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 19 "..\..\..\Workwithdriver\WorkWithTheDriver.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DriverGrid;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Workwithdriver\WorkWithTheDriver.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame FrameFromNavigation;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Workwithdriver\WorkWithTheDriver.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IdDriverTbox;
        
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
            System.Uri resourceLocater = new System.Uri("/TrafficPolice;component/workwithdriver/workwiththedriver.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Workwithdriver\WorkWithTheDriver.xaml"
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
            this.DriverGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.FrameFromNavigation = ((System.Windows.Controls.Frame)(target));
            return;
            case 7:
            this.IdDriverTbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 62 "..\..\..\Workwithdriver\WorkWithTheDriver.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuItem_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 63 "..\..\..\Workwithdriver\WorkWithTheDriver.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateDriver_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 65 "..\..\..\Workwithdriver\WorkWithTheDriver.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.SerchDriver_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 71 "..\..\..\Workwithdriver\WorkWithTheDriver.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.mcCreateDriverLIcence);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 25 "..\..\..\Workwithdriver\WorkWithTheDriver.xaml"
            ((System.Windows.Controls.MenuItem)(target)).SubmenuOpened += new System.Windows.RoutedEventHandler(this.MenuItem_SubmenuOpened);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 26 "..\..\..\Workwithdriver\WorkWithTheDriver.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.OpenPeopleInfo_Click);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 27 "..\..\..\Workwithdriver\WorkWithTheDriver.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateDriverInfo_Click);
            
            #line default
            #line hidden
            break;
            case 5:
            
            #line 30 "..\..\..\Workwithdriver\WorkWithTheDriver.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.mcCreateDriverLIcence);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

