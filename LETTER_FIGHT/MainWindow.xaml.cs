using LETTER_FIGHT.Core;
using LETTER_FIGHT.Service;
using System.Windows;


namespace LETTER_FIGHT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigationService.Navigator = new NavigationBase(ContentSpace);

            NavigationService.Navigator.RegisterView("Menu", typeof(View.MenuView));
            NavigationService.Navigator.RegisterView("Game", typeof(View.GameView));
            NavigationService.Navigator.RegisterView("Setting", typeof(View.SettingView));
            NavigationService.Navigator.RegisterView("Help", typeof(View.HelpView));

            NavigationService.Navigator.NavigateTo("Menu");
        }
    }
}
