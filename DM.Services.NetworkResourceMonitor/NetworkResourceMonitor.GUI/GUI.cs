#region Using
using System;
using System.Windows.Forms;
using DM.Services.NetworkResourceMonitor.BusinessLogic.Configuration.Cache;
#endregion

namespace DM.Services.NetworkResourceMonitor.GUI
{

    ///<summary> 
    ///Class: Network Resource Monitor GUI Class, for easy debugging of service behaviour held in the business logic layer of the solution.
    ///</summary>
    ///<author> Dan Maul </author> <created> 21/06/2017 </created>
    ///<remarks></remarks>
    public partial class GUI : Form
    {

        #region Properties

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
                ServiceConfigurationCache.Session.Initialise();
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

        ///<summary> 
        ///Event Handler: Manually triggers an exception, for testing database interaction and stored procedure caching.
        ///</summary>
        ///<author> Dan Maul </author> <created> 20/06/2017 </created>
        ///<remarks></remarks>
        private void btn_TriggerException_Click(object sender, EventArgs e)
        {
            try
            {
                throw new Exception("Test Exception");
            }
            catch(Exception Exc)
            {
                using (BusinessLogic.SQL.DatabaseHandler DatabaseHandler = new BusinessLogic.SQL.DatabaseHandler(ServiceConfigurationCache.Session))
                {
                    DatabaseHandler.LogApplicationException(Exc);
                }
            }
        }

        ///<summary> 
        ///Event Handler: Manually trigger a loop of all cached Network Resource entries and pings each one, for testing basic resource monitoring.
        ///</summary>
        ///<author> Dan Maul </author> <created> 06/07/2017 </created>
        ///<remarks></remarks>
        private void btn_PingResources_Click(object sender, EventArgs e)
        {

            System.Net.NetworkInformation.PingReply PingReply = null;

            try
            {
                foreach (BusinessLogic.Configuration.NetworkResource NetworkResource in BusinessLogic.SQL.DatabaseHandler.DataTableToEnterpriseObjects<BusinessLogic.Configuration.NetworkResource>(ServiceConfigurationCache.Session.CachedSQLConnections["Configuration"].DataTables["NetworkResource"]))
                {
                    using (BusinessLogic.Network.NetworkResourceHandler NetworkResourceHandler = new BusinessLogic.Network.NetworkResourceHandler(NetworkResource))
                    {

                        txtbx_MonitorOutput.AppendText($"Pinging {NetworkResource.ResourceID}... ");

                        PingReply = NetworkResourceHandler.PingResource();

                        txtbx_MonitorOutput.AppendText($"Responded: {PingReply.RoundtripTime.ToString()}ms, Status: {PingReply.Status.ToString()} \r\n");
                    }
                }

            } catch (Exception Exc)
            {
                txtbx_MonitorOutput.AppendText($"An Exception of type {Exc.GetType().ToString()} occurred when pinging configured resources: {Exc.Message} \r\n");
            }            
        }

        #endregion

        #region Protected Functions/Subroutines

        #endregion

        #region Private Functions/Subroutines

        #endregion

        #region Public Functions/Subroutines

        #endregion
    }
}
