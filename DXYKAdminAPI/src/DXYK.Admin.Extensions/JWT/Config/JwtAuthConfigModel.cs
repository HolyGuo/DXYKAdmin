﻿using System;
using System.Collections.Generic;
using System.Text;

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
                JWTSecretKey = Configuration["JwtAuth:SecurityKey"];
                WebExp = double.Parse(Configuration["JwtAuth:WebExp"]);
                AppExp = double.Parse(Configuration["JwtAuth:AppExp"]);
                WxExp = double.Parse(Configuration["JwtAuth:WxExp"]);
                OtherExp = double.Parse(Configuration["JwtAuth:OtherExp"]);
                Issuer = Configuration["JwtAuth:Issuer"];
                Audience = Configuration["JwtAuth:Audience"];
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
