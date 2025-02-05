﻿using myServices.Commands;
using myServices.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceProcess;
using System.Windows.Input;

namespace myServices
{
    internal class ServicesViewModel : ViewModelBase
    {
        public ICommand StopCommand { get; }
        public ICommand StartCommand { get; }

        private readonly ServicesModel _model;

        private readonly ObservableCollection<DataItemViewModel> _gridItems;
        public IEnumerable<DataItemViewModel> GridItems => _gridItems;

        public ServicesViewModel(ServicesModel model)
        {
            _model = model;
            _gridItems = new ObservableCollection<DataItemViewModel>();

            Initialization(_model.Services);

            StopCommand = new StopServiceCommand(model);
            StartCommand = new StartServiceCommand(model);

            _model.ItemChange += OnItemChange;
        }

        private void Initialization(ServiceController[] services)
        {   
            foreach(ServiceController servic in services)
            {
                _gridItems.Add(new DataItemViewModel(servic));
            }
        }

        /// <summary>
        /// Update status of process
        /// </summary>
        private void OnItemChange(ServiceController newService)
        {
            var oldServic = _gridItems.FirstOrDefault(i => i.DisplayName.Equals(newService.DisplayName));
            int index = _gridItems.IndexOf(oldServic);
            _gridItems[index] = new DataItemViewModel(newService);
        }
    }
}
