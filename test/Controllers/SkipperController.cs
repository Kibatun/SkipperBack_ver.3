using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SkipperBack3.DBImport;
//using SkipperBack3.EFCore;
using SkipperBack3.Model;
using SkipperBack3.TokenUtils;
using Swashbuckle.AspNetCore.Annotations;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkipperBack3.Controllers
{
    [ApiController]
    public class ShoppingApiController : ControllerBase
    {
        private readonly DbHelper _db;

        public ShoppingApiController (ShopingPostgresContext skipper_DdataContext) /*(EF_DataContext eF_DataContext)*/
        {
            _db = new DbHelper(skipper_DdataContext);//(eF_DataContext);
        }
        /// <summary>
        /// Добавление пользователя в БД
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/[controller]/Register")]
        public IActionResult AddUser([FromBody] User user)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                bool isSaved = _db.IsUserSaved(user);
                if (isSaved)
                    return Ok(ResponseHandler.GetAppResponse(type, user));
                else return this.BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        /// <summary>
        /// Вход пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/[controller]/Login")]
        public IActionResult Login([FromBody] User user)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                string accesToken;
                if (_db.Authenticate(user, out accesToken))
                    return Ok(new
                    {
                        accessToken = accesToken
                    });
                else throw new Exception("Неправвильное имя пользователя или пароль");
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
                
        }
        
        [HttpPost]
        [Route("api/[controller]/RefreshToken")]
        public IActionResult RefreshToken([FromBody] string token)
        {
            try
            {
                if (TokenUtilities.isTokenValid(token))
                {
                    User user = _db.GetUserFromToken(token);
                var refreshedAccessToken = _db.RefreshToken(user,token);
                return Ok(new { accessToken = refreshedAccessToken });                    
                }
                else throw new Exception("Обновление токена не удалось");
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        
    }
}