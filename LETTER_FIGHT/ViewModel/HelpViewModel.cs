using LETTER_FIGHT.Core;
using LETTER_FIGHT.Service;

namespace LETTER_FIGHT.ViewModel
{
    public class HelpViewModel
    {
        public CommandBase ExitCommand { get; set; } = new CommandBase((o) => NavigationService.Navigator.NavigateTo("Menu"));

    }
}
