using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;
using RDPClient.Configs;
using RDPClient.Configs.Logger;
using RDPClient.Telegram;

namespace RDPClient.Forms.Dialogs
{
    public partial class SettingsNotifyForm : Form
    {
        /// <summary>
        /// Поле настроек
        /// </summary>
        public static SettingsConfig _config; 
        /// <summary>
        /// Поля для хранения токена и ID
        /// </summary>
        public string Token, Id; 

        public SettingsNotifyForm()
        {
            InitializeComponent();

            // Проверяем наличие файла "settings.json" в папке "Configs". Если файл существует, 
            // загружаем данные из него и восстанавливаем настройки, устанавливая значения токена и ID 
            // в соответствующие текстовые поля

            if (File.Exists(Path.Combine("Configs", "settings.json")))
            {
                var json = JsonConvert.DeserializeObject<SettingsConfig>(
                    File.ReadAllText(Path.Combine("Configs", "settings.json")));

                textBox_Token.Text = Token = json.Token; 
                textBox_Id.Text = Id = json.Id; 
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            // Создание нового экземпляра настроек и установка параметров
            _config = new SettingsConfig
            {
                Token = textBox_Token.Text,
                Id = textBox_Id.Text
            };
            _config.SaveToDisk();


            try
            {
                // Отправка СМС в Telegram для проверки работоспособности

                Bot.Send($"✅ Бот активирован.\n\nЯ буду тебе присылать информацию о смене порта на твоем сервере."); 
            }
            catch
            {
                Log.Push("Бот в Telegram неверно настроен"); 
            }
        }
    }

}
