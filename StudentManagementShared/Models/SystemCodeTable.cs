using System.ComponentModel.DataAnnotations;

namespace StudentManagementShared.Models
{
    public class SystemCodeTable
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
