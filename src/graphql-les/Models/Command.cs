using System.ComponentModel.DataAnnotations;

namespace graphql_les.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }
        
        public string HowTo { get; set; }

        [Required]
        public string CommandLine { get; set; }

        [Required]
        public int PlatformId { get; set; }

        public Platform Platform { get; set; }
    }
}
