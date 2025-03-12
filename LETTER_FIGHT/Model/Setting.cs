using LETTER_FIGHT.Core;

namespace LETTER_FIGHT.Model
{
    public class Setting : NotifyChangeBase
    {
        private string _player1Name;
        private string _player2Name;
        private int _targetScore;
        private string _language;
        public string Player1Name
        {
            get => _player1Name;
            set
            {
                _player1Name = value;
                OnPropertyChanged();
            }
        }
        public string Player2Name
        {
            get => _player2Name;
            set
            {
                _player2Name = value;
                OnPropertyChanged();
            }
        }
        public int TargetScore
        {
            get => _targetScore;
            set
            {
                if (value < 25)
                {
                    value = 25;
                }
                _targetScore = value;
                OnPropertyChanged();
            }
        }
        public string Language
        {
            get => _language;
            set
            {
                _language = value;
                OnPropertyChanged();
            }
        }

    }
}
