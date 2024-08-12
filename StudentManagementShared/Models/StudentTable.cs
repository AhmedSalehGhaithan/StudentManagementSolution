using System.ComponentModel.DataAnnotations;
namespace StudentManagementShared.Models
{
    public class StudentTable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public  string FirstName { get; set; }
        [Required]
        public  string MiddleName { get; set; }
        [Required]
        public  string LastName { get; set; }
        [Required]
        public  string EmailAddress { get; set; }
        [Required]
        public  string Address { get; set; }
        [Required]
        public  string PhoneNumber { get; set; }
        [Required]
        public  string Country { get; set; }

    }
}
