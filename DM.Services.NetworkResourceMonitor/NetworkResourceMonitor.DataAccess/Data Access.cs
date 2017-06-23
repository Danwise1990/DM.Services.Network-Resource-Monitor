#region Using
using System;
using System.Collections.Generic;
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

    namespace XML
    {

        ///<summary> 
        ///Class: XML Serialiser Class Object, contains data access utility functions used to serialise, manipulate and deserialise XML strings and objects.
        ///</summary>
        ///<author> Dan Maul </author> <created> 21/06/2017 </created>
        ///<remarks></remarks>
        public class Serialiser
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

    namespace SQL
    {

        ///<summary> 
        ///Class: XML Serialiser Class Object, contains data access utility functions used to serialise, manipulate and deserialise XML strings and objects.
        ///</summary>
        ///<author> Dan Maul </author> <created> 21/06/2017 </created>
        ///<remarks></remarks>
        public class DatabaseHandler
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
            ///Constructor: Class constructor method.
            ///</summary>
            ///<author> Dan Maul </author> <created> 20/06/2017 </created>
            ///<remarks></remarks>
            public DatabaseHandler()
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
            public static System.Data.DataSet ExecuteStoredProcedure(string StoredProcedure)
            {

                System.Data.DataSet ResultSet = null;

                try
                {

                    return ResultSet;

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