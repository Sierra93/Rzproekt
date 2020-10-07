using Rzproekt.Core;
using Rzproekt.Core.Data;
using Rzproekt.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Services {
    /// <summary>
    /// Сервис реализует методы сообщений.
    /// </summary>
    public class MessageService : MessageBase {
        ApplicationDbContext _db;

        public MessageService(ApplicationDbContext db) => _db = db;

        /// <summary>
        /// Метод реализует отправку сообщений.
        /// </summary>
        /// <param name="messageDto"></param>
        /// <returns></returns>
        public override Task Send(MessageDto messageDto) {
            throw new NotImplementedException();
        }
    }
}
