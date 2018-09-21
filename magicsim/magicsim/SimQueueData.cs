﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magicsim
{
    public class SimQueueData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        SimData BackingData;
        
        public SimQueueData()
        {
            BackingData = SimDataManager.GetSimData();
            FixedIterationOrError = 1;
            Threads = Math.Min(8, Environment.ProcessorCount);
        }
        
        public ObservableCollection<Sim> Sims
        {
            get
            {
                return BackingData.Sims;
            }
        }

        public ObservableCollection<string> Models
        {
            get
            {
                return BackingData.Models;
            }
        }

        public String SelectedModel
        {
            get { return BackingData._SelectedModel; }
            set
            {
                if (value != BackingData._SelectedModel)
                {
                    BackingData._SelectedModel = value;
                    OnPropertyChanged("SelectedModel");
                }
            }
        }

        public bool ReforgeEnabled
        {
            get { return BackingData._ReforgeEnabled; }
            set
            {
                if (value != BackingData._ReforgeEnabled)
                {
                    BackingData._ReforgeEnabled = value;
                    OnPropertyChanged("ReforgeEnabled");
                }
            }
        }

        public bool DisableStatWeights
        {
            get { return BackingData._DisableStatWeights; }
            set
            {
                if (value != BackingData._DisableStatWeights)
                {
                    BackingData._DisableStatWeights = value;
                    OnPropertyChanged("DisableStatWeights");
                }
            }
        }

        public bool PTRMode
        {
            get { return BackingData._PTRMode; }
            set
            {
                if (value != BackingData._PTRMode)
                {
                    BackingData._PTRMode = value;
                    OnPropertyChanged("PTRMode");
                }
            }
        }

        public bool ReforgeCrit
        {
            get { return BackingData._ReforgeCrit; }
            set
            {
                if (value != BackingData._ReforgeCrit)
                {
                    BackingData._ReforgeCrit = value;
                    OnPropertyChanged("ReforgeCrit");
                }
            }
        }

        public bool ReforgeMastery
        {
            get { return BackingData._ReforgeMastery; }
            set
            {
                if (value != BackingData._ReforgeMastery)
                {
                    BackingData._ReforgeMastery = value;
                    OnPropertyChanged("ReforgeMastery");
                }
            }
        }

        public bool ReforgeHaste
        {
            get { return BackingData._ReforgeHaste; }
            set
            {
                if (value != BackingData._ReforgeHaste)
                {
                    BackingData._ReforgeHaste = value;
                    OnPropertyChanged("ReforgeHaste");
                }
            }
        }

        public bool ReforgeVers
        {
            get { return BackingData._ReforgeVers; }
            set
            {
                if (value != BackingData._ReforgeVers)
                {
                    BackingData._ReforgeVers = value;
                    OnPropertyChanged("ReforgeVers");
                }
            }
        }

        public int Threads
        {
            get { return BackingData._Threads; }
            set
            {
                if (value != BackingData._Threads)
                {
                    BackingData._Threads = value;
                    OnPropertyChanged("Threads");
                }
            }
        }

        public int Processes
        {
            get { return BackingData._Processes; }
            set
            {
                if (value != BackingData._Processes)
                {
                    BackingData._Processes = value;
                    OnPropertyChanged("Processes");
                }
            }
        }

        public int ReforgeStepSize
        {
            get { return BackingData._ReforgeStepSize; }
            set
            {
                if (value != BackingData._ReforgeStepSize)
                {
                    BackingData._ReforgeStepSize = value;
                    OnPropertyChanged("ReforgeStepSize");
                }
            }
        }

        public int ReforgeAmount
        {
            get { return BackingData._ReforgeAmount; }
            set
            {
                if (value != BackingData._ReforgeAmount)
                {
                    BackingData._ReforgeAmount = value;
                    OnPropertyChanged("ReforgeAmount");
                }
            }
        }

        public int FixedIterationOrError
        {
            get { return BackingData._FixedIterationOrError; }
            set
            {
                if (value != BackingData._FixedIterationOrError)
                {
                    BackingData._FixedIterationOrError = value;
                    OnPropertyChanged("FixedIterationOrError");
                }
            }
        }

        public void AddSim(string profile, string name)
        {
            if(BackingData.Sims.Where((sim) => { return sim.Name.Equals(name); }).Count() > 0)
            {
                var i = 1;
                while(BackingData.Sims.Where((sim) => { return sim.Name.Equals(name + i); }).Count() > 0)
                {
                    i++;
                }
                BackingData.Sims.Add(new Sim() { Name = name + i, Profile = profile });
                return;
            }
            BackingData.Sims.Add(new Sim() { Name = name, Profile = profile });
            OnPropertyChanged("Sims");
        }

        public void RemoveSim(string name)
        {
            var matching = BackingData.Sims.Where((sim) =>
            {
                return sim.Name.Equals(name);
            });
            if(matching.Count() > 0)
            {
                BackingData.Sims.Remove(matching.ElementAt(0));
            }
            OnPropertyChanged("Sims");
        }

        public void RenameSim(string name, string newName)
        {
            var matching = BackingData.Sims.Where((sim) =>
            {
                return sim.Name.Equals(name);
            });
            if (matching.Count() > 0)
            {
                BackingData.Sims.ElementAt(0).Name = newName;
            }
            OnPropertyChanged("Sims");
        }
    }
}
