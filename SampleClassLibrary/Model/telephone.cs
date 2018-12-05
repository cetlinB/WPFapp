using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleClassLibrary.BaseClass;
using System.Xml.Serialization;

namespace SampleClassLibrary.Model
{
    public class Telephone : NotificationObject
    {
        string number;

        [XmlElement(ElementName = "Number")]
        public string Number
        {
            get { return this.number; }
            set
            {
                if (this.number != value)
                {
                    this.number = value;
                    OnPropertyChanged("Number");
                }
            }
        }
        string description;

        [XmlElement(ElementName = "Description")]
        public string Description
        {
            get { return this.description; }
            set
            {
                if (this.description != value)
                {
                    this.description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public override string ToString()
        {
            return String.Format("Telephone:\t{0}\nDescription:\t{1}", this.Number, this.Description);
        }
    }
}
