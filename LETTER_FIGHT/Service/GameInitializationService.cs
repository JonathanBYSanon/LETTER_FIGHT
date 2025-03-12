using LETTER_FIGHT.Model;
using System.Collections.ObjectModel;

namespace LETTER_FIGHT.Service
{
    public class GameInitializationService
    {
        /// <summary>
        /// Generate letters from A to Z
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Letter> GenerateLetters()
        {
            var letters = new ObservableCollection<Letter>();
            for (char c = 'A'; c <= 'Z'; c++)
            {
                letters.Add(new Letter { Value = c});
            }
            return letters;
        }

        /// <summary>
        /// Generate players
        /// </summary>
        /// <returns></returns>
        public static Player[] GeneratePlayers()
        {
            Player[] players = new Player[2]
            {
                new Player 
                { 
                    Index = 0, 
                    Name = SettingService.ActiveSettings.Player1Name,
                    IsTurn = true
                },
                new Player 
                { 
                    Index = 1, 
                    Name = SettingService.ActiveSettings.Player2Name,
                }
            };

            return players;
        }
    }
}
