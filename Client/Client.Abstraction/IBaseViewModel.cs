namespace Client.Abstraction
{
    public interface IBaseViewModel<T> : SimpleDataGrid.ViewModel.EditableGridViewModel<T>
    {
        bool IsValid { get; set; }
        void Load();
        void Save();
    }
}
