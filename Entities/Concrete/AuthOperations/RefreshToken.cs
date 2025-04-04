

namespace Entities
{
    public class RefreshToken:IEntity
    {
        public int Id { get; set; }
        public string Token { get; set; } 
        public int UserId { get; set; }  
        public DateTime ExpireDate { get; set; }  
        public DateTime CreatedDate { get; set; }
    }
}
