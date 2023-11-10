using SkipperBack3.DBImport;
using SkipperBack3.TokenUtils;
using System.IdentityModel.Tokens.Jwt;

namespace SkipperBack3.Model
{
    public class DbHelper
    {
        private SkipperDBContext _context/*EF_DataContext _context*/;

        public DbHelper(SkipperDBContext context)/*(EF_DataContext context)*/
        {
            _context = context;
        }

        public bool IsUserSaved(User user)
        {
            if (_context.Users.Any(x => x.Email.Equals(user.Email)))
                throw new Exception("Пользователь с такой почтой уже зарегестрирован");
            if (user.Uid != Guid.Empty)
            {
                if (_context.Users.Any(x => x.Uid.Equals(user.Uid)))
                    throw new Exception("Пользователь с таким UUID уже существует");
                else
                {
                    user.PasswordHash = Utilities.GetHashString(user.PasswordHash);
                    _context.Users.Add(user);
                    _context.SaveChanges();
                }
            }
            else
            {
                user.PasswordHash = Utilities.GetHashString(user.PasswordHash);
                _context.Users.Add(user);
                user.Uid = Guid.NewGuid();
                _context.SaveChanges();
            }
            return true;
        }

        public bool Authenticate(string email, string password, out string accessToken)
        {
            accessToken = null;
            var user = _context.Users.FirstOrDefault(x => x.Email.Equals(email));
            if (user != null && user.PasswordHash.Equals(Utilities.GetHashString(password)))
            {
                accessToken = TokenUtilities.GenerateAccessToken(user);
                var refreshToken = TokenUtilities.GenerateRefreshToken(user.Uid);
                _context.RefreshTokens.Add(refreshToken);
                user.RefreshTokens.Add(refreshToken);
                _context.Update(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }


        public void RemoveExpiredRefreshTokens(User user)
        {
            var expiredTokens = user.RefreshTokens.Where(x => x.ExpiresAt < DateTime.Now).ToList();
            _context.RefreshTokens.RemoveRange(expiredTokens);
            //_context.SaveChanges();
        }

        public string RefreshToken(User user, string token)
        {
            try
            {
                Guid userGuid = user.Uid;
                //TODO: по какой-то причине у пользователя 0 рефреш токенов
                var refreshToken = _context.RefreshTokens.OrderByDescending(x => x.ExpiresAt).FirstOrDefault(x => x.UserId == userGuid);
                //var refreshToken = user.RefreshTokens.Single(x => x.Token == token);
                if (!refreshToken.IsRevoked)
                {
                    var newRefreshToken = TokenUtilities.GenerateRefreshToken(user.Uid);
                    //user.RefreshTokens.Remove(refreshToken);
                    //user.RefreshTokens.Clear();
                    user.RefreshTokens.Add(newRefreshToken);
                    RemoveExpiredRefreshTokens(user);
                    //foreach (var tok in user.RefreshTokens)
                    _context.Update(user);
                    _context.SaveChanges();
                    var newAccessToken = TokenUtilities.GenerateAccessToken(user);
                    return newAccessToken;
                }
                else throw new Exception("Неверный статус токена обновления");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public User GetUserFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var userId = new Guid (jwtToken.Claims.FirstOrDefault(c => c.Type == "uuid")?.Value);
            var user = _context.Users.FirstOrDefault(u => u.Uid == userId);
            return user;
        }

        public User GetUserByID(Guid uid)
        {
            var user = _context.Users.FirstOrDefault(u => u.Uid == uid);
            return user;
        }


        public Category[] GetCategories()
        {
            var categories = _context.Categories
                .Select(c => new Category
                {
                    Id = c.Id,
                    Key = c.Key,
                    Name = c.Name,
                    Subcategories = c.Subcategories
                })
                .ToArray();

            return categories;
        }
        /*
        public void RefreshToken(string token, User user)
        {
            string refreshToken = user.RefreshTokens.Single(x => x.Token == token);
            if (refreshToken.IsRevoked)
            {
                TokenUtilities.RevokeChildTokens(refreshToken, user);
                _context.Update(user);
                _context.SaveChanges();
            }
            if (refreshToken.IsActive)
                throw new Exception("Неверный статус токена обновления");

            var newRefreshToken = ;
            user.RefreshTokens.Add(newRefreshToken);
            RemoveOldRefreshTokens(user);
            foreach (var token in user.RefreshTokens)
                _context.Update(user);
            _context.SaveChanges();
            var jwtToken = TokenUtilities.GenerateAccessToken(user);
            return jwtToken;
        }
        */
    }
}