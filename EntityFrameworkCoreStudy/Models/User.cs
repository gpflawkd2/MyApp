using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCoreStudy.Models
{
    public class User
    {
        [Key]
        public int UserNo { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string UserPassword { get; set; }
    }
}
