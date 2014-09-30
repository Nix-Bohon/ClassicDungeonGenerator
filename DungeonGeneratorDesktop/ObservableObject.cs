using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGeneratorDesktop
{
    class ObservableObject : INotifyPropertyChanged
    {
        public void RaisePropertyChangedEvent(String propertyName){
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
