using LETTER_FIGHT.Core;
using LETTER_FIGHT.Service;

namespace LETTER_FIGHT.Model
{
    public class Player : NotifyChangeBase
    {
        private int _index;
        private string _name;
        private int _score = 0;
        private bool _isTurn = false;
        public int Index
        {
            get => _index;
            set
            {
                _index = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ToString));
            }
        }
        public bool IsTurn
        {
            get => _isTurn;
            set
            {
                _isTurn = value;
                if(value) TurnControlService.ActivePlayerIndex = Index;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ToString));
            }
        }
    }
}
