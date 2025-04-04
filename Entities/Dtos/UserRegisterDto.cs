

using Core;

namespace Entities
{
    public class UserRegisterDto:IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
