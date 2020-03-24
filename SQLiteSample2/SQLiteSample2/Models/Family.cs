using Prism.Mvvm;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SQLiteSample2.Models {
    public class Family : BindableBase {

        [PrimaryKey, AutoIncrement]
        public int ID {
            get => id;
            set => SetProperty(ref id, value);
        }
        private int id;
        
        public string Name {
            get => name;
            set => SetProperty(ref name, value);
        }
        private string name;

        public ObservableCollection<Person> Persons { get; }

        public Family() {
        }

        public Family(ObservableCollection<Person> persons) {
            Persons = persons;
        }

    }
}
