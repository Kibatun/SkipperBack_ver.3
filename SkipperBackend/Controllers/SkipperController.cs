using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SkipperBack3.DBImport;
using SkipperBack3.Model;
using SkipperBack3.TokenUtils;
using System.IdentityModel.Tokens.Jwt;
using System.Text;



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

        [HttpGet]
        [Route("api/[controller]/GetMe")]
        public IActionResult GetMe()
        {
            try
            {
                ///https://github.com/inpad-ru/InpadPluginsProxy/blob/1.0.5/InpadPluginsProxy/Helpers/AuthorizeAttribute.cs
                ///https://github.com/inpad-ru/InpadPluginsProxy/blob/1.0.5/InpadPluginsProxy/Helpers/JwtMiddleware.cs
                var token = HttpContext.Request.Headers["Bearer"].FirstOrDefault()?.Split(" ").Last();


                var tokenHandler = new JwtSecurityTokenHandler();
                // min 16 characters
                var key = Encoding.UTF8.GetBytes(AuthOptions.KEY);
                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = securityKey,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "uuid").Value);
                var user = _db.GetUserByID(userId);
                var userBio = user.Bio;
                var userEmail = user.Email;
                var userFirsName = user.FirstName;
                var userImageURL = user.Avatar;
                var userLastName = user.LastName;
                var userPost = user.Post;

                var userInfo = new
                {
                    bio = userBio,
                    email = userEmail,
                    first_name = userFirsName,
                    image_url = userImageURL,
                    last_name = userLastName,
                    post = userPost
                };

                return Ok(userInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetUserById")]
        public IActionResult GetUserById(Guid uuid)
        {
            try
            {
                var userId = uuid;
                var user = _db.GetUserByID(userId);
                var userBio = user.Bio;
                var userEmail = user.Email;
                var userFirsName = user.FirstName;
                var userImageURL = user.Avatar;
                var userLastName = user.LastName;
                var userPost = user.Post;

                var userInfo = new
                {
                    bio = userBio,
                    email = userEmail,
                    first_name = userFirsName,
                    image_url = userImageURL,
                    last_name = userLastName,
                    post = userPost
                };

                return Ok(userInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}