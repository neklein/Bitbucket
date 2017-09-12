using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.BLL.Models
{
    public class ListStudentResponses
    {
        public List<Student> Students { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
