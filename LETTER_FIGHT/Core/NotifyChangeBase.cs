using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LETTER_FIGHT.Core
{
    /// <summary>
    /// Base class for all change notification, impelementing INotifyPropertyChanged
    /// </summary>
    public class NotifyChangeBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
