#region Using
using NetworkResourceMonitor.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
#endregion

namespace NetworkResourceMonitor.WebApplication.Controllers
{

    ///<summary> 
    ///Class: Login View Controller Class.
    ///</summary>
    ///<author> Dan Maul </author> <created> 16/09/2017 </created>
    ///<remarks></remarks>
    public class LoginController : Controller
    {

        #region Properties

        #endregion

        #region Constants

        #endregion

        #region Constructors

        #endregion

        #region Destructors

        #endregion

        #region Event Handlers

        #endregion

        #region Public Functions/Subroutines

        ///<summary> 
        ///Function: Returns the requested Login page index view.
        ///</summary>
        ///<author> Dan Maul </author> <created> 16/09/2017 </created>
        ///<remarks></remarks>
        public ActionResult Index()
        {
            return View();
        }

        ///<summary> 
        ///Function: Validates the given user credentials against the local domain or machine, if they're valid, redirects the user to the
        ///homepage, if they're not, returns the user to the login screen.
        ///</summary>
        ///<author> Dan Maul </author> <created> 16/09/2017 </created>
        ///<param name="loginmodel"></param>
        ///<remarks></remarks>        
        public ActionResult Validate_User(LoginModel loginmodel)
        {
            try
            {
                using (PrincipalContext PrincipalContext = new PrincipalContext(ContextType.Machine, Environment.MachineName))
                {
                    // validate the credentials
                    if (PrincipalContext.ValidateCredentials(loginmodel.Username, loginmodel.Password, ContextOptions.Negotiate))
                    {
                        FormsAuthentication.SetAuthCookie(loginmodel.Username, true);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData.Add("Exception", "UnrecognisedUsernameOrPassword");
                        return View("Index");
                    }
                }
            }
            catch (Exception Exc)
            {
                TempData.Add("Exception", "ExceptionOccured");
                return View("Index");
            }
        }

        ///<summary>
        ///Function: Logs the current user out of the application and returns them to the login screen.
        ///</summary>
        ///<remarks>
        ///<author> Dan Maul </author> <created> 16/09/2017 </created>
        ///</remarks>
        [Authorize()]
        public ActionResult Logout()
        {
            DestroyUserSession();
            return RedirectToAction("Index");
        }

        #endregion

        #region Protected Functions/Subroutines

        #endregion

        #region Private Functions/Subroutines

        ///<summary> 
        ///Subroutine: Destroys the current user's session, as part of the logout process.
        ///</summary>
        ///<author> Dan Maul </author> <created> 16/09/2017 </created>
        ///<remarks></remarks>     
        private void DestroyUserSession()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
        }

        #endregion
    }
}