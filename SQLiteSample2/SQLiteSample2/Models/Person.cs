﻿using Prism.Mvvm;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLiteSample2.Models {
    public class Person : BindableBase {

        [PrimaryKey, AutoIncrement]
        public int ID {
            get => id;
            set => SetProperty(ref id, value);
        }
        private int id;

        public int FamilyID {
            get => familyId;
            set => SetProperty(ref familyId, value);
        }
        private int familyId;

        public string Name {
            get => name;
            set => SetProperty(ref name, value);
        }
        private string name;

    }
}
