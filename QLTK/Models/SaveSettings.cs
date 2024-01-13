using LitJson;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace QLTK.Models
{
    public class SaveSettings
    {
        [LitJSON.JsonSkip]
        private AppConfig _appConfig;

        public string VersionNotification { get; set; }
        public string Size { get; set; } = "1024x600";
        public int LowGraphic { get; set; } = 1;
        public int TypeSize { get; set; } = 2;
        public int RowDetailsMode { get; set; } = 0;
        public int IndexConnectToDiscordRPC { get; set; } = -1;

        [LitJSON.JsonSkip]
        public NroAccount? AccountConnectToDiscordRPC { get; set; }

        public SaveSettings(IOptions<AppConfig> config)
        {
            _appConfig = config.Value;
        }

        private void LoadSaveSettings()
        {
            try
            {
                var saveSettingsJson = File.ReadAllText(_appConfig.PathSettings);
                var saveSettingsObject = JsonMapper.ToObject(saveSettingsJson);
                VersionNotification = saveSettingsObject["VersionNotification"].ToString();
                Size = saveSettingsObject["Size"].ToString();
                LowGraphic = int.Parse(saveSettingsObject["LowGraphic"].ToString());
                TypeSize = int.Parse(saveSettingsObject["TypeSize"].ToString());
                RowDetailsMode = int.Parse(saveSettingsObject["RowDetailsMode"].ToString());
                IndexConnectToDiscordRPC = int.Parse(saveSettingsObject["IndexConnectToDiscordRPC"].ToString());
            }
            catch (Exception e)
            {
                var r = MessageBox.Show(
                    "Không tìm thấy dữ liệu cài đặt, bạn có muốn tạo dữ liệu mới?\n\n" + e.ToString(),
                    "Lỗi tải dữ liệu", MessageBoxButton.YesNo, MessageBoxImage.Information);

                if (r == MessageBoxResult.Yes)
                {
                    //return new SaveSettings();
                }
                else
                {
                    Application.Current.Shutdown();

                }
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                var saveSettingJson = LitJson.JsonMapper.ToJson(this);
                await File.WriteAllTextAsync(_appConfig.PathSettings, saveSettingJson);
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi lưu dữ liệu\n" + e.ToString());
            }
        }
    }
}
