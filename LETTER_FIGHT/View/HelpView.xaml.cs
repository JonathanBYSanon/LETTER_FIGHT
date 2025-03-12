using LETTER_FIGHT.Service;
using LETTER_FIGHT.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace LETTER_FIGHT.View
{
    /// <summary>
    /// Interaction logic for HelpView.xaml
    /// </summary>
    public partial class HelpView : UserControl
    {
        public HelpView()
        {
            InitializeComponent();
            if (SettingService.ActiveSettings.Language == "EN")
            {
                HtmlView.Navigate(new Uri("pack://siteoforigin:,,,/Resources/HTML/Rules.html"));
            }
            else
            {
                HtmlView.Navigate(new Uri("pack://siteoforigin:,,,/Resources/HTML/Regles.html"));
            }
        }
    }
}
