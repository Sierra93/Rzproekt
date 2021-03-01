using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Rzproekt.Core;
using Rzproekt.Core.Data;
using Rzproekt.Models;
using Rzproekt.Services;

namespace Rzproekt.Controllers {
    /// <summary>
    /// Контроллер описывает авторизацию и регистрацию пользователей.
    /// </summary>
    [ApiController, Route("api/auth")]
    public class AuthController : ControllerBase {
        ApplicationDbContext _db;

        public AuthController(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод регистрирует пользователя, но сначала проверяет существует ли он уже.
        /// </summary>
        /// <param name="user">Объект модели с данными пользователя.</param>
        /// <returns>Статус регистрации.</returns>
        [HttpPost, Route("checkin")]
        public async Task<IActionResult> CheckIn([FromBody] UserDto user) {
            //return Ok("Пользователь успешно зарегистрирован");
            if (string.IsNullOrEmpty(user.Login) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.Email)) {
                throw new ArgumentNullException();
            }
            UserBase userBase = new UserService(_db);

            try {
                // Проверяет, есть ли пользователь с таким логином.
                await userBase.GetIdentityLogin(user.Login);

                // Проверяет, есть ли пользователь с таким email.
                await userBase.GetIdentityEmail(user.Email);

                string sPassword = user.Password;

                // Хэширует пароль в MD5.
                var hashPassword = await HashMD5Service.HashPassword(sPassword);
                user.Password = hashPassword;

                // Добавляет нового пользователя в БД.
                await userBase.Create(user);

                return Ok("Пользователь успешно зарегистрирован");
            }
            catch (ArgumentNullException ex) {
                throw new ArgumentNullException("Входные параметры не заполнены", ex.Message.ToString());
            }
        }

        /// <summary>
        /// Метод авторизует пользователя.
        /// </summary>
        /// <param name="input">Логин или email.</param>
        /// <param name="password">Пароль.</param>
        /// <returns>Статус авторизации.</returns>
        [HttpPost, Route("signin")]
        public async Task<IActionResult> SignIn([FromBody] UserDto user) {
            if (string.IsNullOrEmpty(user.Login) || string.IsNullOrEmpty(user.Password)) {
                throw new ArgumentException("Параметры не могут быть пустыми");
            }
            UserBase userBase = new UserService(_db);

            // Хэширует пароль для сравнения.
            var hashPassword = await HashMD5Service.HashPassword(user.Password);

            // Выбирает пароль пользователя из БД.
            bool getIdentityPassword = await userBase.GetUserPassword(user.Login, hashPassword);

            // Если пароль не совпадает с тем что в БД.
            if (!getIdentityPassword) {
                throw new ArgumentException("Логин или пароль не верен");
            }

            var isUser = await userBase.GetIdentity(user.Login);

            if (isUser != null) {
                var now = DateTime.UtcNow;
                var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: isUser.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

                var response = new {
                    access_token = encodedJwt,
                    username = isUser.Name,
                    url = "/back-office"
                };

                return Ok(response);
            }

            throw new ArgumentNullException("Пользователь не найден");
        }

        /// <summary>
        /// Метод выбирает пользователя из БД
        /// </summary>
        /// <param name = "input" ></ param >
        /// < param name="password"></param>
        /// <returns></returns>
        async Task<ClaimsIdentity> GetIdentity(string input, string password) {
            bool isEmail = input.Contains("@"); // Проверяет логин передан или email.

            if (isEmail) {
                var oUser = await _db.Users.Where(u => u.Login == input).FirstOrDefaultAsync();
                var claims = new List<Claim> {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, input)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            else {
                var oUser = await _db.Users.Where(u => u.Login == input).FirstOrDefaultAsync();
                var claims = new List<Claim> {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, input)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
        }

        /// <summary>
        /// Метод сравнивает пароли при авторизации хэшируя исходный с хэшем в БД.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        async Task<string> EqualsHash(string login) {
            try {
                string hashDb = "";
                bool isEmail = login.Contains("@"); // Проверяет логин передан или email.

                if (isEmail) {
                    var getHashPassword = await (from u in _db.Users
                                                 where u.Email == login
                                                 select u.Password).ToListAsync();

                    foreach (var el in getHashPassword) {
                        hashDb = el;
                    }
                }
                return hashDb;
            }
            catch (KeyNotFoundException ex) {
                throw new KeyNotFoundException($"Пользователь не найден {ex.Message}");
            }
            catch (ArgumentException ex) {
                throw new ArgumentException($"Пароль не верен {ex.Message}");
            }
        }
    }
}
