using myServices.ViewModel;
using System.ServiceProcess;
using Microsoft.Win32;

namespace myServices
{
    internal class DataItemViewModel : ViewModelBase
    {
        public ServiceController _service;

        public string _serviceAccountName;
        public string Name => _service.ServiceName;
        public string DisplayName => _service.DisplayName;
        public string Status => _service.Status.ToString();
        public string Account => _serviceAccountName;

        public DataItemViewModel(ServiceController service)
        {
            _service = service;
            RegistryKey fileServiceKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\" + service.ServiceName);
            _serviceAccountName = (string)fileServiceKey.GetValue("ObjectName");
        }
    }
}
