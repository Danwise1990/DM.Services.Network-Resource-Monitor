#region Using
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Net.NetworkInformation;
using System.Xml.Serialization;
#endregion

namespace DM.Services.NetworkResourceMonitor.BusinessLogic
{

    namespace Network
    {
        ///<summary> 
        ///Class: Network Resource Handler Business Logic Class, handles various network resource interaction tasks for the application,
        ///including monitoring and polling tasks.
        ///</summary>
        ///<author> Dan Maul </author> <created> 06/07/2017 </created>
        ///<remarks></remarks>
        public class NetworkResourceHandler : IDisposable
        {

            #region Properties

            private Configuration.NetworkResource NetworkResource { get; set; }

            #endregion

            #region Constants

            #endregion

            #region Constructors

            ///<summary> 
            ///Constructor: Class constructor method.
            ///</summary>
            ///<author> Dan Maul </author> <created> 05/07/2017 </created>
            ///<param name="NetworkResource">The network resource object that the class will be handling.</param>
            ///<remarks></remarks>
            public NetworkResourceHandler(Configuration.NetworkResource NetworkResource)
            {
                this.NetworkResource = NetworkResource;

                if (NetworkResource.IPAddress == null)
                {
                    NetworkResource.IPAddress = ResolveHostname(NetworkResource.Hostname);
                }
            }

            #endregion

            #region Destructors

            ///<summary> 
            ///Destructor: Disposable Interface implementation method.
            ///</summary>
            ///<author> Dan Maul </author> <created> 05/07/2017 </created>
            ///<remarks></remarks>
            public void Dispose()
            {
            }

            #endregion

            #region Event Handlers

            #endregion

            #region Protected Functions/Subroutines

            #endregion

            #region Private Functions/Subroutines

            #endregion

            #region Public Functions/Subroutines

            ///<summary> 
            ///Function: Pings the currently configured network resource and returns the enum status of the ping.
            ///</summary>
            ///<author> Dan Maul </author> <created> 06/07/2017 </created>
            ///<remarks></remarks>
            public PingReply PingResource()
            {
                try
                {
                    using (Ping NetworkResourcePing = new Ping())
                    {
                        return NetworkResourcePing.Send(NetworkResource.IPAddress, NetworkResource.Timeout);
                    }
                }
                catch (Exception Exc)
                {
                    throw (Exc);
                }
            }

            ///<summary> 
            ///Function: Resolves the given hostname to an IP Address,.
            ///</summary>
            ///<author> Dan Maul </author> <created> 06/07/2017 </created>
            ///<param name="Hostname">The hostname to attempt to resolve.</param>
            ///<remarks></remarks>
            public static string ResolveHostname(string Hostname)
            {
                try
                {
                    return System.Net.Dns.GetHostAddresses(Hostname)[0].ToString();
                }
                catch(System.Net.Sockets.SocketException Exc)
                {
                    throw new Exception($"Unable to resolve hostname '{Hostname}' to an IP Address, no DNS entries were found.");
                }
            }

            #endregion
        }
    }

    namespace SQL
    {
        ///<summary> 
        ///Class: Database Handler Business Logic Class, handles various database interaction tasks for the application, including exception logging.
        ///</summary>
        ///<author> Dan Maul </author> <created> 05/07/2017 </created>
        ///<remarks></remarks>
        public class DatabaseHandler : IDisposable
        {

            #region Properties

            private Configuration.Cache.ServiceConfigurationCache ConfigurationCache { get; set; }

            #endregion

            #region Constants

            #endregion

            #region Constructors

            ///<summary> 
            ///Constructor: Class constructor method.
            ///</summary>
            ///<author> Dan Maul </author> <created> 05/07/2017 </created>
            ///<remarks></remarks>
            public DatabaseHandler(Configuration.Cache.ServiceConfigurationCache ConfigurationCache)
            {
                this.ConfigurationCache = ConfigurationCache;
            }

            #endregion

            #region Destructors

            ///<summary> 
            ///Destructor: Disposable Interface implementation method.
            ///</summary>
            ///<author> Dan Maul </author> <created> 05/07/2017 </created>
            ///<remarks></remarks>
            public void Dispose()
            {
            }

            #endregion

            #region Event Handlers

            #endregion

            #region Protected Functions/Subroutines

            #endregion

            #region Private Functions/Subroutines

            #endregion

            #region Public Functions/Subroutines

            ///<summary> 
            ///Function: Spawns and logs an application exception to the database.
            ///</summary>
            ///<author> Dan Maul </author> <created> 21/06/2017 </created>
            ///<param name="XMLString">String of XML to be deserialised into the target object.</param>
            ///<remarks></remarks>
            public void LogApplicationException(Exception ExceptionToLog)
            {
                try
                {
                    using (DataAccess.SQL.Database Database = new DataAccess.SQL.Database(ConfigurationCache.CachedSQLConnections["Transaction"].ConnectionString))
                    {
                        Database.ExecuteCachedStoredProcedure(ConfigurationCache.CachedSQLConnections["Transaction"].StoredProcedures["LogException"],
                                                              new List<object> { new EnterpriseObjects.ExceptionLog(ExceptionToLog, ConfigurationCache.ServiceConfiguration.InstanceID) });
                    }
                }

                catch (Exception Exc)
                {

                }
            }

            ///<summary> 
            ///Function: Converts the data in the given data table object into a list of objects of type T.
            ///</summary>
            ///<author> Dan Maul </author> <created> 06/07/2017 </created>
            ///<typeparam name="T">The type of object list to spawn from the data.</typeparam>
            ///<param name="DataTableToConvert">Data table whose rows are to be converted into a list of the given enterprise object type.</param>            
            ///<remarks></remarks>
            public static List<T> DataTableToEnterpriseObjects<T>(System.Data.DataTable DataTableToConvert)
            {

                List<T> EnterpriseObjects = null;
                T EnterpriseObject = default(T);

                try
                {
                    EnterpriseObjects = new List<T>();

                    foreach (System.Data.DataRow DataRow in DataTableToConvert.Rows)
                    {
                        EnterpriseObject = (T)Activator.CreateInstance(typeof(T));

                        foreach (PropertyInfo EnterpriseObjectProperty in EnterpriseObject.GetType().GetProperties(BindingFlags.DeclaredOnly |
                                                                                                                   BindingFlags.Public |
                                                                                                                   BindingFlags.Instance))
                        {
                            if ((DataRow.Table.Columns.Contains(EnterpriseObjectProperty.Name)) && !(DataRow.IsNull(EnterpriseObjectProperty.Name)))
                            {
                                EnterpriseObjectProperty.SetValue(EnterpriseObject, DataRow[EnterpriseObjectProperty.Name]);
                            }
                        }

                        EnterpriseObjects.Add(EnterpriseObject);
                    }

                    return EnterpriseObjects;

                }
                catch (Exception Exc)
                {
                    throw (Exc);
                }
            }

            ///<summary> 
            ///Function: Converts the data in the given data row object into an object of type T.
            ///</summary>
            ///<author> Dan Maul </author> <created> 06/07/2017 </created>
            ///<typeparam name="T">The type of object to spawn from the data.</typeparam>
            ///<param name="DataRowToConvert">The data row whose data is to be converted into the specified enterprise object type.</param>
            ///<remarks></remarks>
            public static T DataRowToEnterpriseObjects<T>(System.Data.DataRow DataRowToConvert)
            {

                T EnterpriseObject = default(T);

                try
                {
                    EnterpriseObject = (T)Activator.CreateInstance(typeof(T));

                    foreach (PropertyInfo EnterpriseObjectProperty in EnterpriseObject.GetType().GetProperties(BindingFlags.DeclaredOnly |
                                                                                                               BindingFlags.Public |
                                                                                                               BindingFlags.Instance))
                    {
                        if (!(DataRowToConvert.IsNull(EnterpriseObjectProperty.Name)))
                        {
                            EnterpriseObjectProperty.SetValue(EnterpriseObject, DataRowToConvert[EnterpriseObjectProperty.Name]);
                        }
                    }

                    return EnterpriseObject;

                }
                catch (Exception Exc)
                {
                    throw (Exc);
                }
            }

            #endregion
        }
    }

    namespace XML
    {
        ///<summary> 
        ///Class: XML Serialiser Class Object, contains data access utility functions used to serialise, manipulate and deserialise XML strings and objects.
        ///</summary>
        ///<author> Dan Maul </author> <created> 21/06/2017 </created>
        ///<remarks></remarks>
        public class Serialiser
        {

            #region Properties

            #endregion

            #region Constants

            #endregion

            #region Constructors

            ///<summary> 
            ///Constructor: Class constructor method.
            ///</summary>
            ///<author> Dan Maul </author> <created> 20/06/2017 </created>
            ///<remarks></remarks>
            public Serialiser()
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
            ///Function: Deserialises the given XML string data to the given target object type.
            ///</summary>
            ///<author> Dan Maul </author> <created> 21/06/2017 </created>
            ///<param name="XMLString">String of XML to be deserialised into the target object.</param>
            ///<param name="ObjectType">Target object type to attempt to desreialise the string into.</param>
            ///<remarks></remarks>
            public static T DeserialiseToObject<T>(string XMLString)
            {
                XmlSerializer XmlSerializer = null;
                try
                {
                    using (System.IO.TextReader TextReader = new System.IO.StringReader(XMLString))
                    {
                        XmlSerializer = new XmlSerializer(typeof(T));
                        return (T)XmlSerializer.Deserialize(TextReader);
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
