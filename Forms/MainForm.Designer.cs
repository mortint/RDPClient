
namespace RDPClient
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Ports = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Logger = new System.Windows.Forms.RichTextBox();
            this.button_SgowFormSettings = new System.Windows.Forms.Button();
            this.button_AutoRun = new System.Windows.Forms.Button();
            this.button_Run = new System.Windows.Forms.Button();
            this.numericDelay = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.TimerUpdate = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_Report = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Список портов (один на строку)";
            // 
            // textBox_Ports
            // 
            this.textBox_Ports.Location = new System.Drawing.Point(12, 25);
            this.textBox_Ports.Name = "textBox_Ports";
            this.textBox_Ports.Size = new System.Drawing.Size(208, 400);
            this.textBox_Ports.TabIndex = 1;
            this.textBox_Ports.Text = "5212\n47914\n29491\n3801\n6932";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Логирование";
            // 
            // textBox_Logger
            // 
            this.textBox_Logger.Location = new System.Drawing.Point(226, 247);
            this.textBox_Logger.Name = "textBox_Logger";
            this.textBox_Logger.ReadOnly = true;
            this.textBox_Logger.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textBox_Logger.Size = new System.Drawing.Size(337, 178);
            this.textBox_Logger.TabIndex = 3;
            this.textBox_Logger.Text = "";
            // 
            // button_SgowFormSettings
            // 
            this.button_SgowFormSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_SgowFormSettings.Location = new System.Drawing.Point(307, 73);
            this.button_SgowFormSettings.Name = "button_SgowFormSettings";
            this.button_SgowFormSettings.Size = new System.Drawing.Size(154, 23);
            this.button_SgowFormSettings.TabIndex = 4;
            this.button_SgowFormSettings.Text = "Настройка уведомлений";
            this.button_SgowFormSettings.UseVisualStyleBackColor = true;
            this.button_SgowFormSettings.Click += new System.EventHandler(this.button_SgowFormSettings_Click);
            // 
            // button_AutoRun
            // 
            this.button_AutoRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_AutoRun.Location = new System.Drawing.Point(307, 102);
            this.button_AutoRun.Name = "button_AutoRun";
            this.button_AutoRun.Size = new System.Drawing.Size(154, 23);
            this.button_AutoRun.TabIndex = 6;
            this.button_AutoRun.Text = "Добавить в автозагрузку";
            this.button_AutoRun.UseVisualStyleBackColor = true;
            this.button_AutoRun.Click += new System.EventHandler(this.button_AutoRun_Click);
            // 
            // button_Run
            // 
            this.button_Run.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Run.Location = new System.Drawing.Point(307, 131);
            this.button_Run.Name = "button_Run";
            this.button_Run.Size = new System.Drawing.Size(154, 23);
            this.button_Run.TabIndex = 7;
            this.button_Run.Text = "Запустить";
            this.button_Run.UseVisualStyleBackColor = true;
            this.button_Run.Click += new System.EventHandler(this.button_Run_Click);
            // 
            // numericDelay
            // 
            this.numericDelay.Location = new System.Drawing.Point(307, 189);
            this.numericDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericDelay.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericDelay.Name = "numericDelay";
            this.numericDelay.Size = new System.Drawing.Size(154, 20);
            this.numericDelay.TabIndex = 8;
            this.numericDelay.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(465, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "мин.";
            // 
            // TimerUpdate
            // 
            this.TimerUpdate.Enabled = true;
            this.TimerUpdate.Interval = 1000;
            this.TimerUpdate.Tick += new System.EventHandler(this.TimerUpdate_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(304, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Частота смены порта";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(282, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(223, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Рекомендация: не чаще одного раза в час";
            // 
            // label_Report
            // 
            this.label_Report.AutoSize = true;
            this.label_Report.Location = new System.Drawing.Point(12, 429);
            this.label_Report.Name = "label_Report";
            this.label_Report.Size = new System.Drawing.Size(93, 13);
            this.label_Report.TabIndex = 12;
            this.label_Report.TabStop = true;
            this.label_Report.Text = "Сообщить о баге";
            this.label_Report.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.label_Report_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(575, 451);
            this.Controls.Add(this.label_Report);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericDelay);
            this.Controls.Add(this.button_Run);
            this.Controls.Add(this.button_AutoRun);
            this.Controls.Add(this.button_SgowFormSettings);
            this.Controls.Add(this.textBox_Logger);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Ports);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RDP Client v";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox textBox_Ports;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox textBox_Logger;
        private System.Windows.Forms.Button button_SgowFormSettings;
        private System.Windows.Forms.Button button_AutoRun;
        private System.Windows.Forms.Button button_Run;
        private System.Windows.Forms.NumericUpDown numericDelay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer TimerUpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel label_Report;
    }
}

