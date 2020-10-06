using Microsoft.EntityFrameworkCore;
using Rzproekt.Core;
using Rzproekt.Core.Data;
using Rzproekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Services {
    public class UserService : UserBase {
        ApplicationDbContext _db;

        public UserService(ApplicationDbContext db) => _db = db;

        public async override Task<string> GetIdentityLogin(string login) {
            if (string.IsNullOrEmpty(login)) {
                throw new ArgumentNullException("Логин не передан");
            }

            // Проверяет, есть ли пользователь с таким логином.
            var isUser = await _db.Users.Where(u => u.Login == login).FirstOrDefaultAsync();

            if (isUser != null) {
                throw new ArgumentException("Пользователь с таким логином уже существует");
            }

            return "Логин свободен";
        }

        public async override Task<string> GetIdentityEmail(string email) {
            if (string.IsNullOrEmpty(email)) {
                throw new ArgumentNullException("Логин не передан");
            }

            // Проверяет, есть ли пользователь с таким email.
            var isUser = await _db.Users.Where(u => u.Email.Equals(email)).FirstOrDefaultAsync();

            if (isUser != null) {
                throw new ArgumentException("Такой email уже существует");
            }

            return "Email свободен";
        }

        /// <summary>
        /// Метод проверяет пароль пользователя.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public async override Task<bool> GetUserPassword(string password) {
            var oUser = await _db.Users.Where(u => u.Password.Equals(password)).FirstOrDefaultAsync();

            if (oUser == null) {
                return false;
            }

            return true;
        }

        public override dynamic GetUserEmail(string login) {
            throw new NotImplementedException();
        }

        public override bool IdentityEmailFormat(string email) {
            throw new NotImplementedException();
        }

        public override Task<int> GetCountBlogs(string login) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Провкеряет существование пользователя по login или email.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async override Task<ClaimsIdentity> GetIdentity(string input) {
            bool isEmail = input.Contains("@"); // Проверяет логин передан или email.

            if (isEmail) {
                var isUser = await _db.Users.Where(u => u.Email.Equals(input)).FirstOrDefaultAsync();

                var claims = new List<Claim> {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, input)
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

                return claimsIdentity;
            }
            else {
                var isUser = await _db.Users.Where(u => u.Login.Equals(input)).FirstOrDefaultAsync();

                var claims = new List<Claim> {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, input)
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

                return claimsIdentity;
            }
        }

        /// <summary>
        /// Метод регистрарует нового пользователя.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async override Task Create(UserDto user) {
            try {
                if (string.IsNullOrEmpty(user.Login) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password)) {
                    throw new ArgumentNullException();
                }

                await _db.Users.AddRangeAsync(user);
                await _db.SaveChangesAsync();
            }
            catch (ArgumentNullException ex) {
                throw new ArgumentNullException("Не заполнены обязательные поля", ex.Message.ToString());
            }
            catch (Exception ex) {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
