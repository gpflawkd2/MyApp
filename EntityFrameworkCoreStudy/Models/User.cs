using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreStudy.Models
{
    // Model-Class Mapping
    // 1) Annotaion Mapping

    // Mapping 해야할 테이블명
    // [Table("s_users")]
    public class User
    {
        [Key]
        public int UserNo { get; set; }
        // Mapping 해야할 컬럼명
        // [Column("s_userName")]
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string UserPassword { get; set; }
    }
}
