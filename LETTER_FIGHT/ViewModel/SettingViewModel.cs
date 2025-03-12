using LETTER_FIGHT.Core;
using LETTER_FIGHT.Model;
using LETTER_FIGHT.Service;
using System.Collections.ObjectModel;

namespace LETTER_FIGHT.ViewModel
{
    public class SettingViewModel : NotifyChangeBase
    {
        public Setting Setting { get; set; }
        public ObservableCollection<string> Languages { get; set; } = new ObservableCollection<string>() { "EN", "FR" };
        public CommandBase SaveCommand { get; set; }
        public SettingViewModel()
        {
            Setting = new Setting()
            {
                Player1Name = SettingService.ActiveSettings.Player1Name,
                Player2Name = SettingService.ActiveSettings.Player2Name,
                TargetScore = SettingService.ActiveSettings.TargetScore,
                Language = SettingService.ActiveSettings.Language
            };

            SaveCommand = new CommandBase(SaveAction, canSave);
        }

        private void SaveAction(object obj)
        {
            SettingService.ActiveSettings = Setting;
            NavigationService.Navigator.NavigateTo("Menu");
        }

        private bool canSave(object obj)
        {
            return !string.IsNullOrEmpty(Setting.Player1Name)
                && !string.IsNullOrEmpty(Setting.Player2Name)
                && Setting.TargetScore > 0;
        }

    }
}
