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
    ///Class: Service Configuration File Root Class Object.
    ///</summary>
    ///<author> Dan Maul </author> <created> 20/06/2017 </created>
    ///<remarks></remarks>
    [Serializable]
    public class ServiceConfiguration
    {
        #region Implements

        #endregion

        #region Inherits

        #endregion

        #region Properties

        private string Identity;
        private bool EnableEmailAlerts;
        private bool EnableServiceStatusReporting;
        private Int32 MonitoringInterval;
        [XmlElement("Resource")]
        private List<NetworkResource> NetworkResources;
        [XmlElement("SQLDatabase")]
        private List<SQLDatabase> SQLDatabases;

        #endregion

        #region Constants

        #endregion

        #region Constructors

        ///<summary> 
        ///Constructor: Class constructor method.
        ///</summary>
        ///<author> Dan Maul </author> <created> 20/06/2017 </created>
        ///<remarks></remarks>
        public ServiceConfiguration()
        {

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

    ///<summary> 
    ///Class: Service Configuration File Network Resource Class Object.
    ///</summary>
    ///<author> Dan Maul </author> <created> 20/06/2017 </created>
    ///<remarks></remarks>
    [Serializable]
    internal class NetworkResource
    {

        #region Implements

        #endregion

        #region Inherits

        #endregion

        #region Properties

        private string Identity;
        private string IPAddress;
        private NetworkResourceType Type;
        private bool EnableEmailAlerts;
        private bool EnableHeartbeat;

        #endregion

        #region Constants

        #endregion

        #region Constructors

        ///<summary> 
        ///Constructor: Class constructor method.
        ///</summary>
        ///<author> Dan Maul </author> <created> 20/06/2017 </created>
        ///<remarks></remarks>
        public NetworkResource()
        {

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

    ///<summary> 
    ///Class: Service Configuration File SQL Databsae Connection Class Object.
    ///</summary>
    ///<author> Dan Maul </author> <created> 20/06/2017 </created>
    ///<remarks></remarks>
    [Serializable]
    internal class SQLDatabase
    {

        #region Implements

        #endregion

        #region Inherits

        #endregion

        #region Properties

        private string Identity;
        private string ConnectionString;
        private string EncryptedConnectionString;
        private List<StoredProcedure> StoredProcedures;
        private List<DataTable> DataTables;

        #endregion

        #region Constants

        #endregion

        #region Constructors

        ///<summary> 
        ///Constructor: Class constructor method.
        ///</summary>
        ///<author> Dan Maul </author> <created> 20/06/2017 </created>
        ///<remarks></remarks>
        public SQLDatabase()
        {

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

    ///<summary> 
    ///Class: Service Configuration File SQL Database Connection Cached Datatable Configuration Class.
    ///</summary>
    ///<author> Dan Maul </author> <created> 20/06/2017 </created>
    ///<remarks></remarks>
    [Serializable]
    internal class DataTable
    {

        #region Implements

        #endregion

        #region Inherits

        #endregion

        #region Properties

        private string Identity;

        #endregion

        #region Constants

        #endregion

        #region Constructors

        ///<summary> 
        ///Constructor: Class constructor method.
        ///</summary>
        ///<author> Dan Maul </author> <created> 20/06/2017 </created>
        ///<remarks></remarks>
        public DataTable()
        {

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

    ///<summary> 
    ///Class: Service Configuration File SQL Database Connection Cached Stored Procedure Configuration Class.
    ///</summary>
    ///<author> Dan Maul </author> <created> 20/06/2017 </created>
    ///<remarks></remarks>
    [Serializable]
    internal class StoredProcedure
    {

        #region Implements

        #endregion

        #region Inherits

        #endregion

        #region Properties

        private string Identity;

        #endregion

        #region Constants

        #endregion

        #region Constructors

        ///<summary> 
        ///Constructor: Class constructor method.
        ///</summary>
        ///<author> Dan Maul </author> <created> 20/06/2017 </created>
        ///<remarks></remarks>
        public StoredProcedure()
        {

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

    namespace Cache
    {

        ///<summary> 
        ///Class: Service Configuration File Class Object.
        ///</summary>
        ///<author> Dan Maul </author> <created> 20/06/2017 </created>
        ///<remarks></remarks>
        public class ServiceConfigurationCache
        {
            #region Implements

            #endregion

            #region Inherits

            #endregion

            #region Properties

            public ServiceConfiguration ServiceConfigurartion;

            #endregion

            #region Constants

            #endregion

            #region Constructors

            ///<summary> 
            ///Constructor: Class constructor method.
            ///</summary>
            ///<author> Dan Maul </author> <created> 20/06/2017 </created>
            ///<remarks></remarks>
            public ServiceConfigurationCache()
            {

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

            ///<summary> 
            ///Subroutine: Initialises the instance of the Service Configuration Cache object, 
            ///reading configuration information from both the service configuration file and subsequent database instances.
            ///</summary>
            ///<author> Dan Maul </author> <created> 20/06/2017 </created>
            ///<remarks></remarks>
            public void Initialise()
            {

                try
                {
                    // TODO: Add code to initialise the configuration cache, need to determine assembly build type to identify target config folder.

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
        }

    }

}
