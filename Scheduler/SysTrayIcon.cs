﻿using System;
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
        private TabPage generalPage;
        private SplitContainer splitContainer2;
        private TabPage schedulingPage;
        private SplitContainer splitContainer1;
        private CheckBox hiResInput;
        private Label label1;
        private TextBox tagInput;
        private ListView tagList;
        private CheckBox sketchyInput;
        private Label label3;
        private Label label9;
        private CheckBox weabooInput;
        private CheckBox nsfwInput;
        private Label label2;
        private TextBox excludeInput;
        private TextBox minHeightInput;
        private TextBox minWidthInput;
        private ListView excludeList;
        private Label label10;
        private NumericUpDown samplesInput;
        private Label label4;
        private Label label12;
        private NumericUpDown intervalInput;
        private Label label11;
        private TabControl tabControl;
        private Label label5;
        private Label label6;
        private NumericUpDown numericUpDown1;
        private CheckBox batteryOnlyInput;
        private CheckBox startupInput;
        private readonly Task wallChangerTask;

        public SysTrayIcon(Task wallChangerTask)
        {
            this.wallChangerTask = wallChangerTask;
            InitializeComponent();
            Application.ApplicationExit += OnApplicationExit;
        }

        // ReSharper disable RedundantThisQualifier, RedundantNameQualifier, RedundantCast, RedundantDelegateCreation
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysTrayIcon));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalPage = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.batteryOnlyInput = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.schedulingPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.hiResInput = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tagInput = new System.Windows.Forms.TextBox();
            this.tagList = new System.Windows.Forms.ListView();
            this.sketchyInput = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.weabooInput = new System.Windows.Forms.CheckBox();
            this.nsfwInput = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.excludeInput = new System.Windows.Forms.TextBox();
            this.minHeightInput = new System.Windows.Forms.TextBox();
            this.minWidthInput = new System.Windows.Forms.TextBox();
            this.excludeList = new System.Windows.Forms.ListView();
            this.label10 = new System.Windows.Forms.Label();
            this.samplesInput = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.intervalInput = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.startupInput = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip.SuspendLayout();
            this.generalPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.schedulingPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.samplesInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalInput)).BeginInit();
            this.tabControl.SuspendLayout();
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
            this.changeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.changeToolStripMenuItem.Text = "Change Now";
            this.changeToolStripMenuItem.ToolTipText = "Change wallpaper now";
            this.changeToolStripMenuItem.Click += new System.EventHandler(this.changeToolStripMenuItem_Click);
            // 
            // autoToolStripMenuItem
            // 
            this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            this.autoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.autoToolStripMenuItem.ShowShortcutKeys = false;
            this.autoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.autoToolStripMenuItem.Text = "Pause";
            this.autoToolStripMenuItem.ToolTipText = "Pause auto-change";
            this.autoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.optionsToolStripMenuItem.ShowShortcutKeys = false;
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.optionsToolStripMenuItem.Text = "Settings";
            this.optionsToolStripMenuItem.ToolTipText = "Open settings menu";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exitToolStripMenuItem.ShowShortcutKeys = false;
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.ToolTipText = "Quit Wall Changer and stop auto-changing";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // generalPage
            // 
            this.generalPage.Controls.Add(this.splitContainer2);
            this.generalPage.Location = new System.Drawing.Point(4, 22);
            this.generalPage.Name = "generalPage";
            this.generalPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalPage.Size = new System.Drawing.Size(446, 275);
            this.generalPage.TabIndex = 2;
            this.generalPage.Text = "General";
            this.generalPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.batteryOnlyInput);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.startupInput);
            this.splitContainer2.Panel2.Controls.Add(this.label6);
            this.splitContainer2.Panel2.Controls.Add(this.numericUpDown1);
            this.splitContainer2.Size = new System.Drawing.Size(440, 269);
            this.splitContainer2.SplitterDistance = 220;
            this.splitContainer2.TabIndex = 0;
            // 
            // batteryOnlyInput
            // 
            this.batteryOnlyInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.batteryOnlyInput.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.batteryOnlyInput.Location = new System.Drawing.Point(3, 26);
            this.batteryOnlyInput.Name = "batteryOnlyInput";
            this.batteryOnlyInput.Size = new System.Drawing.Size(214, 17);
            this.batteryOnlyInput.TabIndex = 22;
            this.batteryOnlyInput.Text = "Auto Change on Battery";
            this.batteryOnlyInput.UseVisualStyleBackColor = true;
            this.batteryOnlyInput.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Auto Change Interval:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(172, 5);
            this.label6.Margin = new System.Windows.Forms.Padding(0, 6, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "minutes";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(136, 3);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(36, 20);
            this.numericUpDown1.TabIndex = 15;
            this.numericUpDown1.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // schedulingPage
            // 
            this.schedulingPage.Controls.Add(this.splitContainer1);
            this.schedulingPage.Location = new System.Drawing.Point(4, 22);
            this.schedulingPage.Name = "schedulingPage";
            this.schedulingPage.Padding = new System.Windows.Forms.Padding(3);
            this.schedulingPage.Size = new System.Drawing.Size(446, 275);
            this.schedulingPage.TabIndex = 1;
            this.schedulingPage.Text = "Query";
            this.schedulingPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.hiResInput);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.tagInput);
            this.splitContainer1.Panel1.Controls.Add(this.tagList);
            this.splitContainer1.Panel1.Controls.Add(this.sketchyInput);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.weabooInput);
            this.splitContainer1.Panel2.Controls.Add(this.nsfwInput);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.excludeInput);
            this.splitContainer1.Panel2.Controls.Add(this.minHeightInput);
            this.splitContainer1.Panel2.Controls.Add(this.minWidthInput);
            this.splitContainer1.Panel2.Controls.Add(this.excludeList);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.samplesInput);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Size = new System.Drawing.Size(440, 269);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 19;
            // 
            // hiResInput
            // 
            this.hiResInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hiResInput.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.hiResInput.Location = new System.Drawing.Point(3, 247);
            this.hiResInput.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.hiResInput.Name = "hiResInput";
            this.hiResInput.Size = new System.Drawing.Size(214, 17);
            this.hiResInput.TabIndex = 21;
            this.hiResInput.Text = "Hi Res";
            this.hiResInput.UseVisualStyleBackColor = true;
            this.hiResInput.CheckedChanged += new System.EventHandler(this.hiResInput_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tags";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tagInput
            // 
            this.tagInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagInput.Location = new System.Drawing.Point(3, 152);
            this.tagInput.Name = "tagInput";
            this.tagInput.Size = new System.Drawing.Size(214, 20);
            this.tagInput.TabIndex = 2;
            this.tagInput.Text = "Enter Tags";
            this.tagInput.WordWrap = false;
            // 
            // tagList
            // 
            this.tagList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.tagList.LabelWrap = false;
            this.tagList.Location = new System.Drawing.Point(3, 16);
            this.tagList.Name = "tagList";
            this.tagList.ShowGroups = false;
            this.tagList.Size = new System.Drawing.Size(214, 130);
            this.tagList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.tagList.TabIndex = 0;
            this.tagList.UseCompatibleStateImageBehavior = false;
            // 
            // sketchyInput
            // 
            this.sketchyInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sketchyInput.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.sketchyInput.Location = new System.Drawing.Point(3, 224);
            this.sketchyInput.Name = "sketchyInput";
            this.sketchyInput.Size = new System.Drawing.Size(214, 17);
            this.sketchyInput.TabIndex = 19;
            this.sketchyInput.Text = "Sketchy";
            this.sketchyInput.UseVisualStyleBackColor = true;
            this.sketchyInput.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 180);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Minimum size: ";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 203);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Use Best of";
            // 
            // weabooInput
            // 
            this.weabooInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.weabooInput.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.weabooInput.Location = new System.Drawing.Point(3, 247);
            this.weabooInput.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.weabooInput.Name = "weabooInput";
            this.weabooInput.Size = new System.Drawing.Size(210, 17);
            this.weabooInput.TabIndex = 20;
            this.weabooInput.Text = "Manga/Anime";
            this.weabooInput.UseVisualStyleBackColor = true;
            this.weabooInput.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // nsfwInput
            // 
            this.nsfwInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nsfwInput.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nsfwInput.Location = new System.Drawing.Point(3, 222);
            this.nsfwInput.Name = "nsfwInput";
            this.nsfwInput.Size = new System.Drawing.Size(210, 19);
            this.nsfwInput.TabIndex = 22;
            this.nsfwInput.Text = "NSFW";
            this.nsfwInput.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Excludes";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // excludeInput
            // 
            this.excludeInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.excludeInput.Location = new System.Drawing.Point(3, 151);
            this.excludeInput.Name = "excludeInput";
            this.excludeInput.Size = new System.Drawing.Size(210, 20);
            this.excludeInput.TabIndex = 4;
            this.excludeInput.Text = "Enter Excludes";
            this.excludeInput.WordWrap = false;
            // 
            // minHeightInput
            // 
            this.minHeightInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.minHeightInput.Location = new System.Drawing.Point(153, 177);
            this.minHeightInput.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.minHeightInput.Name = "minHeightInput";
            this.minHeightInput.Size = new System.Drawing.Size(60, 20);
            this.minHeightInput.TabIndex = 7;
            // 
            // minWidthInput
            // 
            this.minWidthInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.minWidthInput.Location = new System.Drawing.Point(81, 177);
            this.minWidthInput.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.minWidthInput.Name = "minWidthInput";
            this.minWidthInput.Size = new System.Drawing.Size(60, 20);
            this.minWidthInput.TabIndex = 5;
            // 
            // excludeList
            // 
            this.excludeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.excludeList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.excludeList.LabelWrap = false;
            this.excludeList.Location = new System.Drawing.Point(3, 16);
            this.excludeList.Name = "excludeList";
            this.excludeList.ShowGroups = false;
            this.excludeList.Size = new System.Drawing.Size(210, 129);
            this.excludeList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.excludeList.TabIndex = 3;
            this.excludeList.UseCompatibleStateImageBehavior = false;
            this.excludeList.SelectedIndexChanged += new System.EventHandler(this.excludeList_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(171, 203);
            this.label10.Margin = new System.Windows.Forms.Padding(0, 6, 3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "samples";
            // 
            // samplesInput
            // 
            this.samplesInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.samplesInput.Location = new System.Drawing.Point(135, 201);
            this.samplesInput.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.samplesInput.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.samplesInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.samplesInput.Name = "samplesInput";
            this.samplesInput.Size = new System.Drawing.Size(36, 20);
            this.samplesInput.TabIndex = 13;
            this.samplesInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 180);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "x";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(134, 5);
            this.label12.Margin = new System.Windows.Forms.Padding(0, 6, 3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "minutes";
            // 
            // intervalInput
            // 
            this.intervalInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.intervalInput.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.intervalInput.Location = new System.Drawing.Point(98, 3);
            this.intervalInput.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.intervalInput.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.intervalInput.Name = "intervalInput";
            this.intervalInput.Size = new System.Drawing.Size(36, 20);
            this.intervalInput.TabIndex = 15;
            this.intervalInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 5);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Interval: ";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.schedulingPage);
            this.tabControl.Controls.Add(this.generalPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(454, 301);
            this.tabControl.TabIndex = 1;
            this.tabControl.Visible = false;
            // 
            // startupInput
            // 
            this.startupInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startupInput.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.startupInput.Location = new System.Drawing.Point(3, 26);
            this.startupInput.Name = "startupInput";
            this.startupInput.Size = new System.Drawing.Size(210, 17);
            this.startupInput.TabIndex = 23;
            this.startupInput.Text = "Launch on Startup";
            this.startupInput.UseVisualStyleBackColor = true;
            // 
            // SysTrayIcon
            // 
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(454, 301);
            this.Controls.Add(this.tabControl);
            this.Enabled = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(265, 300);
            this.Name = "SysTrayIcon";
            this.Text = "Wall Changer Settings";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.SysTrayIcon_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.generalPage.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.schedulingPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.samplesInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intervalInput)).EndInit();
            this.tabControl.ResumeLayout(false);
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
            Application.Exit();
        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
            wallChangerTask.TaskService.RootFolder.DeleteTask(wallChangerTask.Name, false);
            notifyIcon.Visible = false;
        }

        private void SysTrayIcon_Load(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void hiResInput_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void excludeList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
