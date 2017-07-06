#region Using
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
#endregion

namespace DM.Services.NetworkResourceMonitor.DataAccess
{

    ///<summary> 
    ///Class: Data Access File Handler Class Object, contains data access utility functions used to access an manipulate the file system.
    ///</summary>
    ///<author> Dan Maul </author> <created> 21/06/2017 </created>
    ///<remarks></remarks>
    public class FileHandler
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
        public FileHandler()
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
        ///Function: Reads the text file at the specified fully-qualified filepath and returns the contents as a string.
        ///</summary>
        ///<author> Dan Maul </author> <created> 21/06/2017 </created>
        ///<remarks></remarks>
        public static string ReadFile(string FilePath)
        {

            try
            {
                using (System.IO.StreamReader StreamReader = new System.IO.StreamReader(FilePath))
                {
                    return StreamReader.ReadToEnd();
                }
            }

            catch (Exception Exc)
            {
                throw (Exc);
            }
        }

        ///<summary> 
        ///Function: Reads the XML file at the specified fully-qualified filepath and returns the contents as an XML document.
        ///</summary>
        ///<author> Dan Maul </author> <created> 21/06/2017 </created>
        ///<remarks></remarks>
        public static XmlDocument ReadXMLFile(string FilePath)
        {

            System.Xml.XmlDocument XMLDocument = null;

            try
            {
                using (System.IO.StreamReader StreamReader = new System.IO.StreamReader(FilePath))
                {
                    XMLDocument = new System.Xml.XmlDocument();
                    XMLDocument.LoadXml(StreamReader.ReadToEnd());
                    return XMLDocument;
                }
            }

            catch (Exception Exc)
            {
                throw (Exc);
            }
        }

        #endregion
    }

    namespace SQL
    {

        ///<summary> 
        ///Class: XML Serialiser Class Object, contains data access utility functions used to serialise, manipulate and deserialise XML strings and objects.
        ///</summary>
        ///<author> Dan Maul </author> <created> 21/06/2017 </created>
        ///<remarks></remarks>
        public class Database : IDisposable
        {

            #region Properties

            private string ConnectionString { get; set; }

            #endregion

            #region Constants

            #endregion

            #region Constructors

            ///<summary> 
            ///Constructor: Class constructor method.
            ///</summary>
            ///<author> Dan Maul </author> <created> 20/06/2017 </created>
            ///<remarks></remarks>
            public Database(string ConnectionString)
            {
                this.ConnectionString = ConnectionString;
            }

            #endregion

            #region Destructors

            ///<summary> 
            ///Destructor: Disposable Interface implementation method.
            ///</summary>
            ///<author> Dan Maul </author> <created> 26/06/2017 </created>
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

            ///<summary> 
            ///Function: Builds a SQLCommand object from the given cached stored procedure definition and parameter object.
            ///</summary>
            ///<author> Dan Maul </author> <created> 05/07/2017 </created>
            ///<param name="CachedStoredProcedure">The cached stored procedure to use when building the SQL Command.</param>
            ///<param name="SQLConnection">The connection to be used by the new SQL Command object when executing.</param>
            ///<param name="Timeout">The executing timeout value for the query in seconds.</param>
            ///<param name="ParameterObject">The enterprise object from which reflectively gather parameter values as defined in the cached stored procedure.</param>
            ///<remarks></remarks>
            private SqlCommand BuildSQLCommand(StoredProcedure CachedStoredProcedure, SqlConnection SQLConnection, int Timeout, object ParameterObject)
            {

                SqlCommand SQLCommand = null;

                try
                {
                    SQLCommand = new SqlCommand(CachedStoredProcedure.Name, SQLConnection);
                    SQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    SQLCommand.CommandTimeout = Timeout;
                    

                    if (ParameterObject != null)
                    {

                        foreach (KeyValuePair<string, System.Data.SqlDbType> Parameter in CachedStoredProcedure.Parameters)
                        {
                            foreach (PropertyInfo ParameterObjectProperty in ParameterObject.GetType().GetProperties(BindingFlags.DeclaredOnly |
                                                                                                            BindingFlags.Public |
                                                                                                            BindingFlags.Instance))
                            {
                                if (ParameterObjectProperty.Name == Parameter.Key)
                                {
                                    SQLCommand.Parameters.Add(new SqlParameter($"@{Parameter.Key}", ParameterObjectProperty.GetValue(ParameterObject)));
                                }
                            }
                        }
                    }

                    return SQLCommand;

                }
                catch (Exception Exc)
                {
                    throw (Exc);
                }
            }

            ///<summary> 
            ///Function: Builds a SQLCommand object from the given cached stored procedure definition and parameter object.
            ///</summary>
            ///<author> Dan Maul </author> <created> 05/07/2017 </created>
            ///<param name="CachedStoredProcedure">The cached stored procedure to use when building the SQL Command.</param>
            ///<param name="SQLConnection"></param>
            ///<remarks></remarks>
            private SqlCommand BuildSQLCommand(string SQLString, SqlConnection SQLConnection, int Timeout)
            {

                SqlCommand SQLCommand = null;

                try
                {
                    SQLCommand = new SqlCommand(SQLString, SQLConnection);
                    SQLCommand.CommandType = System.Data.CommandType.Text;
                    SQLCommand.CommandTimeout = Timeout;

                    return SQLCommand;

                }
                catch (Exception Exc)
                {
                    throw (Exc);
                }
            }

            #endregion

            #region Public Functions/Subroutines

            ///<summary> 
            ///Function: Executes the given stored procedure against the desired database, and returns the resultant data table.
            ///</summary>
            ///<author> Dan Maul </author> <created> 21/06/2017 </created>
            ///<param name="StoredProcedureName">The database name of the stored procedure you wish to execute.</param>
            ///<remarks></remarks>
            public System.Data.DataTable GetRecords(StoredProcedure StoredProcedure)
            {

                System.Data.DataSet ResultSet = null;

                try
                {
                    using (var SQLConnection = new SqlConnection(ConnectionString))
                    {
                        using (var SQLCommand = BuildSQLCommand(StoredProcedure, SQLConnection, 10, null))
                        {
                            SQLCommand.Connection = SQLConnection;

                            using (var SQLAdapter = new SqlDataAdapter(SQLCommand))
                            {

                                ResultSet = new System.Data.DataSet();

                                SQLConnection.Open();
                                SQLAdapter.Fill(ResultSet);
                                SQLConnection.Close();
                            }

                        }
                    }

                    return ResultSet.Tables[0];

                }
                catch (Exception Exc)
                {
                    throw (Exc);
                }
            }

            ///<summary> 
            ///Function: Executes the given stored procedure against the desired database, and returns the resultant data table.
            ///</summary>
            ///<author> Dan Maul </author> <created> 21/06/2017 </created>
            ///<param name="StoredProcedureName">The database name of the stored procedure you wish to execute.</param>
            ///<param name="EnterpriseObject">Enterprise object which reflectively provides the parameters for the SQL command.</param>
            ///<remarks></remarks>
            public System.Data.DataTable GetRecords(StoredProcedure StoredProcedure, object ParameterObject)
            {

                System.Data.DataSet ResultSet = null;

                try
                {
                    using (var SQLConnection = new SqlConnection(ConnectionString))
                    {
                        using (var SQLCommand = BuildSQLCommand(StoredProcedure, SQLConnection, 10, ParameterObject))
                        {

                            SQLCommand.Connection = SQLConnection;

                            using (var SQLAdapter = new SqlDataAdapter(SQLCommand))
                            {
                                SQLConnection.Open();
                                SQLAdapter.Fill(ResultSet);
                                SQLConnection.Close();
                            }

                        }
                    }

                    return ResultSet.Tables[0];

                }
                catch (Exception Exc)
                {
                    throw (Exc);
                }
            }

            ///<summary> 
            ///Function: Executes the given stored procedure against the desired database, and returns the resultant data set.
            ///</summary>
            ///<author> Dan Maul </author> <created> 21/06/2017 </created>
            ///<param name="StoredProcedureName">The database name of the stored procedure you wish to execute.</param>
            ///<remarks></remarks>
            public System.Data.DataTable GetRecords(string SQLString)
            {

                System.Data.DataSet ResultSet = null;

                try
                {
                    using (var SQLConnection = new SqlConnection(this.ConnectionString))
                    {
                        using (var SQLCommand = new SqlCommand(SQLString, SQLConnection))
                        {
                            SQLCommand.CommandType = System.Data.CommandType.Text;

                            using (var SQLAdapter = new SqlDataAdapter(SQLCommand))
                            {
                                SQLConnection.Open();
                                SQLAdapter.Fill(ResultSet);
                                SQLConnection.Close();
                            }
                        }
                    }

                    return ResultSet.Tables[0];

                }
                catch (Exception Exc)
                {
                    throw (Exc);
                }
            }

            ///<summary> 
            ///Function: Takes a stored procedure name and retrieves it's list of parameters from database metadata.
            ///</summary>
            ///<author> Dan Maul </author> <created> 21/06/2017 </created>
            ///<param name="StoredProcedureName">The database name of the stored procedure you wish to execute.</param>
            ///<remarks></remarks>
            public SqlParameterCollection GetStoredProcedureParameters(string StoredProcedureName)
            {
                try
                {
                    using (var SQLConnection = new SqlConnection(this.ConnectionString))
                    {
                        using (var SQLCommand = new SqlCommand(StoredProcedureName, SQLConnection))
                        {
                            SQLCommand.CommandType = System.Data.CommandType.StoredProcedure;

                            SQLConnection.Open();
                            SqlCommandBuilder.DeriveParameters(SQLCommand);
                            SQLConnection.Close();

                            return SQLCommand.Parameters;
                        }
                    }
                }
                catch (Exception Exc)
                {
                    throw (Exc);
                }
            }

            ///<summary> 
            ///Function: Executes the given cached stored procedure against the database for each of the given parameter objects.
            ///</summary>
            ///<author> Dan Maul </author> <created> 05/07/2017 </created>
            ///<param name="StoredProcedure">The stored procedure that you wish to execute.</param>
            ///<param name="EnterpriseObject">The enterprise object to be used when reflectively populating the stored procedure's parameters.</param>
            ///<remarks></remarks>
            public bool ExecuteCachedStoredProcedure(StoredProcedure StoredProcedure, List<object> ParameterObjects)
            {
                try
                {
                    using (var SQLConnection = new SqlConnection(ConnectionString))
                    {
                        foreach (object ParameterObject in ParameterObjects)
                        {
                            using (var SQLCommand = BuildSQLCommand(StoredProcedure, SQLConnection, 10, ParameterObject))
                            {
                                SQLCommand.Connection = SQLConnection;

                                SQLConnection.Open();
                                SQLCommand.ExecuteNonQuery();
                                SQLConnection.Close();
                            }
                        }
                    }

                    return true;

                }
                catch (Exception Exc)
                {
                    throw (Exc);
                }
            }

            #endregion
        }

        ///<summary> 
        ///Class: Cached SQL Stored Procedure Object Class, contains cached stored procedure parameter information to be held in the service configuration cache.
        ///</summary>
        ///<author> Dan Maul </author> <created> 29/06/2017 </created>
        ///<remarks></remarks>
        public class StoredProcedure
        {

            #region Properties

            public string Name { get; set; }
            public Dictionary<string, System.Data.SqlDbType> Parameters { get; set; }

            #endregion

            #region Constants

            #endregion

            #region Constructors

            ///<summary> 
            ///Constructor: Class constructor method.
            ///</summary>
            ///<author> Dan Maul </author> <created> 26/06/2017 </created>
            ///<remarks></remarks>
            public StoredProcedure(string Name, string ConnectionString)
            {
                this.Name = Name;
                GetParameters(ConnectionString);
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
            ///Subroutine: Populates the cached stored procedure with parameters from the database at the specified connection.
            ///</summary>
            ///<author> Dan Maul </author> <created> 29/06/2017 </created>
            ///<param name="ConnectionString">Connection string to the SQL database on which the stored procedure resides</param>
            ///<remarks></remarks>
            private void GetParameters(string ConnectionString)
            {

                Parameters = new Dictionary<string, System.Data.SqlDbType>();

                try
                {
                    using (var Database = new Database(ConnectionString))
                    {
                        foreach (SqlParameter Parameter in Database.GetStoredProcedureParameters(Name))
                        {
                            Parameters.Add(Parameter.ParameterName.Replace("@",""), Parameter.SqlDbType);
                        }
                    }
                }
                catch (Exception Exc)
                {
                    throw (Exc);
                }
            }

            #endregion

            #region Public Functions/Subroutines

            #endregion

        }

    }
}