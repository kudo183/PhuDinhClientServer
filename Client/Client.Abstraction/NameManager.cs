namespace Client.Abstraction
{
    public sealed class NameManager
    {
        private static readonly NameManager _instance = new NameManager();

        public static NameManager Instance
        {
            get { return _instance; }
        }

        public string GetControllerName<T>() where T : DTO.IDto
        {
            return typeof(T).Name.Replace("Dto", "").ToLower();
        }

        public string GetViewName<T>() where T : DTO.IDto
        {
            return typeof(T).Name.Replace("Dto", "View");
        }

        public string GetViewModelName<T>() where T : DTO.IDto
        {
            return typeof(T).Name.Replace("Dto", "ViewModel");
        }
    }
}
