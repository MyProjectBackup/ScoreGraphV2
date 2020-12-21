using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoreGraphV2
{
    class History : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private string name;
        private int countPerMinutes;//速度
        private int correctPercentage;//正确率
        private int finishedPercentage;//完成率
        private DateTime startAt;
        private DateTime lastUpdate;

        private int interval;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int CountPerMinutes
        {
            get
            {
                return countPerMinutes;
            }
            set
            {
                countPerMinutes = value;
                OnPropertyChanged("CountPerMinutes");
            }
        }

        public int CorrectPercentage
        {
            get
            {
                return correctPercentage;
            }
            set
            {
                correctPercentage = value;
                OnPropertyChanged("CorrectPercentage");
            }
        }

        public int FinishedPercentage
        {
            get
            {
                return finishedPercentage;
            }
            set
            {
                finishedPercentage = value;
                OnPropertyChanged("FinishedPercentage");
            }
        }

        public DateTime StartAt
        {
            get
            {
                return startAt;
            }
            set
            {
                startAt = value;
                OnPropertyChanged("StartAt");
            }
        }

        public DateTime LastUpdate
        {
            get
            {
                return lastUpdate;
            }
            set
            {
                lastUpdate = value;
                OnPropertyChanged("LastUpdate");
            }
        }


        public int Interval
        {
            get
            {
                return interval;
            }
            set
            {
                interval = value;
                OnPropertyChanged("Interval");
            }
        }
    }    
}
