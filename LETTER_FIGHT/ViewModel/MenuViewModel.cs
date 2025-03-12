using LETTER_FIGHT.Core;
using LETTER_FIGHT.Service;
using System.Collections.ObjectModel;
using System.Windows;

namespace LETTER_FIGHT.ViewModel
{
    public class MenuViewModel
    {
        public CommandBase GoToGame { get; set; }
        public CommandBase GoToSetting { get; set; }
        public CommandBase GoToHelp { get; set; }
        public CommandBase Exit { get; set; }
        public ObservableCollection<string> ButtonText { get; set; }
        public MenuViewModel()
        {
            if (SettingService.ActiveSettings.Language == "FR")
            {
                ButtonText = new ObservableCollection<string> { "🎮 | Jouer", "❓ | Aide", "⚙️ | Paramètres", "❌ | Quitter" };
            }
            else
            {
                ButtonText = new ObservableCollection<string> { "🎮 | Play", "❓ | Help", "⚙️ | Settings", "❌ | Close" };
            }
            GoToGame = new CommandBase(GoToGameAction);
            GoToSetting = new CommandBase(GoToSettingAction);
            GoToHelp = new CommandBase(GoToHelpAction);
            Exit = new CommandBase(ExitAction);
        }

        private void GoToGameAction(object obj)
        {
            NavigationService.Navigator.NavigateTo("Game");
        }

        private void GoToSettingAction(object obj)
        {
            NavigationService.Navigator.NavigateTo("Setting");
        }

        private void GoToHelpAction(object obj)
        {
            NavigationService.Navigator.NavigateTo("Help");
        }

        private void ExitAction(object obj)
        {
            MessageBoxResult result = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
                System.Windows.Application.Current.Shutdown();
        }
    }
}
