using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleClassLibrary.BaseClass;
using System.Xml.Serialization;

namespace SampleClassLibrary.Model
{
    public class Address : NotificationObject
    {
        string street;

        [XmlElement(ElementName = "Street")]
        public string Street
        {
            get { return this.street; }
            set
            {
                if (this.street != value)
                {
                    this.street = value;
                    OnPropertyChanged("Street");
                }
            }
        }
        string town;

        [XmlElement(ElementName = "Town")]
        public string Town
        {
            get { return this.town; }
            set
            {
                if (this.town != value)
                {
                    this.town = value;
                    OnPropertyChanged("Town");
                }
            }
        }
        string province;

        [XmlElement(ElementName = "Province")]
        public string Province
        {
            get { return this.province; }
            set
            {
                if (this.province != value)
                {
                    this.province = value;
                    OnPropertyChanged("Province");
                }
            }
        }
        string zipcode;

        [XmlElement(ElementName = "Zipcode")]
        public string Zipcode
        {
            get { return this.zipcode; }
            set
            {
                if (this.zipcode != value)
                {
                    this.zipcode = value;
                    OnPropertyChanged("Zipcode");
                }
            }
        }

        public override string ToString()
        {
            return String.Format("Street:\t{0}\nTown:\t{1}\nProvince:\t{2}\nZipcode:\t{3}", this.Street, this.Town, this.Province, this.Zipcode);
        }
    }
}
