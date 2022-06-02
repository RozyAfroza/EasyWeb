using System;
using System.ComponentModel;

namespace LearningProject.Objects
{
    public class DbConnectionModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private string _databaseServerUsername;
        private string _databaseServerPassword;
        private string _databaseName;
        private string _serverName;

        public string ServerName
        {
            get { return _serverName; }
            set { _serverName = value; OnPropertyChanged("ServerName"); }
        }

        public string DatabaseName
        {
            get { return _databaseName; }
            set
            {
                _databaseName = value;
                OnPropertyChanged("DatabaseName");
            }
        }

        public string Username
        {
            get { return _databaseServerUsername; }
            set
            {
                _databaseServerUsername = value;
                OnPropertyChanged("Username");
            }
        }

        public string Password
        {
            get { return _databaseServerPassword; }
            set
            {
                _databaseServerPassword = value;
                OnPropertyChanged("Password");
            }
        }



        public string this[string columnName]
        {
            get
            {
                string result = null;
                switch (columnName)
                {
                    case "Username":
                        if (string.IsNullOrEmpty(Username))
                            result = "UserNameRequired";
                        break;
                    case "Password":
                        if (string.IsNullOrEmpty(Password))
                            result = "PasswordRequired";
                        break;
                    case "ServerName":
                        if (string.IsNullOrEmpty(ServerName))
                            result = "ServerNameRequired";
                        break;
                    case "DatabaseName":
                        if (string.IsNullOrEmpty(DatabaseName))
                            result = "DatabaseNameRequired";
                        break;
                }
                return result;
            }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
