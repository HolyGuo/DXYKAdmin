//*******************************
// Create By Holy Guo
// Date 2019-09-08 14:52
//*******************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using SmartSql.DyRepository;
using SmartSql.DyRepository.Annotations;
using DXYK.Admin.Entity;
using DXYK.Admin.Entity.Dto;

namespace DXYK.Admin.Repository
{
    ///<summary>
    /// 用户信息
    ///</summary>
    public interface IUserRepository 
    {

        ///<summary>
        /// 根据用户名密码登录
        ///</summary>
        [Statement(Id = "LoginIn")]
        UserDto LoginIn([Param("id")]string loginname,[Param("loginpwd")]string loginpwd);

        ///<summary>
        /// 根据用户名密码登录
        ///</summary>
        [Statement(Id = "LoginIn")]
        Task<UserDto> LoginInAsync([Param("id")]string loginname, [Param("loginpwd")]string loginpwd);
        
    }
}

