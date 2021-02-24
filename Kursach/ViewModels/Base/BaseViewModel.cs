using PropertyChanged;
using System.ComponentModel;

namespace Kursach
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// call this to fire <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="prop"></param>
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
