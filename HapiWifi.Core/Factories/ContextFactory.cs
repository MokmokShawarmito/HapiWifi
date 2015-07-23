using HapiWifi.Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HapiWifi.Core.Factories
{
    class ContextFactory
    {
        public static HapiWifiDB CreateContext()
        {
            return new HapiWifiDB();
        }
    }
}
