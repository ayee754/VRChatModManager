using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Cache;
using System.Windows.Forms;

namespace VRChatModManager
{
    class ModManager
    {
        private const string MelonLoaderUrl =
            @"https://github.com/HerpDerpinstine/MelonLoader/releases/latest/download/MelonLoader.zip";

        private const string ModListUrl =
            @"https://raw.githubusercontent.com/ayee754/VRChatModManager/master/VRCMods.txt";

        private const string MelonLoaderTempPath = @"MelonLoader.zip";
        private Dictionary<string, string> _modDictionary = new Dictionary<string, string>();

        private readonly String _vrChatPath;

        private string GetModFolderPath()
        {
            return _vrChatPath + "Mods\\";
        }

        private string GetMelonLoaderFolderPath()
        {
            return _vrChatPath + "MelonLoader\\";
        }

        private string GetLogFolderPath()
        {
            return _vrChatPath + "Logs\\";
        }

        private string GetPluginFolderPath()
        {
            return _vrChatPath + "Plugins\\";
        }

        private string GetUserDataFolderPath()
        {
            return _vrChatPath + "UserData\\";
        }

        private string GetMelonLoaderFilePath()
        {
            return _vrChatPath + "version.dll";
        }

        private string GetFileNameFromURL(string url)
        {
            return url.Substring(url.LastIndexOf('/'));
        }

        public WebClient CreateWebClient()
        {
            var client = new WebClient();
            client.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            return client;
        }

        public void UpdateModDictionary()
        {
            var webClient = CreateWebClient();
            var listString = webClient.DownloadString(ModListUrl);

            _modDictionary.Clear();
            foreach (var line in listString.Split("\n"))
            {
                var colonIndex = line.IndexOf(':');
                if (colonIndex == -1) continue;

                _modDictionary.Add(line.Substring(0, colonIndex), line.Substring(colonIndex + 1));
            }
        }

        public Dictionary<string, string> GetModDictionary()
        {
            return _modDictionary;
        }

        public ModManager(String vrChatPath)
        {
            this._vrChatPath = vrChatPath;
            if (!_vrChatPath.EndsWith('\\'))
            {
                MessageBox.Show(
                    @"Abnormal path: " + _vrChatPath,
                    @"Abnormal Path",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public bool IsInstalled()
        {
            return File.Exists(GetMelonLoaderFilePath());
        }

        public bool IsModInstalled(string modId)
        {
            var fileName = GetFileNameFromURL(_modDictionary[modId]);
            return File.Exists(GetModFolderPath() + fileName);
        }

        public void Install()
        {
            try
            {
                using var webClient = CreateWebClient();
                webClient.DownloadFile(MelonLoaderUrl, MelonLoaderTempPath);
                ZipFile.ExtractToDirectory(MelonLoaderTempPath, _vrChatPath);
            }
            finally
            {
                try
                {
                    File.Delete(MelonLoaderTempPath);
                    File.Delete(_vrChatPath + "NOTICE.txt");
                }
                catch (IOException)
                {
                    MessageBox.Show(@"Failed to delete temporary files!",
                        @"Temporary files error!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }

            Directory.CreateDirectory(GetModFolderPath());
        }

        public void InstallMod(string modId)
        {
            var url = _modDictionary[modId];
            DownloadModFile(url, GetFileNameFromURL(url));
        }

        private void DownloadModFile(string url, string fileName)
        {
            using var webClient = CreateWebClient();
            webClient.DownloadFile(url, GetModFolderPath() + fileName);
        }

        public void Uninstall()
        {
            File.Delete(GetMelonLoaderFilePath());

            var melonLoaderFolder = GetMelonLoaderFolderPath();
            if (Directory.Exists(melonLoaderFolder)) Directory.Delete(melonLoaderFolder, true);

            UninstallMods();
        }

        public void UninstallMods()
        {
            var modPath = GetModFolderPath();
            if (!Directory.Exists(modPath)) return;
            foreach (var f in Directory.GetFiles(modPath, "*.dll"))
            {
                File.Delete(f);
            }
        }

        public void Wipe()
        {
            if (IsInstalled())
            {
                Uninstall();
            }

            var modFolderPath = GetModFolderPath();
            if (Directory.Exists(modFolderPath)) Directory.Delete(modFolderPath, true);

            var pluginFolderPath = GetPluginFolderPath();
            if (Directory.Exists(pluginFolderPath)) Directory.Delete(pluginFolderPath, true);

            var logFolder = GetLogFolderPath();
            if (Directory.Exists(logFolder)) Directory.Delete(logFolder, true);

            var userDataFolder = GetUserDataFolderPath();
            if (Directory.Exists(userDataFolder)) Directory.Delete(userDataFolder, true);
        }
    }
}