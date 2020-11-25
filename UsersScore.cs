using System;
using System.ComponentModel;

namespace ScoreGraphV2
{
    public class UsersScore : INotifyPropertyChanged
    {
        private int student_id;
        private string user_name;
        private string project;
        private string score;
        private DateTime time;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public int Id
        {
            get
            {
                return student_id;
            }
            set
            {
                student_id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get
            {
                return user_name;
            }
            set
            {
                user_name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Project
        {
            get
            {
                return project;
            }
            set
            {
                project = value;
                OnPropertyChanged("Project");
            }
        }

        public string Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
                OnPropertyChanged("Score");
            }
        }


        public DateTime Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
                OnPropertyChanged("Time");
            }
        }
    }
}