using Rzproekt.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Core {
    /// <summary>
    /// Базовый абстрактный класс описывает работу с пользователями.
    /// </summary>
    public abstract class UserBase {
        /// <summary>
        /// Интерфейс описывает методы работы с пользователем.
        /// </summary>
        /// <summary>
        /// Метод проверяет, существует ли уже в БД такой логин.
        /// </summary>
        /// <param name="login"></param>
        public abstract Task<string> GetIdentityLogin(string login);

        /// <summary>
        /// Метод проверяет, существует ли уже в БД такой email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public abstract Task<string> GetIdentityEmail(string email);

        /// <summary>
        /// Метод выбирает пароль пользователя из БД.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public abstract Task<bool> GetUserPassword(string password);

        /// <summary>
        /// Метод получает email пользователя.
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public abstract dynamic GetUserEmail(string login);

        /// <summary>
        /// Метод проверяет формат даты.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public abstract bool IdentityEmailFormat(string email);

        /// <summary>
        /// Метод получает кол-во блогов пользователя.
        /// </summary>
        /// <returns></returns>
        public abstract Task<int> GetCountBlogs(string login);

        /// <summary>
        /// Провкеряет существование пользователя по login или email.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public abstract Task<ClaimsIdentity> GetIdentity(string input);

        /// <summary>
        /// Метод регистрарует нового пользователя.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public abstract Task Create(UserDto user);
    }
}

