using DXYK.Admin.Common.ConfigHelper;
using System;

namespace DXYK.Admin.Extensions.JWT.Config
{
    public class JwtAuthConfigModel : BaseConfigModel
    {
        /// <summary>
        /// 
        /// </summary>
        public JwtAuthConfigModel()
        {
            try
            {
                JWTSecretKey = ConfigExtensions.Configuration["JwtAuth:SecurityKey"];
                WebExp = double.Parse(ConfigExtensions.Configuration["JwtAuth:WebExp"]);
                AppExp = double.Parse(ConfigExtensions.Configuration["JwtAuth:AppExp"]);
                WxExp = double.Parse(ConfigExtensions.Configuration["JwtAuth:WxExp"]);
                OtherExp = double.Parse(ConfigExtensions.Configuration["JwtAuth:OtherExp"]);
                Issuer = ConfigExtensions.Configuration["JwtAuth:Issuer"];
                Audience = ConfigExtensions.Configuration["JwtAuth:Audience"];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        /// <summary>
        /// JWTSecretKey
        /// </summary>
        public string JWTSecretKey = "lyDqoSIQmyFcUhmmN4KBRGWWzm1ELC7owHVtStOu1YD7wYz";
        /// <summary>
        /// WebExp
        /// </summary>
        public double WebExp = 12;
        /// <summary>
        /// AppExp
        /// </summary>
        public double AppExp = 12;
        /// <summary>
        /// WxExp
        /// </summary>
        public double WxExp = 12;
        /// <summary>
        /// 
        /// </summary>
        public double OtherExp = 12;

        public string Issuer = "jwt";

        public string Audience = "jwt";
    }
}
