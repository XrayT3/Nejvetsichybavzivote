using System;
using System.Collections.ObjectModel;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace myServices
{
    internal class ServicesModel
    {
        public event Action<ServiceController> ItemChange;

        private ObservableCollection<ServiceController> _serviceItems;
        public ObservableCollection<ServiceController> ServiceItems => _serviceItems;

        public ServicesModel()
        {
            _serviceItems = new ObservableCollection<ServiceController>();
            Initialization();
        }

        public void Initialization()
        {
            ServiceController[] services = ServiceController.GetServices();

            foreach (ServiceController service in services)
            {
                _serviceItems.Add(service);
            }
        }

        public async Task StopService(ServiceController service)
        {
            await Task.Run(() =>
            {
                if (service.Status == ServiceControllerStatus.Running)
                {
                    try
                    {
                        service.Stop();
                        OnServiceChange(service);
                    }catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            });
        }

        public async Task StartService(ServiceController service)
        {
            await Task.Run(() =>
            {
                if (service.Status == ServiceControllerStatus.Stopped)
                {
                    try
                    {
                        service.Start();
                        OnServiceChange(service);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            });
        }

        private void OnServiceChange(ServiceController service)
        {
            ItemChange?.Invoke(service);
        }

    }

}
