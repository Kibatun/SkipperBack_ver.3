using Microsoft.AspNetCore.Mvc;
using SkipperBack3.DBImport;
using SkipperBack3.Model;
using SkipperBack3.TokenUtils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkipperBack3.Controllers
{
    public class LoginRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class TokenModel
    {
        public string token { get; set; }
    }

    [ApiController]
    public class SkipperAPIController : ControllerBase
    {
        private readonly DbHelper _db;

        public SkipperAPIController(SkipperDBContext skipper_DdataContext)
        {
            _db = new DbHelper(skipper_DdataContext);
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
        public IActionResult Login([FromBody] LoginRequestModel request)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                string accessToken;
                if (_db.Authenticate(request.Email, request.Password, out accessToken))
                {
                    return Ok(new
                    {
                        accessToken
                    });
                }
                else
                {
                    throw new Exception("Неправильное имя пользователя или пароль");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        /// <summary>
        /// Обновление токена доступа
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/[controller]/RefreshToken")]
        public IActionResult RefreshToken([FromBody] TokenModel tokenModel)
        {
            try
            {
                string token = tokenModel.token;
                if (TokenUtilities.isTokenValid(token))
                {
                    User user = _db.GetUserFromToken(token);
                    var refreshedAccessToken = _db.RefreshToken(user, token);
                    return Ok(new { accessToken = refreshedAccessToken });
                }
                else throw new Exception("Обновление токена не удалось");
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        /// <summary>
        /// Получить список всех категорий
        /// </summary>
        /// <returns>Массив объектов категорий</returns>
        [HttpGet]
        [Route("api/[controller]/GetCategories")]
        public IActionResult GetCategories()
        {
            try
            {
                Category[] categories = _db.GetCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}