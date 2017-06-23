#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
#endregion

namespace DM.Services.NetworkResourceMonitor.BusinessLogic.Configuration
{

    ///<summary> 
    ///Enumerator: Service Configuration DataTable Source Type, defines the types of sources for the configured cached data table.
    ///</summary>
    ///<author> Dan Maul </author> <created> 23/06/2017 </created>
    ///<remarks></remarks>
    public enum DataTableSourceType
    {
        SQL,
        StoredProcedure
    }

}