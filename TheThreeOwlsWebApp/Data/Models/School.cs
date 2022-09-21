using System.ComponentModel.DataAnnotations;

namespace TheThreeOwlsWebApp.Data.Models
{
    public class School
    {
        [Key]
        public int Id { get; init; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Telephone { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Url]
        public string FacebookPath { get; set; }
    }
}
