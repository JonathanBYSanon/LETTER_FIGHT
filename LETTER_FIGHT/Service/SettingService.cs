using LETTER_FIGHT.Model;

namespace LETTER_FIGHT.Service
{
    public class SettingService
    {
        /// <summary>
        /// Active settings
        /// </summary>
        public static Setting ActiveSettings { get; set; } = new Setting()
        {
            Player1Name = "Player 1",
            Player2Name = "Player 2",
            TargetScore = 50,
            Language = "FR"
        };
    }
}
