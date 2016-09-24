using Server.Entities;

namespace Server.DTOs
{
    public class UserDto : huypq.SwaMiddleware.SwaIDto<User>
    {
        public int Ma { get; set; }
        public string Email { get; set; }
        public System.DateTime NgayTao { get; set; }

        public void FromEntity(User entity)
        {
            Ma = entity.Ma;
            Email = entity.Email;
            NgayTao = entity.NgayTao;
        }

        public User ToEntity()
        {
            return new User()
            {
                Ma = Ma,
                Email = Email,
                NgayTao = NgayTao
            };
        }
    }
}
