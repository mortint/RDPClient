using Newtonsoft.Json;
using System.IO;

namespace RDPClient.Configs
{
    public class SettingsConfig
    {
        /// <summary>
        /// Токен Telegram для авторизации
        /// </summary>
        [JsonProperty("token")] public string Token { get; set; }
        /// <summary>
        /// ID пользователя Telegram, кому бот будет отправлять сообщение 
        /// </summary>
        [JsonProperty("id")] public string Id { get; set; } 
        /// <summary>
        /// Сериализация полей в JSON файл
        /// </summary>
        public void SaveToDisk() => File.WriteAllText(Path.Combine("Configs", "settings.json"), JsonConvert.SerializeObject(this));
    }
}
