using System.Web;
using System.Web.Optimization;

namespace BrokerMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/Backend").Include(
                      "~/Scripts/js/Backend.js"));
            // Front end Scripts
        bundles.Add(new ScriptBundle("~/bundles/frontend").Include(
          "~/Content/_ui/js/bootstrap.min.js",
          "~/Content/_ui/js/jquery.flexslider-min.js"));
        bundles.Add(new ScriptBundle("~/bundles/unit").Include(
            "~/Content/_ui/js/unit/alert.js",
            "~/Content/_ui/js/unit/button.js",
            "~/Content/_ui/js/unit/carousel.js",
            "~/Content/_ui/js/unit/collapse.js",
            "~/Content/_ui/js/unit/dropdown.js",
            "~/Content/_ui/js/unit/modal.js",
            "~/Content/_ui/js/unit/scrollspy.js",
            "~/Content/_ui/js/unit/tab.js",
            "~/Content/_ui/js/unit/tooltip.js",
            "~/Content/_ui/js/unit/popover.js",
            "~/Content/_ui/js/unit/affix.js",
            "~/Content/_ui/js/unit/bootstrap-select.min.js"));
        bundles.Add(new ScriptBundle("~/bundles/Custom").Include(
            "~/Content/_ui/js/swiper.min.js",
            "~/Content/_ui/js/jquery.swipebox.min.js",
            "~/Content/_ui/js/bootstrap-v3.3.4.js",
            "~/Content/_ui/js/main.js",
            "~/Scripts/js/Frontend.js"));
            ///


            //bundles.Add(new ScriptBundle("~/bundles/jquiryUI").Include(
            //   "https://code.jquery.com/ui/1.12.1/jquery-ui.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/_ui/css/bootstrap.min.css",
                      "~/Content_ui/css/bootstrap-theme.min.css",
                      "~/Content/_ui/css/bootstrap-select.min.css",
                      "~/Content/_ui/css/font-awesome.min.css",
                      "~/Content/_ui/css/animate.min.css",
                      "~/Content/_ui/css/swiper.min.css",
                      "~/Content/_ui/css/swipebox.min.css",
                      "~/Content/_ui/css/main.css"));
            //bundles.Add(new StyleBundle("~/Content/jquiryUI").Include(
            // "//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"));
            bundles.Add(new StyleBundle("~/Backend/css").Include(
                "~/Content/Backend/css/bootstrap.min.css",
                "~/Content/Backend/css/Main.css"));
        }
    }
}
