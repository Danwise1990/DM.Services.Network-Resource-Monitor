#region Using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace NetworkResourceMonitor.GUI
{

    ///<summary> 
    ///Class: Network Resource Monitor GUI Class, for easy debugging of service behaviour held in the business logic layer of the solution.
    ///</summary>
    ///<author> Dan Maul </author> <created> 21/06/2017 </created>
    ///<remarks></remarks>
    public partial class GUI : Form
    {

        #region Implements

        #endregion

        #region Inherits

        #endregion

        #region Properties

        private DM.Services.NetworkResourceMonitor.BusinessLogic.Configuration.Cache.ServiceConfigurationCache ServiceConfigurationCache;

        #endregion

        #region Constants

        #endregion

        #region Constructors

        ///<summary> 
        ///Constructor: Class Constructor Method.
        ///</summary>
        ///<author> Dan Maul </author> <created> 20/06/2017 </created>
        ///<remarks></remarks>
        public GUI()
        {
            InitializeComponent();

            try
            {
                // TODO: Add code here to start your service.
                ServiceConfigurationCache = new DM.Services.NetworkResourceMonitor.BusinessLogic.Configuration.Cache.ServiceConfigurationCache();
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
