using System;
using System.Collections.ObjectModel;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows;

namespace myServices
{
    internal class ServicesModel
    {
        public event Action<ServiceController> ItemChange;

        private ServiceController[] _services;

        public ServiceController[] Services => _services;

        public ServicesModel()
        {
            _services = ServiceController.GetServices();
        }

        public async Task StopService(ServiceController service)
        {
            await Task.Run(() =>
            {
                try
                {
                    TimeSpan timeout = TimeSpan.FromMilliseconds(500);

                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Access is denied");
                    Console.WriteLine(ex.ToString());
                }
            });
            OnServiceChange(service);
        }

        public async Task StartService(ServiceController service)
        {
            await Task.Run(() =>
            {
                try
                {
                    TimeSpan timeout = TimeSpan.FromMilliseconds(500);

                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Access is denied");
                    Console.WriteLine(ex.ToString());
                }
            });
            OnServiceChange(service);
        }

        private void OnServiceChange(ServiceController service)
        {
            ItemChange?.Invoke(service);
        }

    }

}
