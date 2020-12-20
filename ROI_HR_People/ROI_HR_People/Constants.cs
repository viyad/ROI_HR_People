using Xamarin.Forms;

namespace ROI_HR_People
{
    public static class Constants
    {
        // URL of ASMX service
        public static string SoapUrl
        {
            get
            {
                var defaultUrl = "http://172.20.10.7:44381/PeopleService.asmx";

                if (Device.RuntimePlatform == Device.Android)
                {
                    // Home
                    defaultUrl = "http://172.20.10.7:44381/PeopleService.asmx";
                }

                return defaultUrl;
            }
        }
    }
}