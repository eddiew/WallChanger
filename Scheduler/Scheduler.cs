using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;
using WallChanger;

namespace Scheduler
{
    partial class Scheduler : Form
    {
        private NotifyIcon NotifyIcon;
        private System.ComponentModel.IContainer components;
        private Button ChangeWallButton;
    
        public Scheduler()
        {
            InitializeComponent();
        }

        public static void Main(string[] args)
        {
            using (var taskService = new TaskService())
            {
                var td = taskService.NewTask();
                td.RegistrationInfo.Description =
                    "Fetches an image from wallbase.cc and sets it as the desktop background at fixed intervals";
                td.RegistrationInfo.Author = "Eddie Wang";
                td.Settings.StartWhenAvailable = true;
                var biHourly = new RegistrationTrigger{Repetition = {Interval = TimeSpan.FromMinutes(30)}};
                td.Triggers.Add(biHourly);
                td.Actions.Add(new ExecAction(WindowsOps.ExecutableDirectory + @"\WallChanger.exe"));
                taskService.RootFolder.RegisterTaskDefinition("WallChanger", td);
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scheduler));
            this.ChangeWallButton = new System.Windows.Forms.Button();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // ChangeWallButton
            // 
            this.ChangeWallButton.Location = new System.Drawing.Point(12, 12);
            this.ChangeWallButton.Name = "ChangeWallButton";
            this.ChangeWallButton.Size = new System.Drawing.Size(103, 23);
            this.ChangeWallButton.TabIndex = 0;
            this.ChangeWallButton.Text = "Change Wallpaper";
            this.ChangeWallButton.UseVisualStyleBackColor = true;
            this.ChangeWallButton.Click += new System.EventHandler(this.ChangeWallButton_Click);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "WallChanger";
            this.NotifyIcon.Visible = true;
            this.NotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // Scheduler
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(163, 79);
            this.ControlBox = false;
            this.Controls.Add(this.ChangeWallButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Scheduler";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.ResumeLayout(false);

        }

        private void ChangeWallButton_Click(object sender, EventArgs e)
        {
            Main(null);
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
