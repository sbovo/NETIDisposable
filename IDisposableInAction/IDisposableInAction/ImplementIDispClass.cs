﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisposableInAction
{
    class ImplementIDispClass : IDisposable
    {
        private StreamWriter sw = null;

        public ImplementIDispClass(string fileName)
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

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            Trace.WriteLine($"ImplementIDispClass | Dispose {disposing}");

            if (!disposedValue)
            {
                if (disposing)
                {
                    if (this.sw != null)
                    {
                        this.sw.Close();
                    }
                }

                
                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~ImplementIDispClass()
        {
            Trace.WriteLine("ImplementIDispClass | Finalizer");

            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
