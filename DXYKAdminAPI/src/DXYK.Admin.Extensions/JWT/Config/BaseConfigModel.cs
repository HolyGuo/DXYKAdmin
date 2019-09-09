using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DXYK.Admin.Extensions.JWT.Config
{
    public class BaseConfigModel
    {
        /// <summary>
        /// IConfiguration
        /// </summary>
        public static IConfiguration Configuration { get; set; }

        /// <summary>
        /// ContentRootPath
        /// </summary>

        public static string ContentRootPath { get; set; }

        /// <summary>
        /// WebRootPath
        /// </summary>

        public static string WebRootPath { get; set; }

        /// <summary>
        /// SetBaseConfig
        /// </summary>
        /// <param name="config"></param>
        /// <param name="contentRootPath"></param>
        /// <param name="webRootPath"></param>
        public static void SetBaseConfig(IConfiguration config, string contentRootPath, string webRootPath)
        {
            Configuration = config;
            ContentRootPath = contentRootPath;
            WebRootPath = webRootPath;
        }
    }
}
