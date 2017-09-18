#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
#endregion

namespace NetworkResourceMonitor.WebApplication.Models
{
    public class LoginModel
    {

        #region Properties

        [Required(ErrorMessage = "Please enter a valid username.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter a valid password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        #endregion

        #region Constants

        #endregion

        #region Constructors

        ///<summary> 
        ///Constructor: Class constructor method.
        ///</summary>
        ///<author> Dan Maul </author> <created> 16/09/2017 </created>
        ///<remarks></remarks>
        public LoginModel() { }

        #endregion

        #region Destructors

        #endregion

        #region Event Handlers

        #endregion

        #region Public Functions/Subroutines

        #endregion

        #region Protected Functions/Subroutines

        #endregion

        #region Private Functions/Subroutines

        #endregion

    }
}