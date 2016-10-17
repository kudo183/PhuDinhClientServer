namespace Client.Abstraction
{
    public interface IViewModelFactory
    {
        object CreateViewModel<T>() where T : DTO.IDto;
    }
}
