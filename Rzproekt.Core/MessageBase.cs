using Rzproekt.Models;
using System;
using System.Collections;
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

        /// <summary>
        /// Метод получает список всех диалогов.
        /// </summary>
        /// <returns></returns>
        public abstract Task<IList> GetDialogs();

        /// <summary>
        /// Метод получает сообщений диалога по его Id.
        /// </summary>
        public abstract Task<IList<DialogMessage>> GetDialogMessages(int dialogId);
    }
}
