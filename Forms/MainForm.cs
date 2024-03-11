using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using RDPClient.Configs.Logger;
using RDPClient.Forms.Dialogs;
using RDPClient.Telegram;
using System.Diagnostics;

namespace RDPClient
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Таймер для выполнения задачи по расписанию
        /// </summary>
        private System.Timers.Timer Timer { get; set; }
        /// <summary>
        /// Индекс текущего порта из списка
        /// </summary>
        private int Index {  get; set; } = -1;
        /// <summary>
        /// Список портов, используемый для смены портов и настройки брандмауэра
        /// </summary>
        private List<string> Ports {  get; set; }
        /// <summary>
        /// Флаг для определения наличия запуска в автозагрузке
        /// </summary>
        private bool _autoUpload { get; set; } = false;
        public MainForm()
        {
            InitializeComponent();
            Timer = new System.Timers.Timer();

            Text += Application.ProductVersion;

            // Создание директории Configs для хранения данных/настроек приложения
            Directory.CreateDirectory("Configs");
        }

        private void TimerUpdate_Tick(object sender, EventArgs e)
        {
            while (Log.Logs.Count > 0)
            {
                textBox_Logger.Text = $"{ Log.Logs.Dequeue()}\n{textBox_Logger.Text}";
            }
        }

        private void button_SgowFormSettings_Click(object sender, EventArgs e)
        {
            var from = new SettingsNotifyForm();
            from.Show();
        }
        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                Index = (Index + 1) % Ports.Count;

                // Формирование PowerShell скриптов для изменения порта и настройки брандмауэра
                var changePortScript = $@"Set-ItemProperty -Path HKLM:\SYSTEM\CurrentControlSet\Control\Terminal*Server\WinStations\RDP-TCP\ -Name PortNumber -Value {Ports[Index]}";
                var firewallScript = $@"netsh advfirewall firewall add rule name=""NewRDP"" dir=in action=allow protocol=TCP localport={Ports[Index]}";
                var restartServiceScript = @"net stop TermService /yes; net start TermService /yes";

                // Добавление скриптов в сессию PowerShell
                var powerShell = PowerShell.Create();
                powerShell.AddScript(changePortScript);
                powerShell.AddScript(firewallScript);
                powerShell.AddScript(restartServiceScript);

                foreach (var output in powerShell.Invoke())
                {
                    Bot.Send($"*{output}*"); 
                }

                // Отправка уведомления в Telegram о смене порта на удаленном ПК
                Bot.Send($"🔄 Порт успешно изменен на *{Ports[Index]}*\n\n⏳ Интервал смены: {numericDelay.Value} мин.");
            }));
        }

        private void button_Run_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox_Ports.Text))
                {
                    Log.Push("Отсутствуют порты или поле содержит пробелы");
                    return;
                }

                button_Run.Text = "Запущено";
                Log.Push("Запущено. Логирование перенесено в Telegram.");

                var time = (int)numericDelay.Value * 60000;

                // Разделение текста из textBox_Ports по символу новой строки и удаление пустых элементов
                var ports = textBox_Ports.Text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                Ports = new List<string>();

                foreach (var port in ports)
                    Ports.Add(port);

                // Запуск таймера, установка интервала и привязка события
                Timer.Interval = time;
                Timer.Elapsed += OnTimeEvent;
                Timer.Start();
            }
            catch (Exception ex)
            {
                Log.Push($"[Error]: {ex.Message}"); 
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Проверка наличия приложения в автозагрузке при старте формы

                using (var registryKeyStartup = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    // Получаем значение из реестра по ключу "RDPClient"
                    var value = (string)registryKeyStartup.GetValue("RDPClient"); 

                    if (!string.IsNullOrEmpty(value)) 
                    {
                        _autoUpload = true;
                        button_AutoRun.Text = "Удалить из автозагрузки"; 
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Push($"[Error]: {ex.Message}"); 
            }
        }

        private void button_AutoRun_Click(object sender, EventArgs e)
        {
            // Константа "applicationName" содержит название приложения, которое будет добавлено или удалено из автозагрузки
            const string applicationName = "RDPClient";
            // Константа "pathRegistryKeyStartup" представляет путь к реестровому ключу, отвечающему за автозагрузку программ в Windows.
            const string pathRegistryKeyStartup = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

            try
            {
                // Добавление в автозагрузку Windows или удаление

                using (var registryKeyStartup = Registry.CurrentUser.OpenSubKey(pathRegistryKeyStartup, true))
                {
                    if (registryKeyStartup != null)
                    {
                        if (!_autoUpload)
                        {
                            registryKeyStartup.SetValue(applicationName, $"\"{System.Reflection.Assembly.GetExecutingAssembly().Location}\"");
                            button_AutoRun.Text = "Удалить из автозагрузки";
                            Log.Push("Приложение добавлено в автозагрузку Windows");
                        }
                        else
                        {
                            registryKeyStartup.DeleteValue(applicationName, false);
                            button_AutoRun.Text = "Добавить в автозагрузку";
                            Log.Push("Приложение удалено из автозагрузки Windows");
                        }

                        _autoUpload = !_autoUpload;
                    }
                    else
                    {
                        Log.Push("Не удалось получить доступ к реестру для автозагрузки");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Push($"[Error]: {ex.Message}");
            }
        }


        private void label_Report_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            => Process.Start("https://t.me/novikov_w");
        private void Form1_Shown(object sender, EventArgs e)
        {
            try
            {
                var random = new Random();

                // Получение доступа к ключу в реестре
                var key = Registry.LocalMachine.CreateSubKey(@"SYSTEM\CurrentControlSet\Control\Terminal Server\WinStations\RDP-Tcp");
                // Получение значения порта из реестра
                var portNumber = key.GetValue("PortNumber").ToString();

                // Переменная для хранения списка портов
                var listPorts = string.Empty; 

                for (int i = 0; i <= 10; i++) 
                {
                    listPorts += random.Next(int.Parse(portNumber), int.Parse(portNumber) + 10000) + "\r\n"; 
                }

                textBox_Ports.Text = listPorts; 
            }
            catch (Exception ex)
            {
                Log.Push($"[Error]: {ex.Message}"); 
            }
        }

    }
}
