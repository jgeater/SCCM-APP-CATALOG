using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Windows.Forms;
using System.Management.Instrumentation;

using System.Diagnostics;


namespace Allstate_SW_Catalog
{
    class Program
    {
        static void Main(string[] args)
        {
            try// Get the client's SMS_ClientSDK class.
            {
                ManagementScope s = new ManagementScope("root\\ccm\\clientsdk");
                ManagementPath p = new ManagementPath("CCM_SoftwareCatalogUtilities");
                ManagementClass cls = new ManagementClass(s, p, null);

                // get the catalog URL.
                ManagementBaseObject outSiteParams = cls.InvokeMethod("GetPortalUrlValue", null, null);

                Process pr = new Process();

                pr.StartInfo.FileName = "c:\\Program Files\\Internet Explorer\\iexplore.exe";
                pr.StartInfo.Arguments = (outSiteParams["PortalUrl"].ToString());
                pr.Start();

            }
            catch (ManagementException e)
            {
                Console.WriteLine("Failed to execute method", e);
                MessageBox.Show("Error! Could not find SCCM Store URL!", "Error");
            }
        }
    }
}
