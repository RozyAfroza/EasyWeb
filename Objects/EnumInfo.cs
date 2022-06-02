using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace LearningProject.Objects
{
    public class EnumInfo : INotifyPropertyChanged
    {
        private string _name;
        private int _id;
        public int Id
        {
            get=> _id;
            set { _id = value; OnPropertyChanged("Id"); }
        }
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged("Name"); }
        }

        [JsonIgnore]
        public Type EnumType { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

       
    }
}
