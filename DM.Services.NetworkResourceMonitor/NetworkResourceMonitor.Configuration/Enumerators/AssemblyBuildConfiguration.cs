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
    ///Enumerator: Assembly Build Configuration Enumerator, lists the different types of configured assembly build types.
    ///</summary>
    ///<author> Dan Maul </author> <created> 21/06/2017 </created>
    ///<remarks></remarks>
    public enum AssemblyBuildConfiguration
    {
        Debug,
        Release,
        Dev,
        QC,
        PRD
    }

}