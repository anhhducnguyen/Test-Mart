﻿#pragma checksum "..\..\Statistical.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "28BEE6C50DC82F4A63C08E0A805D63FE3265A0C2F6B4644164D4D28DFFEEC351"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
using LiveCharts.Wpf;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using sieu_thi_mini;
using sieu_thi_mini.Utilities;
using sieu_thi_mini.ViewModel;


namespace sieu_thi_mini.View {
    
    
    /// <summary>
    /// Statistical
    /// </summary>
    public partial class Statistical : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 49 "..\..\Statistical.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label idEmployee;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\Statistical.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label nameEmployee;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\Statistical.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label doanhthu;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\Statistical.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.PieChart PieChart2;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\Statistical.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btexcel;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\Statistical.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TimeframeComboBox;
        
        #line default
        #line hidden
        
        
        #line 143 "..\..\Statistical.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock name_chart;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\Statistical.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart BarChart;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\Statistical.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbMonth;
        
        #line default
        #line hidden
        
        
        #line 200 "..\..\Statistical.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbYear;
        
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
            System.Uri resourceLocater = new System.Uri("/sieu_thi_mini;component/statistical.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Statistical.xaml"
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
            
            #line 15 "..\..\Statistical.xaml"
            ((sieu_thi_mini.View.Statistical)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.idEmployee = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.nameEmployee = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.doanhthu = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.PieChart2 = ((LiveCharts.Wpf.PieChart)(target));
            return;
            case 6:
            this.btexcel = ((System.Windows.Controls.Button)(target));
            
            #line 117 "..\..\Statistical.xaml"
            this.btexcel.Click += new System.Windows.RoutedEventHandler(this.btexcel_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TimeframeComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 130 "..\..\Statistical.xaml"
            this.TimeframeComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TimeframeComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.name_chart = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.BarChart = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 10:
            this.cmbMonth = ((System.Windows.Controls.ComboBox)(target));
            
            #line 169 "..\..\Statistical.xaml"
            this.cmbMonth.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbMonth_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            this.cmbYear = ((System.Windows.Controls.ComboBox)(target));
            
            #line 201 "..\..\Statistical.xaml"
            this.cmbYear.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbYear_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

