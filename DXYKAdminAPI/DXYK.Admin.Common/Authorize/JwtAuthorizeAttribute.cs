using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace DXYK.Admin.Common.Authorize
{
    public class JwtAuthorizeAttribute : AuthorizeAttribute
    {
        public const string JwtAuthenticationScheme = "JwtAuthenticationScheme";

        public JwtAuthorizeAttribute()
        {
            this.AuthenticationSchemes = JwtAuthenticationScheme;
        }
    }
}
