using System.Web;
using System.Web.Optimization;

namespace NetworkResourceMonitor.WebApplication
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Script Bundles

            //Jquery Script Bundle
            bundles.Add(new ScriptBundle("~/Scripts/JQuery").Include(
                        "~/Content/Extensions/JQuery/jquery-3.2.1.min.js"));

            //Jquery Validate Script Bundle
            bundles.Add(new ScriptBundle("~/Scripts/JQueryValidate").Include(
                        "~/Content/Extensions/JQuery Validate/dist/jquery.validate.min.js",
                        "~/Content/Extensions/JQuery Validate/dist/additional-methods.min.js",
                        "~/Content/Extensions/JQuery Validate Unobtrusive/dist/jquery.validate.unobtrusive.min.js"));

            //Bootstrap Script Bundle
            bundles.Add(new ScriptBundle("~/Scripts/Bootstrap").Include(
                      "~/Content/Extensions/Bootstrap/js/bootstrap.js"));

            //Extensions Script Bundle
            bundles.Add(new ScriptBundle("~/Scripts/Extensions").Include(
                      "~/Content/Extensions/Moment/moment.js"));

            //Common Script Bundle
            bundles.Add(new ScriptBundle("~/Scripts/Common").Include(
                        "~/Content/Scripts/Common.js",
                        "~/Content/Scripts/Validation.js",
                        "~/Content/Scripts/SessionHandler.js"));

            //Login Script Bundle
            bundles.Add(new ScriptBundle("~/Scripts/Login").Include(
                        "~/Content/Scripts/Login.js"));

            //Style Bundles

            //Bootstrap Style Bundle
            bundles.Add(new StyleBundle("~/Styles/Bootstrap").Include(
                      "~/Content/Extensions/Bootstrap/css/bootstrap.css"));

            //Fontawesome Style Bundle
            bundles.Add(new StyleBundle("~/Styles/Fontawesome").Include(
                      "~/Content/Extensions/Font Awesome/css/font-awesome.css"));
        }
    }
}
