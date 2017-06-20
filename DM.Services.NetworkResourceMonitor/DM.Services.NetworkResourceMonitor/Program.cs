#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace DM.Services.NetworkResourceMonitor
{
    ///<summary> 
    ///Class: Main Windows Service program.
    ///</summary>
    ///<author> Dan Maul </author> <created> 20/06/2017 </created>
    ///<remarks></remarks>
    static class Program
    {

        #region Implements

        #endregion

        #region Inherits

        #endregion

        #region Properties

        #endregion

        #region Constants

        #endregion

        #region Constructors

        ///<summary> 
        ///Subroutine: The main entry point for the application.
        ///</summary>
        ///<author> Dan Maul </author> <created> 20/06/2017 </created>
        ///<remarks></remarks>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new NetworkResourceMonitor()
            };
            ServiceBase.Run(ServicesToRun);
        }

        #endregion

        #region Destructors

        #endregion

        #region Event Handlers

        #endregion

        #region Protected Functions/Subroutines

        #endregion

        #region Private Functions/Subroutines

        #endregion

        #region Public Functions/Subroutines

        #endregion

    }
}
