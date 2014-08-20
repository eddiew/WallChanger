using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;
using WallChanger;

namespace Scheduler
{
    partial class Scheduler : Form
    {
        private NotifyIcon notifyIcon;
        private System.ComponentModel.IContainer components;
        private Button changeWallButton;
    
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
                var biHourly = new TimeTrigger{Repetition = {Interval = TimeSpan.FromMinutes(30)}};
                td.Triggers.Add(biHourly);
                td.Actions.Add(new ExecAction(WindowsOps.ExecutableDirectory + @"\WallChanger.exe"));
                taskService.RootFolder.RegisterTaskDefinition("WallChanger", td).Run();
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scheduler));
            this.changeWallButton = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // changeWallButton
            // 
            this.changeWallButton.Location = new System.Drawing.Point(12, 12);
            this.changeWallButton.Name = "changeWallButton";
            this.changeWallButton.Size = new System.Drawing.Size(103, 23);
            this.changeWallButton.TabIndex = 0;
            this.changeWallButton.Text = "Change Wallpaper";
            this.changeWallButton.UseVisualStyleBackColor = true;
            this.changeWallButton.Click += new System.EventHandler(this.ChangeWallButton_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "WallChanger";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // Scheduler
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(163, 79);
            this.ControlBox = false;
            this.Controls.Add(this.changeWallButton);
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
