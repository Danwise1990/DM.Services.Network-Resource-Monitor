#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
#endregion

namespace DM.Services.NetworkResourceMonitor.BusinessLogic.Configuration
{

    ///<summary> 
    ///Class: Service Configuration File Root Class Object.
    ///</summary>
    ///<author> Dan Maul </author> <created> 20/06/2017 </created>
    ///<remarks></remarks>
    [Serializable]
    [XmlRoot("ServiceConfiguration")]
    public class ServiceConfiguration
    {
        #region Implements

        #endregion

        #region Inherits

        #endregion

        #region Properties

        public string Identity;
        public bool EnableEmailAlerts;
        public bool EnableEventLogging;
        public bool EnableDatabaseLogging;
        public bool MonitorLocalMachine;
        public Int32 MonitoringInterval;
        [XmlElement("NetworkResource")]
        public List<NetworkResource> NetworkResources;
        [XmlElement("SQLDatabase")]
        public List<SQLDatabase> SQLDatabases;

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
    [XmlRoot("NetworkResource")]
    public class NetworkResource
    {

        #region Implements

        #endregion

        #region Inherits

        #endregion

        #region Properties

        public string Identity;
        public string NetworkIdentity;
        public string IPAddress;
        public NetworkResourceType Type;
        public bool EnableEmailAlerts;
        public bool EnableHeartbeat;

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
    [XmlRoot("SQLDatabase")]
    public class SQLDatabase
    {

        #region Implements

        #endregion

        #region Inherits

        #endregion

        #region Properties

        public string Identity;
        [XmlElement(IsNullable = true)]
        public string ConnectionString;
        [XmlElement(IsNullable = true)]
        public string EncryptedConnectionString;
        [XmlElement("StoredProcedure")]
        public List<StoredProcedure> StoredProcedures;
        [XmlElement("DataTable")]
        public List<DataTable> DataTables;

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
    public class DataTable
    {

        #region Implements

        #endregion

        #region Inherits

        #endregion

        #region Properties

        public string Identity;
        public string Source;
        public DataTableSourceType SourceType;

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
    public class StoredProcedure
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

            public ServiceConfiguration ServiceConfiguration;
            public AssemblyBuildConfiguration BuildConfiguration;

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

            ///<summary> 
            ///Subroutine: Determines the current build configuration of the service assembly.
            ///</summary>
            ///<author> Dan Maul </author> <created> 21/06/2017 </created>
            ///<remarks></remarks>
            public void DetermineBuildConfiguration()
            {
                try
                {
#if DEBUG
                    BuildConfiguration = AssemblyBuildConfiguration.Debug;
#elif RELEASE
                    BuildConfiguration = AssemblyBuildConfiguration.Release;
#elif DEV
                    BuildConfiguration = AssemblyBuildConfiguration.Dev;
#elif QC
                    BuildConfiguration = AssemblyBuildConfiguration.QC;
#elif PRD
                    BuildConfiguration = AssemblyBuildConfiguration.PRD;
#else
                    throw (new Exception("Unable to determine assembly build configuration, initialisation failed."));
#endif

                }
                catch (Exception Exc)
                {
                    throw (Exc);
                }
                finally
                {

                }

            }

            ///<summary> 
            ///Subroutine: Iterates over and initialises cached data table resources for each SQL Database configured in the service configuration.
            ///</summary>
            ///<author> Dan Maul </author> <created> 23/06/2017 </created>
            ///<remarks></remarks>
            public void LoadCachedDataTables()
            {

                try
                {
                    
                }
                catch (Exception Exc)
                {
                    throw (Exc);
                }
                finally
                {

                }

            }

            ///<summary> 
            ///Subroutine: Iterates over and initialises cached data table resources for each SQL Database configured in the service configuration.
            ///</summary>
            ///<author> Dan Maul </author> <created> 23/06/2017 </created>
            ///<remarks></remarks>
            public void LoadCachedStoredProcedures()
            {

                try
                {

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
                    DetermineBuildConfiguration();

                    ServiceConfiguration = DataAccess.XML.Serialiser.DeserialiseToObject<ServiceConfiguration>(DataAccess.FileHandler.ReadFile($"{AppDomain.CurrentDomain.BaseDirectory}\\ServiceConfiguration.xml"));

                    LoadCachedDataTables();
                    LoadCachedStoredProcedures();

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
