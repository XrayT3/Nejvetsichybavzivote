using System.Threading.Tasks;
using System.Windows;

namespace myServices.Commands
{
    internal class StopServiceCommand : AsyncCommandBase
    {
        private readonly ServicesModel _servicesModel;

        internal StopServiceCommand(ServicesModel model)
        {
            _servicesModel = model;
        }

        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter);
        }
        public override async Task ExecuteAsync(object parameter)
        {
            DataItemViewModel item = parameter as DataItemViewModel;

            if (item != null && item.Status.Equals("Running"))
            {
                await _servicesModel.StopService(item._service);
            }
            else
            {
                MessageBox.Show("Error: Object from GUI is null or running");
            }
            
        }

    }
}
