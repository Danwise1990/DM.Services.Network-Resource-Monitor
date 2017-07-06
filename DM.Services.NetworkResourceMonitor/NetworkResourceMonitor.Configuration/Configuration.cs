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

        #region Properties

        public string InstanceID { get; set; }
        public bool EnableEmailAlerts { get; set; }
        public bool EnableEventLogging { get; set; }
        public bool EnableDatabaseLogging { get; set; }
        public bool MonitorLocalMachine { get; set; }
        public Int32 MonitoringInterval { get; set; }
        [XmlElement("NetworkResource")]
        public List<NetworkResource> NetworkResources { get; set; }
        [XmlElement("SQLDatabase")]
        public List<SQLConnection> SQLConnections { get; set; }

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
    ///Class: Service Configuration File SQL Databsae Connection Class Object.
    ///</summary>
    ///<author> Dan Maul </author> <created> 20/06/2017 </created>
    ///<remarks></remarks>
    [Serializable]
    [XmlRoot("SQLConnection")]
    public class SQLConnection
    {

        #region Properties

        public string Identity { get; set; }
        [XmlElement(IsNullable = true)]
        public string ConnectionString { get; set; }
        [XmlElement(IsNullable = true)]
        public string EncryptedConnectionString { get; set; }
        [XmlElement("StoredProcedure")]
        public List<StoredProcedure> StoredProcedures { get; set; }
        [XmlElement("DataTable")]
        public List<DataTable> DataTables { get; set; }

        #endregion

        #region Constants

        #endregion

        #region Constructors

        ///<summary> 
        ///Constructor: Class constructor method.
        ///</summary>
        ///<author> Dan Maul </author> <created> 20/06/2017 </created>
        ///<remarks></remarks>
        public SQLConnection()
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
    [XmlRoot("DataTable")]
    public class DataTable
    {

        #region Properties

        public string Identity { get; set; }
        public string Source { get; set; }
        public DataTableSourceType SourceType { get; set; }

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
    [XmlRoot("StoredProcedure")]
    public class StoredProcedure
    {

        #region Properties

        public string Identity { get; set; }
        public string Name { get; set; }

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

    ///<summary> 
    ///Class: Configuration Database Network Resource Record Class.
    ///</summary>
    ///<author> Dan Maul </author> <created> 06/07/2017 </created>
    ///<remarks></remarks>
    public class NetworkResource
    {

        #region Properties

        public string ResourceID { get; set; }
        public string Hostname { get; set; }
        public string IPAddress { get; set; }
        public string CredentialsID { get; set; }
        private NetworkResourceType _ResourceType { get; set; } //Private Enum property
        public string ResourceType
        {
            get
            {
                return _ResourceType.ToString();
            }
            set
            {
                _ResourceType = (NetworkResourceType)Enum.Parse(typeof(NetworkResourceType), value);
            }
        } //Public String-to-Enum property
        public bool EnableEmailAlerts { get; set; }
        public int Timeout { get; set; }
        public DateTime LastMonitored { get; set; }
        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }

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

    namespace Cache
    {

        ///<summary> 
        ///Class: Service Configuration File Class Object.
        ///</summary>
        ///<author> Dan Maul </author> <created> 20/06/2017 </created>
        ///<remarks></remarks>
        public class ServiceConfigurationCache
        {

            #region Properties

            public ServiceConfiguration ServiceConfiguration { get; set; }
            public Dictionary<string, CachedSQLConnection> CachedSQLConnections { get; set; }
            public AssemblyBuildConfiguration BuildConfiguration { get; set; }

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
            private void DetermineBuildConfiguration()
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

            }

            ///<summary> 
            ///Subroutine: Caches the currently configured SQL database connections defined in the Service Configuration file.
            ///</summary>
            ///<author> Dan Maul </author> <created> 26/06/2017 </created>
            ///<remarks></remarks>
            private void CacheSQLConnections()
            {

                CachedSQLConnection NewCachedSQLConnection = null;

                try
                {

                    CachedSQLConnections = new Dictionary<string, CachedSQLConnection>();

                    foreach (var SQLConnection in ServiceConfiguration.SQLConnections)
                    {
                        NewCachedSQLConnection = new CachedSQLConnection(SQLConnection.Identity, SQLConnection.ConnectionString);
                        NewCachedSQLConnection.CacheDataTables(SQLConnection.DataTables);
                        NewCachedSQLConnection.CacheStoredProcedures(SQLConnection.StoredProcedures);
                        CachedSQLConnections.Add(NewCachedSQLConnection.Identity, NewCachedSQLConnection);
                    }

                }
                catch (Exception Exc)
                {
                    throw (Exc);
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

                    ServiceConfiguration = XML.Serialiser.DeserialiseToObject<ServiceConfiguration>(DataAccess.FileHandler.ReadFile($"{AppDomain.CurrentDomain.BaseDirectory}\\ServiceConfiguration.xml"));

                    CacheSQLConnections();


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

        ///<summary> 
        ///Class: Cached SQL Connection Object Class, contains cached SQL Connection information to be held in the service configuration cache.
        ///</summary>
        ///<author> Dan Maul </author> <created> 26/06/2017 </created>
        ///<remarks></remarks>
        public class CachedSQLConnection
        {

            #region Properties

            public string Identity { get; set; }
            public string ConnectionString { get; set; }
            public Dictionary<string, System.Data.DataTable> DataTables { get; set; }
            public Dictionary<string, DataAccess.SQL.StoredProcedure> StoredProcedures { get; set; }

            #endregion

            #region Constants

            #endregion

            #region Constructors

            ///<summary> 
            ///Constructor: Class constructor method.
            ///</summary>
            ///<author> Dan Maul </author> <created> 26/06/2017 </created>
            ///<remarks></remarks>
            public CachedSQLConnection(string Identity, string ConnectionString)
            {
                this.Identity = Identity;
                this.ConnectionString = ConnectionString;
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
            ///Subroutine: Iterates over and initialises cached data table resources for each SQL Database configured in the service configuration.
            ///</summary>
            ///<author> Dan Maul </author> <created> 23/06/2017 </created>
            ///<remarks></remarks>
            public void CacheDataTables(List<DataTable> DataTablesToCache)
            {

                System.Data.DataTable NewDataTable = null;

                try
                {

                    DataTables = new Dictionary<string, System.Data.DataTable>();

                    foreach (DataTable DataTableToCache in DataTablesToCache)
                    {
                        using (var Database = new DataAccess.SQL.Database(ConnectionString))
                        {
                            switch (DataTableToCache.SourceType)
                            {
                                case DataTableSourceType.SQL:
                                    NewDataTable = Database.GetRecords(DataTableToCache.Source);
                                    break;
                                case DataTableSourceType.StoredProcedure:
                                    DataAccess.SQL.StoredProcedure DataSetStoredProcedure = new DataAccess.SQL.StoredProcedure(DataTableToCache.Source, ConnectionString);
                                    NewDataTable = Database.GetRecords(DataSetStoredProcedure);
                                    break;
                                default:
                                    break;
                            }

                            DataTables.Add(DataTableToCache.Identity, NewDataTable);
                        }
                    }
                }
                catch (Exception Exc)
                {
                    throw (Exc);
                }

            }

            ///<summary> 
            ///Subroutine: Iterates over and initialises cached data table resources for each SQL Database configured in the service configuration.
            ///</summary>
            ///<author> Dan Maul </author> <created> 23/06/2017 </created>
            ///<remarks></remarks>
            public void CacheStoredProcedures(List<StoredProcedure> StoredProceduresToCache)
            {

                DataAccess.SQL.StoredProcedure NewStoredProcedure = null;

                try
                {

                    StoredProcedures = new Dictionary<string, DataAccess.SQL.StoredProcedure>();

                    foreach (StoredProcedure StoredProcedureToCache in StoredProceduresToCache)
                    {
                        NewStoredProcedure = new DataAccess.SQL.StoredProcedure(StoredProcedureToCache.Name, ConnectionString);
                        StoredProcedures.Add(StoredProcedureToCache.Identity, NewStoredProcedure);
                    }
                }
                catch (Exception Exc)
                {
                    throw (Exc);
                }

            }

            #endregion
        }
    }
}
