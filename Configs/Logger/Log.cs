using System;
using System.Collections.Generic;

namespace RDPClient.Configs.Logger
{
    public static class Log
    {
        public static Queue<string> Logs;
        static Log() => Logs = new Queue<string>();
        /// <summary>
        /// Вывод сообщения в логирование
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        public static void Push(string message)
            => Logs.Enqueue($"[{DateTime.Now.ToShortTimeString()}]: {message}");
    }
}
