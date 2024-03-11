using Telegram.Bot;
using RDPClient.Forms.Dialogs;
using Telegram.Bot.Types.Enums;

namespace RDPClient.Telegram
{
    public static class Bot
    {
        /// <summary>
        /// Поле для использования Telegram API
        /// </summary>
        private static ITelegramBotClient botClient; 

        /// <summary>
        /// Форма для настроек уведомления
        /// </summary>
        private static SettingsNotifyForm form; // Форма для настроек уведомлений

        static Bot() => form = new SettingsNotifyForm();
        /// <summary>
        /// Отправка сообщений в Telegram
        /// </summary>
        /// <param name="message">Сообщение для отправки</param>
        public static void Send(string message)
        {
            botClient = new TelegramBotClient(form.Token); 

            foreach (var id in form.Id.Split(','))
                botClient.SendTextMessageAsync(id, message, ParseMode.Markdown);
        }
    }
}
