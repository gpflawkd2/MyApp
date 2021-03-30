using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCoreStudy.Models
{
    public class Note
    {

        [Key]
        public int NoteNo { get; set; }

        public string NoteTitle { get; set; }
        public string NoteContents { get; set; }

        [ForeignKey("UserNo")]
        public int UserNo { get; set; }

        public User User { get; set; }
    }
}
