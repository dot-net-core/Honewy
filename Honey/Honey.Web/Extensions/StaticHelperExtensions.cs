using Microsoft.AspNetCore.Mvc.Routing;
using System;

namespace Honey.Web.Extensions
{
    public static class StaticHelperExtensions
    { /// <summary>CSS cdn
      ///
      /// </summary>
      /// <param name="helper"></param>
      /// <param name="contentPath"></param>
      /// <returns></returns>
        public static string CdnCssContent(this UrlHelper helper, string contentPath)
        {
            return GetContent(helper, contentPath, "CSS");
        }

        /// <summary>JS cdn
        ///
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="contentPath"></param>
        /// <returns></returns>
        public static string CdnJsContent(this UrlHelper helper, string contentPath)
        {
            return GetContent(helper, contentPath, "JS");
        }

        /// <summary>img cdn
        ///
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="contentPath"></param>
        /// <returns></returns>
        public static string CdnImgContent(this UrlHelper helper, string contentPath)
        {
            return GetContent(helper, contentPath, "IMG");
        }

        private static string GetContent(this UrlHelper helper, string contentPath, string type)
        {
            var result = helper.Content(contentPath);
            //if (ConfigurationManager.AppSettings[$"CDN_{type}_Enable"].ToUpper() == "TRUE")
            //{
            //    result = ConfigurationManager.AppSettings[$"CDN_{type}_URL"]
            //             + contentPath.TrimStart('~');
            //}
            return result;
        }
    }
}
