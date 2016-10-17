using Client.Abstraction;
using DTO;

namespace Client
{
    public class ViewModelFactory : IViewModelFactory
    {
        public object CreateViewModel<T>() where T : IDto
        {
            var vmName = NameManager.Instance.GetViewModelName<T>();
            var viewModelType = System.Type.GetType("Client.ViewModel." + vmName);
            return System.Activator.CreateInstance(viewModelType);
        }
    }
}
