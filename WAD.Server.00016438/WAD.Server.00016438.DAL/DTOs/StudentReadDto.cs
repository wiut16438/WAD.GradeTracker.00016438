using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAD.Server._00016438.DAL.DTOs
{
	public class StudentReadDto
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public string Course { get; set; }

		public int Level { get; set; }

		public ICollection<GradeDto> Grades { get; set; }
	}

}
