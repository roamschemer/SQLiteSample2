using Prism.Mvvm;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteSample2.Models {
    public class CoreModel : BindableBase {

        public ObservableCollection<Family> Familys { get; private set; }

        readonly SQLiteAsyncConnection _database;

        public CoreModel() {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Family>().Wait();
            _database.CreateTableAsync<Person>().Wait();
            DbLoad();
        }

        private async void DbLoad() {
            var items = await GetFamilysAsync();
            Familys = new ObservableCollection<Family>(items);
            if (Familys.Count == 0) CreateSample();
        }

        public async void DbSave() {
            foreach(var x in Familys) {
                var items = await SaveFamilyAsync(x);
            }
        }

        private void CreateSample() {
            Familys.Add(new Family(new ObservableCollection<Person>() {
                    new Person(){Name = "雨ヶ崎笑虹"},
                    new Person(){Name = "白石ひなた"},
                    new Person(){Name = "都三代らみょん"},
                    new Person(){Name = "三田そにあ"},
                    new Person(){Name = "縁うか"},
                }) { Name = "雨ヶ崎家" });
            Familys.Add(new Family(new ObservableCollection<Person>() {
                    new Person(){Name = "九条林檎"},
                    new Person(){Name = "九条棗"},
                    new Person(){Name = "九条杏子"},
                    new Person(){Name = "九条茘枝"},
                }) { Name = "九条家" });
            Familys.Add(new Family(new ObservableCollection<Person>() {
                    new Person(){Name = "巻乃もなか"},
                    new Person(){Name = "幸糖ミュウミュウ"},
                    new Person(){Name = "青咲ローズ"},
                    new Person(){Name = "泡沫調"},
                }) { Name = "巻乃家" });
            Familys.Add(new Family(new ObservableCollection<Person>() {
                    new Person(){Name = "白乃クロミ"},
                    new Person(){Name = "碧惺スキア"},
                    new Person(){Name = "紫吹ふうか"},
                    new Person(){Name = "菜花なな"},
                }) { Name = "白乃家" });
            Familys.Add(new Family(new ObservableCollection<Person>() {
                    new Person(){Name = "結目ユイ"},
                    new Person(){Name = "水瀬しあ"},
                }) { Name = "結目家" });
        }

        public Task<List<Family>> GetFamilysAsync() {
            var familys = _database.Table<Family>().ToListAsync();
            foreach(var x in familys) {

            }
            return _database.Table<Family>().ToListAsync();
        }

        public Task<Family> GetFamilyAsync(int id) {
            return _database.Table<Family>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveFamilyAsync(Family family) {
            foreach(var person in family.Persons) {
                if (person.ID != 0) {
                    _database.UpdateAsync(person);
                } else {
                    person.FamilyID = family.ID;
                    _database.InsertAsync(person);
                }
            }
            if (family.ID != 0) {
                return _database.UpdateAsync(family);
            } else {
                return _database.InsertAsync(family);
            }
        }

        public Task<int> DeleteFamilyAsync(Family family) {
            return _database.DeleteAsync(family);
        }

    }
}
