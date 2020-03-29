using iRacingSdkWrapper;
using System;
using System.Windows.Forms;

namespace RaceAdmin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // create the main form and add a proxy layer between our application and the iRacingSdkWrapper;
            // this will make it easier for us to add both unit tests and full system tests with wrapper event
            // replay later
            SdkWrapper wrapper = new SdkWrapper();
            SdkWrapperProxy proxy = new SdkWrapperProxy(wrapper);
            RaceAdminMain form = new RaceAdminMain(proxy, new DefaultCautionHandler());

            Application.Run(form);
        }
    }
}
