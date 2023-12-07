using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BasicASP.NET.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "กรุณาป้อนชื่อ-นามสุกล นักเรียน")]
        [DisplayName("ชื่อ-สกุลนักเรียน")]
        public string Name { get; set; }

        [Required(ErrorMessage = "กรูณากรอกตัวเลข")]
        [DisplayName("คะแนนสอบ")]
        [Range(0, 100, ErrorMessage = "กรุณากรอกตัวเลข 0-100")]
        public int Score { get; set; }
    }
}
