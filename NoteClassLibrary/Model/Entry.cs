using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleClassLibrary.BaseClass;
using System.Xml.Serialization;

namespace SampleClassLibrary.Model
{
    public class Entry : NotificationObject
    {
        string name;

        [XmlElement(ElementName = "Name")]
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        string surname;

        [XmlElement(ElementName = "Surname")]
        public string Surname
        {
            get { return this.surname; }
            set
            {
                if (this.surname != value)
                {
                    this.surname = value;
                    OnPropertyChanged("Surname");
                }
            }
        }
        string company;

        [XmlElement(ElementName = "Company")]
        public string Company
        {
            get { return this.company; }
            set
            {
                if (this.company != value)
                {
                    this.company = value;
                    OnPropertyChanged("Company");
                }
            }
        }

        [XmlElement(ElementName = "Telephone")]
        ObservableCollection<Telephone> telephones;
        public ObservableCollection<Telephone> Telephones
        {
            get
            { return this.telephones; }
            set
            {
                if (this.telephones != value)
                {
                    this.telephones = value;
                    OnPropertyChanged("Telephones");
                }
            }
        }

        [XmlElement(ElementName = "Address")]
        ObservableCollection<Address> addresses;
        public ObservableCollection<Address> Addresses
        {
            get
            { return this.addresses; }
            set
            {
                if (this.addresses != value)
                {
                    this.addresses = value;
                    OnPropertyChanged("Telephones");
                }
            }
        }

        public Entry()
        {
            this.Telephones = new ObservableCollection<Telephone>();
            this.Addresses = new ObservableCollection<Address>();
        }
    }
}
