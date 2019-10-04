using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace CompatibilityCalculatorXamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void DisplayAddRemoveSL(object sender, EventArgs args)
        {
            TestCompGrid.IsVisible = false;
            AddRemoveGrid.IsVisible = true;
        }
        void DisplayTestCompSL(object sender, EventArgs args)
        {
            TestCompGrid.IsVisible = true;
            AddRemoveGrid.IsVisible = false;
        }
    }
}
