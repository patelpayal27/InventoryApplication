using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace InventoryView
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            EmbeddedAssembly.Load("InventoryView.EmbeddedResources.InventoryModel.dll", "InventoryView.EmbeddedResources.InventoryModel.dll");
            EmbeddedAssembly.Load("InventoryView.EmbeddedResources.DocumentFormat.OpenXml.dll", "InventoryView.EmbeddedResources.DocumentFormat.OpenXml.dll");
            EmbeddedAssembly.Load("InventoryView.EmbeddedResources.itextsharp.dll", "InventoryView.EmbeddedResources.itextsharp.dll");
            //EmbeddedAssembly.Load("InventoryView.EmbeddedResources.System.Data.SQLite.dll", "InventoryView.EmbeddedResources.System.Data.SQLite.dll");
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMdiMain());
        }

        static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return EmbeddedAssembly.Get(args.Name);
        }
    }
}
