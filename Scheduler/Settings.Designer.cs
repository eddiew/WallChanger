namespace Scheduler
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.TagList = new System.Windows.Forms.ListBox();
            this.NewTagBox = new System.Windows.Forms.TextBox();
            this.AddTagButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ConfigTitle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // TagList
            // 
            this.TagList.FormattingEnabled = true;
            this.TagList.Location = new System.Drawing.Point(12, 38);
            this.TagList.Name = "TagList";
            this.TagList.Size = new System.Drawing.Size(259, 95);
            this.TagList.TabIndex = 1;
            // 
            // NewTagBox
            // 
            this.NewTagBox.Location = new System.Drawing.Point(12, 139);
            this.NewTagBox.Name = "NewTagBox";
            this.NewTagBox.Size = new System.Drawing.Size(179, 20);
            this.NewTagBox.TabIndex = 2;
            // 
            // AddTagButton
            // 
            this.AddTagButton.Location = new System.Drawing.Point(197, 139);
            this.AddTagButton.Name = "AddTagButton";
            this.AddTagButton.Size = new System.Drawing.Size(75, 23);
            this.AddTagButton.TabIndex = 3;
            this.AddTagButton.Text = "Add Tag";
            this.AddTagButton.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(116, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(197, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // ConfigTitle
            // 
            this.ConfigTitle.BackColor = System.Drawing.SystemColors.Window;
            this.ConfigTitle.Location = new System.Drawing.Point(12, 12);
            this.ConfigTitle.Name = "ConfigTitle";
            this.ConfigTitle.ReadOnly = true;
            this.ConfigTitle.Size = new System.Drawing.Size(98, 20);
            this.ConfigTitle.TabIndex = 6;
            this.ConfigTitle.TabStop = false;
            this.ConfigTitle.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.ConfigTitle);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.AddTagButton);
            this.Controls.Add(this.NewTagBox);
            this.Controls.Add(this.TagList);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ListBox TagList;
        private System.Windows.Forms.TextBox NewTagBox;
        private System.Windows.Forms.Button AddTagButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox ConfigTitle;
    }
}