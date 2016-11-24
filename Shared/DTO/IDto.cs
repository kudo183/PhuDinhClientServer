namespace DTO
{
    public interface IDto
    {
        int ID { get; set; }
        void SetCurrentValueAsOriginalValue();
        bool HasChange();
    }
}
