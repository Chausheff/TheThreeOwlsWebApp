using System.ComponentModel.DataAnnotations;

namespace TheThreeOwlsWebApp.Models.Contacts
{
    public class ContactsEditModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; init; }

        [Required]
        public string Telephone { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required]
        [Url]
        public string FacebookPath { get; init; }
    }
}
