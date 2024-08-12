using System.ComponentModel.DataAnnotations;

namespace StudentManagementShared.Models
{
    public class SystemCodeDetailTable
    {
        [Key]
        public int Id { get; set; }
        public int SystemCodeId { get; set; }
        public SystemCodeTable SystemCode { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int? OrderNumber { get; set; }
    }
}
