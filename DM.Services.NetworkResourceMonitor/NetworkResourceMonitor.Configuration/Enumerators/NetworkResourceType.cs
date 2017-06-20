#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
#endregion

namespace DM.Services.NetworkResourceMonitor.Configuration
{

    ///<summary> 
    ///Enumerator: Network Resource Type enumerator, defines the various network resource types that can be monitored.
    ///</summary>
    ///<author> Dan Maul </author> <created> 20/06/2017 </created>
    ///<remarks></remarks>
    enum NetworkResourceType
    {
        Server,
        Desktop,
        Laptop,
        NAS,
        Printer,
        MobileDevice,
        Microcontroller,
        Console
    }

}