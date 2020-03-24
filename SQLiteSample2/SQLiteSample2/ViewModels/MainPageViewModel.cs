using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Reactive.Bindings;
using SQLiteSample2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLiteSample2.ViewModels {
    public class MainPageViewModel : ViewModelBase {

        public ReactiveCommand<object> Command { get; }
        public MainPageViewModel(INavigationService navigationService,CoreModel coreModel)
            : base(navigationService) {
            Command = new ReactiveCommand<object>().WithSubscribe(x => coreModel.DbSave());
        }
    }
}
