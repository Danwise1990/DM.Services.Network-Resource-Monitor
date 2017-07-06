#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
#endregion

namespace DM.Services.NetworkResourceMonitor.BusinessLogic.EnterpriseObjects
{
    ///<summary> 
    ///Class: Database Exception Log Class Object, spawned in exception scenarios as a way of logging exceptions to the database.
    ///</summary>
    ///<author> Dan Maul </author> <created> 05/07/2017 </created>
    ///<remarks></remarks>
    public class ExceptionLog
    {

        #region Implements

        #endregion

        #region Inherits

        #endregion

        #region Properties

        public string InstanceID { get; set; }
        public string ExceptionSource { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionMessage { get; set; }
        public string StackTrace { get; set; }

        #endregion

        #region Constants

        #endregion

        #region Constructors

        ///<summary> 
        ///Constructor: Class constructor method.
        ///</summary>
        ///<author> Dan Maul </author> <created> 05/07/2017 </created>
        ///<remarks></remarks>
        public ExceptionLog(Exception Exc, string InstanceID)
        {
            this.InstanceID = InstanceID;
            ExceptionSource = Exc.Source;
            ExceptionType = Exc.GetType().ToString();
            ExceptionMessage = Exc.Message;
            StackTrace = Exc.StackTrace;
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