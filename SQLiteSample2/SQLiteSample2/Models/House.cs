using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SQLiteSample2.Models {
    public class House : BindableBase {

        public ObservableCollection<Person> Person { get; }

    }
}
