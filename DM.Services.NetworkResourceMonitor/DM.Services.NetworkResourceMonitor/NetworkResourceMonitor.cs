#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace DM.Services.NetworkResourceMonitor
{

    ///<summary> 
    ///Class: Network Resource Monitor Service Class, automatically monitors and reports on the status of various pieces of configured network resource.
    ///</summary>
    ///<author> Dan Maul </author> <created> 20/06/2017 </created>
    ///<remarks></remarks>
    partial class NetworkResourceMonitor : ServiceBase
    {

        #region Implements

        #endregion

        #region Inherits

        #endregion

        #region Properties

        private BusinessLogic.Configuration.Cache.ServiceConfigurationCache ServiceConfigurationCache { get; set; }

        #endregion

        #region Constants

        #endregion

        #region Constructors

        ///<summary> 
        ///Constructor: Class Constructor Method.
        ///</summary>
        ///<author> Dan Maul </author> <created> 20/06/2017 </created>
        ///<remarks></remarks>
        public NetworkResourceMonitor()
        {
            InitializeComponent();
        }

        #endregion

        #region Destructors

        #endregion

        #region Event Handlers

        #endregion

        #region Protected Functions/Subroutines

        ///<summary> 
        ///Constructor: Class Constructor Method.
        ///</summary>
        ///<author> Dan Maul </author> <created> 20/06/2017 </created>
        ///<remarks></remarks>
        protected override void OnStart(string[] args)
        {

            try
            {
                // TODO: Add code here to start your service.
                ServiceConfigurationCache = new BusinessLogic.Configuration.Cache.ServiceConfigurationCache();
                ServiceConfigurationCache.Initialise();


            }
            catch (Exception Exc)
            {
                throw (Exc);
            }
            finally
            {

            }

        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }

        #endregion

        #region Private Functions/Subroutines

        #endregion

        #region Public Functions/Subroutines

        #endregion

    }
}
