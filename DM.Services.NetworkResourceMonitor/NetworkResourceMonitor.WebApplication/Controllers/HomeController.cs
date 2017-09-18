#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
#endregion

namespace NetworkResourceMonitor.WebApplication.Controllers
{

    ///<summary> 
    ///Class: Home View Controller Class.
    ///</summary>
    ///<author> Dan Maul </author> <created> 16/09/2017 </created>
    ///<remarks></remarks>
    public class HomeController : Controller
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
        ///Function: Returns the requested Home page view.
        ///</summary>
        ///<author> Dan Maul </author> <created> 16/09/2017 </created>
        ///<remarks></remarks>
        [Authorize]
        public ActionResult Index()
        {


            return View();
        }

        #endregion

        #region Protected Functions/Subroutines

        #endregion

        #region Private Functions/Subroutines

        #endregion
    }
}