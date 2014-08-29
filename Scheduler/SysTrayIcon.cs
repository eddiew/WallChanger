using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;
using WallChanger;

namespace Scheduler
{
    public class SysTrayIcon : Form
    {
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem changeToolStripMenuItem;
        private ToolStripMenuItem autoToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private System.ComponentModel.IContainer components;
        private readonly Task wallChangerTask;

        public SysTrayIcon(Task wallChangerTask)
        {
            this.wallChangerTask = wallChangerTask;
            InitializeComponent();
        }

        // ReSharper disable RedundantThisQualifier, RedundantNameQualifier, RedundantCast, RedundantDelegateCreation
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysTrayIcon));
            // ReSharper disable 
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "Wall Changer";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Wall Changer";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeToolStripMenuItem,
            this.autoToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(137, 92);
            // 
            // changeToolStripMenuItem
            // 
            this.changeToolStripMenuItem.Name = "changeToolStripMenuItem";
            this.changeToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.changeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.changeToolStripMenuItem.ShowShortcutKeys = false;
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.changeToolStripMenuItem.Text = "Change Now";
            this.changeToolStripMenuItem.ToolTipText = "Change wallpaper now";
            this.changeToolStripMenuItem.Click += new System.EventHandler(this.changeToolStripMenuItem_Click);
            // 
            // autoToolStripMenuItem
            // 
            this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            this.autoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.autoToolStripMenuItem.ShowShortcutKeys = false;
            this.autoToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.autoToolStripMenuItem.Text = wallChangerTask.Enabled? "Pause" : "Resume";
            this.autoToolStripMenuItem.ToolTipText = (wallChangerTask.Enabled? "Pause" : "Resume") + " auto-change";
            this.autoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.optionsToolStripMenuItem.ShowShortcutKeys = false;
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.ToolTipText = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exitToolStripMenuItem.ShowShortcutKeys = false;
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.ToolTipText = "Quit Wall Changer and stop auto-changing";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // SysTrayIcon
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(433, 781);
            this.ControlBox = false;
            this.Enabled = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SysTrayIcon";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        // ReSharper restore RedundantThisQualifier, RedundantNameQualifier, RedundantCast, RedundantDelegateCreation

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            // l33t reflection haxx
            MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
            mi.Invoke(notifyIcon, null);
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wallChangerTask.Enabled)
            {
                wallChangerTask.Run();
            }
            else
            {
                wallChangerTask.Enabled = true;
                wallChangerTask.Run();
                wallChangerTask.Enabled = false;
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(WindowsOps.DocumentsDirectory);
        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wallChangerTask.Enabled)
            {
                wallChangerTask.Enabled = false;
                autoToolStripMenuItem.Text = "Resume";
                autoToolStripMenuItem.ToolTipText = "Resume auto-change";
            }
            else
            {
                wallChangerTask.Enabled = true;
                autoToolStripMenuItem.Text = "Pause";
                autoToolStripMenuItem.ToolTipText = "Pause auto-change";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wallChangerTask.Stop();
            notifyIcon.Visible = false;
            Application.Exit();
        }
    }
}
