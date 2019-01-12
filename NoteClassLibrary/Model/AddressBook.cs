using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteClassLibrary.BaseClass;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace NoteClassLibrary.Model
{
    [XmlRoot(ElementName ="AddressBook")]
    public class AddressBook : NotificationObject
    {
        ObservableCollection<Entry> entries;
        [XmlElement(ElementName ="Entry")]
        public ObservableCollection<Entry> Entries
        {
            get
            { return this.entries; }
            set
            {
                if (this.entries != value)
                {
                    this.entries = value;
                    OnPropertyChanged("Entries");
                }
            }
        }

        public AddressBook()
        {
            this.Entries = new ObservableCollection<Entry>();
        }
    }
}
