﻿#pragma checksum "..\..\CreateInsurances.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "69A35FFC7630435E3CB5631F3CB4D9F4310ABAB8A233621CBB7A1B3E26DCE426"
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
    /// CreateInsurances
    /// </summary>
    public partial class CreateInsurances : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\CreateInsurances.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid InsurancesGrid;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\CreateInsurances.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_Number;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\CreateInsurances.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_Series;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\CreateInsurances.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dp_DateStart;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\CreateInsurances.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker db_DateEnd;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\CreateInsurances.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox cb_Insurant;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\CreateInsurances.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_createInsurants;
        
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
            System.Uri resourceLocater = new System.Uri("/TrafficPolice;component/createinsurances.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\CreateInsurances.xaml"
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
            this.InsurancesGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.tb_Number = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.tb_Series = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.dp_DateStart = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.db_DateEnd = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 6:
            this.cb_Insurant = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.bt_createInsurants = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\CreateInsurances.xaml"
            this.bt_createInsurants.Click += new System.Windows.RoutedEventHandler(this.bt_createInsurants_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

