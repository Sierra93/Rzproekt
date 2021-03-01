using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rzproekt.Services {
    /// <summary>
    /// Класс работы с SignalR.
    /// </summary>
    public class ChatHub : Hub {
        /// <summary>
        /// Метод отправляет сообщение на фронт.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        //public async Task Send(string message) {
        //    await Clients.All.SendAsync("Send", message);
        //}
    }
}