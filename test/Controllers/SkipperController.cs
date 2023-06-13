using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SkipperBack3.EFCore;
using SkipperBack3.Model;
using SkipperBack3.TokenUtils;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SkipperBack3.Controllers
{
    [ApiController]
    public class ShoppingApiController : ControllerBase
    {
        private readonly DbHelper _db;

        public ShoppingApiController(EF_DataContext eF_DataContext)
        {
            _db = new DbHelper(eF_DataContext);
        }
        /*
        // GET: api/<ShoppingApiController>
        [HttpGet]
        [Route("api/[controller]/GetProducts")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<ProductModel> data = _db.GetProducts();

                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<ShoppingApiController>/5
        [HttpGet]
        [Route("api/[controller]/GetProductById/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                ProductModel data = _db.GetProductById(id);

                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<ShoppingApiController>
        [HttpPost]
        [Route("api/[controller]/SaveOrder")]
        public IActionResult Post([FromBody] OrderModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveOrder(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<ShoppingApiController>/5
        [HttpPut]
        [Route("api/[controller]/UpdateOrder")]
        public IActionResult Put([FromBody] OrderModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveOrder(model);
                return Ok(ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE api/<ShoppingApiController>/5
        [HttpDelete]
        [Route("api/[controller]/DeleteOrder/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteOrder(id);
                return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        */
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
                bool isSaved = _db.SaveUser(user);
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
                if (!_db.IsInputCorrect(user))
                    throw new Exception("Неправвильное имя пользователя или пароль");
                else
                {
                    string accessToken = TokenUtilities.GenerateToken(user.Email, "_da_ya_sosu_bibu1488");
                    string refreshToken = TokenUtilities.GenerateRefreshToken();
                    return Ok(new
                    {
                        access_token = accessToken,
                        refresh_token = refreshToken
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        /*
        [HttpPost]
        [Route("api/[controller]/RefreshToken")]
        public IActionResult RefreshToken([FromBody] RefreshToken refreshTokenRequest)
        {
            try
            {
                var refreshedAccessToken = RefreshToken(refreshTokenRequest.RefreshToken, "_da_ya_sosu_bibu1488");
                return Ok(new { AccessToken = refreshedAccessToken });
            }
            catch (SecurityTokenException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        */
    }
}