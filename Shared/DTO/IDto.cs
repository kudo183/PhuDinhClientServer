namespace DTO
{
    public interface IDto
    {
        int Ma { get; set; }
        void SetCurrentValueAsOriginalValue();
        bool HasChange();
    }
}
