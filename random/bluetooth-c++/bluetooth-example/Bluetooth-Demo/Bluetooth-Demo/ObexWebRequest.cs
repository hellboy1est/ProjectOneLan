using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bluetooth_Demo
{
    class ObexWebRequest
    {
        private Uri uri;

        public ObexWebRequest(Uri uri)
        {
            // TODO: Complete member initialization
            this.uri = uri;
        }
        internal void ReadFile(string file_path)
        {
            throw new NotImplementedException();
        }

        internal ObexWebResponse GetResponse()
        {
            throw new NotImplementedException();
        }
    }
}
