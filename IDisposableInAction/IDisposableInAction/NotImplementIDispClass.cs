using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisposableInAction
{
    class NotImplementIDispClass
    {
        private StreamWriter sw = null;

        public NotImplementIDispClass(string fileName)
        {
            try
            {
                this.sw = new StreamWriter(fileName, true, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void WriteToFile()
        {
            if (this.sw != null)
            {
                try
                {
                    sw.WriteLine(DateTime.Now.ToLongTimeString());
                    sw.Flush();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

    }
}
