/* Author: Spencer Stewart
 * Last Updated: 10/11/2019
 * Project: CompatibilityCalculator
 *
 * Description:
 * 
 * The functionality of this class simply changes the view of the
 * window when the different windows are pushed.
 * 
 */

using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace CompatibilityCalculatorXamarin
{
    
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        // Default Constructor.
        public MainPage()
        {
            InitializeComponent();
        }

        // When the user wants to add or remove a potential, they will
        // push this button and the content page will come up.
        void DisplayAddRemoveSL(object sender, EventArgs args)
        {
            // Show the add/remove grid, and hide the test grid.
            TestCompGrid.IsVisible = false;
            AddRemoveGrid.IsVisible = true;
        }

        // When the user wants to test compatibility, they will
        // push this button and the content page will come up.
        void DisplayTestCompSL(object sender, EventArgs args)
        {
            // Hide the add/remove grid, and show the test grid.
            TestCompGrid.IsVisible = true;
            AddRemoveGrid.IsVisible = false;
        }
    }
}
