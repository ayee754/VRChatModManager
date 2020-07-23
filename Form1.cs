using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace VRChatModManager
{
    public partial class Form1 : Form
    {
        private readonly string[] checkPath = new string[]
        {
            "C:\\Program Files\\Steam\\steamapps\\common\\VRChat\\VRChat.exe",
            "C:\\Program Files (x86)\\Steam\\steamapps\\common\\VRChat\\VRChat.exe",
            "D:\\Program Files\\Steam\\steamapps\\common\\VRChat\\VRChat.exe",
            "D:\\Program Files (x86)\\Steam\\steamapps\\common\\VRChat\\VRChat.exe",
        };

        private string _folderPath = null;
        private ModManager _manager;

        public Form1()
        {
            InitializeComponent();
            LocateExecutable();

            _manager = new ModManager(_folderPath);
            _manager.UpdateModDictionary();
            foreach (var key in _manager.GetModDictionary().Keys)
            {
                checkedListMods.Items.Add(key);
            }

            UpdateEnabledModList();
        }

        public void LocateExecutable()
        {
            foreach (var s in checkPath)
            {
                if (File.Exists(s))
                {
                    UpdateExecutablePath(s);
                    SetStatus(s.Substring(0, Math.Min(40, s.Length)) + "...");
                    return;
                }
            }

            var msgResult = MessageBox.Show(
                @"Can't automatically locate VRChat.exe, please specify location",
                @"Automatic location failed",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );

            if (msgResult == DialogResult.Cancel)
            {
                return;
            }

            vrchatExeFileDialog.ShowDialog();
            UpdateExecutablePath(vrchatExeFileDialog.FileName);
        }

        public void UpdateExecutablePath(String path)
        {
            if (!File.Exists((path)))
            {
                MessageBox.Show(
                    @"Selected VRChat.exe does not exist!",
                    @"File does not exist!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            _folderPath = path.Substring(0, path.Length - "VRChat.exe".Length);
        }

        public void InstallCheckedMods()
        {
            foreach (string item in checkedListMods.CheckedItems)
            {
                SetStatus(@"Installing " + item);
                _manager.InstallMod(item);
            }
        }

        private void UpdateUi(bool busy)
        {
            var installed = _manager.IsInstalled();

            buttonInstall.Enabled = !installed && !busy;
            buttonUninstall.Enabled = installed && !busy;
            buttonReinstallMods.Enabled = installed && !busy;

            checkedListMods.Enabled = !busy;
            buttonWipe.Enabled = !busy;
        }

        private void UpdateEnabledModList()
        {
            for (var i = 0; i < checkedListMods.Items.Count; i++)
            {
                var itemText = checkedListMods.Items[i].ToString();
                checkedListMods.SetItemChecked(i, _manager.IsModInstalled(itemText));
            }
        }

        private void SetStatus(string status)
        {
            toolStripStatusLabel1.Text = status;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateUi(false);

            var version = Assembly.GetExecutingAssembly().GetName().Version;
            if (version != null)
            {
                this.Text += @" " + version.Major + @"." + version.Minor + @"." + version.Build;
            }
        }

        private void buttonInstall_Click(object sender, EventArgs e)
        {
            UpdateUi(true);

            SetStatus(@"Installing MelonLoader...");
            try
            {
                _manager.Install();
                InstallCheckedMods();
                SetStatus(@"Installation completed!");
            }
            catch (IOException exception)
            {
                MessageBox.Show(
                    @"IO operation failed!
Please make sure VRChat is closed
If problem still persist, try Wipe then retry

Error:
" + exception.Message,
                    @"Failed to install",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                SetStatus(@"Installation failed!");
            }

            UpdateUi(false);
        }

        private void buttonUninstall_Click(object sender, EventArgs e)
        {
            UpdateUi(true);
            SetStatus(@"Uninstalling!");
            _manager.Uninstall();
            SetStatus(@"Uninstall completed!");
            UpdateUi(false);
        }

        private void buttonReinstallMods_Click(object sender, EventArgs e)
        {
            UpdateUi(true);
            SetStatus("Cleaning mods...");
            _manager.UninstallMods();
            SetStatus("Installing mods...");
            InstallCheckedMods();
            SetStatus("Reinstall successfully!");
            UpdateUi(false);
        }

        private void buttonWipe_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(@"Are you sure you want to wipe all mods data?",
                @"Confirmation",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                SetStatus("Wiping...");
                UpdateUi(true);
                _manager.Wipe();
                UpdateEnabledModList();
                SetStatus("Wipe successfully");
                UpdateUi(false);
            }
            else
            {
                SetStatus("Wipe cancelled");
            }
        }

        private void buttonOpenExplorer_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", _folderPath);
        }
    }
}