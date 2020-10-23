using Rzproekt.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Core {
    /// <summary>
    /// Базовый абстрактный класс описывает методы сообщений.
    /// </summary>
    public abstract class MessageBase {
        /// <summary>
        /// Метод реализует отправку сообщений.
        /// </summary>
        /// <param name="messageDto"></param>
        /// <returns></returns>
        public abstract Task<object> Send(MessageDto messageDto);
    }
}
