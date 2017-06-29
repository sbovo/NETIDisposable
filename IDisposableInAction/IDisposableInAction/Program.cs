using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisposableInAction
{
    public class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                // IDisposable full implementatation and Dispose called by developer
                string fileName1 = $"C:\\_temp\\SomeFiles\\SomeFile1.{i}.txt";
                var dispFullandDisposeCalled = new ImplementIDispClass(fileName1);
                dispFullandDisposeCalled.WriteToFile();
                dispFullandDisposeCalled.Dispose();

                // IDisposable full implementatation but Dispose NOT called by developer
                //string fileName2 = $"C:\\_temp\\SomeFiles\\SomeFile2.{i}.txt";
                //var dispFullandDisposeNOTCalled = new ImplementIDispClass(fileName2);
                //dispFullandDisposeNOTCalled.WriteToFile();

                // IDisposable not implemented at all
                //string fileName3 = $"C:\\_temp\\SomeFiles\\SomeFile3.{i}.txt";
                //var notDisp = new NotImplementIDispClass(fileName3);
                //notDisp.WriteToFile();
            }

            Console.WriteLine("No manual GC collection done. Press ENTER to continue");
            Console.ReadLine();

            #region GC work
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            GC.WaitForFullGCComplete();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            GC.WaitForPendingFinalizers();
            GC.WaitForFullGCComplete();
            #endregion

            Console.WriteLine("Forced GC collections done. Press ENTER to exit");
            Console.ReadLine();
        }


     
    }
}
