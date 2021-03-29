using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCoreStudy.Models
{
    public class Note
    {

        [Key]
        public int NoteNo { get; set; }

        public string NoteTitle { get; set; }
        public string NoteContents { get; set; }
        public int UserNo { get; set; }
    }
}
