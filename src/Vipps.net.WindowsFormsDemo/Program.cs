using System;
using System.Configuration;
using System.Windows.Forms;
using Vipps.net.Infrastructure;

namespace Vipps.net.WindowsFormsDemo
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // These settings are saved in a secrets.xml file, which must not be checked in
            VippsConfiguration.ClientId = ConfigurationManager.AppSettings["ClientId"];
            VippsConfiguration.ClientSecret = ConfigurationManager.AppSettings["ClientSecret"];
            VippsConfiguration.MerchantSerialNumber = ConfigurationManager.AppSettings[
                "MerchantSerialNumber"
            ];
            VippsConfiguration.SubscriptionKey = ConfigurationManager.AppSettings[
                "SubscriptionKey"
            ];
            VippsConfiguration.TestMode = bool.Parse(
                ConfigurationManager.AppSettings["UseTestMode"]
            );

            Application.Run(new Form1());
        }
    }
}
