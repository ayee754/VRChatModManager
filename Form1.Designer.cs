namespace VRChatModManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.vrchatExeFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonInstall = new System.Windows.Forms.Button();
            this.buttonUninstall = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.checkedListMods = new System.Windows.Forms.CheckedListBox();
            this.buttonWipe = new System.Windows.Forms.Button();
            this.buttonReinstallMods = new System.Windows.Forms.Button();
            this.buttonOpenExplorer = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // vrchatExeFileDialog
            // 
            this.vrchatExeFileDialog.FileName = "VRChat.exe";
            this.vrchatExeFileDialog.Filter = "VRChat Executable|VRChat.exe";
            // 
            // buttonInstall
            // 
            this.buttonInstall.Location = new System.Drawing.Point(246, 12);
            this.buttonInstall.Name = "buttonInstall";
            this.buttonInstall.Size = new System.Drawing.Size(110, 26);
            this.buttonInstall.TabIndex = 0;
            this.buttonInstall.Text = "Install";
            this.buttonInstall.UseVisualStyleBackColor = true;
            this.buttonInstall.Click += new System.EventHandler(this.buttonInstall_Click);
            // 
            // buttonUninstall
            // 
            this.buttonUninstall.Location = new System.Drawing.Point(246, 44);
            this.buttonUninstall.Name = "buttonUninstall";
            this.buttonUninstall.Size = new System.Drawing.Size(110, 26);
            this.buttonUninstall.TabIndex = 0;
            this.buttonUninstall.Text = "Uninstall";
            this.buttonUninstall.UseVisualStyleBackColor = true;
            this.buttonUninstall.Click += new System.EventHandler(this.buttonUninstall_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 191);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(361, 24);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(31, 19);
            this.toolStripStatusLabel1.Text = "Idle";
            // 
            // checkedListMods
            // 
            this.checkedListMods.FormattingEnabled = true;
            this.checkedListMods.Location = new System.Drawing.Point(12, 12);
            this.checkedListMods.Name = "checkedListMods";
            this.checkedListMods.Size = new System.Drawing.Size(228, 172);
            this.checkedListMods.TabIndex = 2;
            // 
            // buttonWipe
            // 
            this.buttonWipe.Location = new System.Drawing.Point(246, 158);
            this.buttonWipe.Name = "buttonWipe";
            this.buttonWipe.Size = new System.Drawing.Size(110, 26);
            this.buttonWipe.TabIndex = 3;
            this.buttonWipe.Text = "Wipe";
            this.buttonWipe.UseVisualStyleBackColor = true;
            this.buttonWipe.Click += new System.EventHandler(this.buttonWipe_Click);
            // 
            // buttonReinstallMods
            // 
            this.buttonReinstallMods.Location = new System.Drawing.Point(246, 76);
            this.buttonReinstallMods.Name = "buttonReinstallMods";
            this.buttonReinstallMods.Size = new System.Drawing.Size(110, 26);
            this.buttonReinstallMods.TabIndex = 5;
            this.buttonReinstallMods.Text = "Reinstall Mods";
            this.buttonReinstallMods.UseVisualStyleBackColor = true;
            this.buttonReinstallMods.Click += new System.EventHandler(this.buttonReinstallMods_Click);
            // 
            // buttonOpenExplorer
            // 
            this.buttonOpenExplorer.Location = new System.Drawing.Point(246, 126);
            this.buttonOpenExplorer.Name = "buttonOpenExplorer";
            this.buttonOpenExplorer.Size = new System.Drawing.Size(110, 26);
            this.buttonOpenExplorer.TabIndex = 6;
            this.buttonOpenExplorer.Text = "Open Explorer";
            this.buttonOpenExplorer.UseVisualStyleBackColor = true;
            this.buttonOpenExplorer.Click += new System.EventHandler(this.buttonOpenExplorer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 215);
            this.Controls.Add(this.buttonOpenExplorer);
            this.Controls.Add(this.buttonReinstallMods);
            this.Controls.Add(this.buttonWipe);
            this.Controls.Add(this.checkedListMods);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.buttonUninstall);
            this.Controls.Add(this.buttonInstall);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "VRChat Mod Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog vrchatExeFileDialog;
        private System.Windows.Forms.Button buttonInstall;
        private System.Windows.Forms.Button buttonUninstall;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.CheckedListBox checkedListMods;
        private System.Windows.Forms.Button buttonWipe;
        private System.Windows.Forms.Button buttonReinstallMods;
        private System.Windows.Forms.Button buttonOpenExplorer;
    }
}

