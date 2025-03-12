using LETTER_FIGHT.Core;

namespace LETTER_FIGHT.Model
{
    public class Letter : NotifyChangeBase
    {
        private char _value;
        private int _counter = 0;
        public char Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ToString));
            }
        }

        public int Counter
        {
            get => _counter;
            set
            {
                _counter = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ToString));
            }
        }
    }
}
