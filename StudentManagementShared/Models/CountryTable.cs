using System.ComponentModel.DataAnnotations;

namespace StudentManagementShared.Models
{
    public class CountryTable
    {
        [Key]
        public int  Id{ get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

    }
}
