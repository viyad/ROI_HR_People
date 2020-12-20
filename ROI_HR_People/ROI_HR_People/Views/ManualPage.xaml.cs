using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ROI_HR_People.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ManualPage : ContentPage
    {
        private double width;
        private double height;

        public ManualPage()
        {
            InitializeComponent();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    section1.Orientation = section1_1.Orientation = section1_2.Orientation = section1_3.Orientation = StackOrientation.Horizontal;
                    section2.Orientation = section2_1.Orientation = section2_2.Orientation = section2_3.Orientation = StackOrientation.Horizontal;
                    section3.Orientation = section3_1.Orientation = section3_2.Orientation = StackOrientation.Horizontal;
                }
                else
                {
                    section1.Orientation = section1_1.Orientation = section1_2.Orientation = StackOrientation.Vertical;
                    section2.Orientation = section2_1.Orientation = section2_2.Orientation = StackOrientation.Vertical;
                    section3.Orientation = section3_1.Orientation = section3_2.Orientation = StackOrientation.Vertical;
                }
            }
        }
    }
}