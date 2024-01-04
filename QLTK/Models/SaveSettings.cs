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
        public NroAccount AccountConnectToDiscordRPC { get; set; }

        private SaveSettings LoadSaveSettings()
        {
            try
            {
                return LitJson.JsonMapper.ToObject<SaveSettings>(
                    File.ReadAllText(_appConfig.PathSettings));
            }
            catch (Exception e)
            {
                var r = MessageBox.Show(
                    "Không tìm thấy dữ liệu cài đặt, bạn có muốn tạo dữ liệu mới?\n\n" + e.ToString(),
                    "Lỗi tải dữ liệu", MessageBoxButton.YesNo, MessageBoxImage.Information);

                if (r == MessageBoxResult.Yes)
                {
                    return new SaveSettings();
                }

                Application.Current.Shutdown();
                return null;
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await File.WriteAllTextAsync(_appConfig.PathSettings,
                    LitJson.JsonMapper.ToJson(this));
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi lưu dữ liệu\n" + e.ToString());
            }
        }
    }
}
