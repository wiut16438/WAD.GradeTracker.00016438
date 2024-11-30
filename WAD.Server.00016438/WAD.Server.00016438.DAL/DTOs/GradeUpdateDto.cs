using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAD.Server._00016438.DAL.DTOs
{
	public class GradeUpdateDto
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Module name is required.")]
		[StringLength(50, ErrorMessage = "Module name cannot exceed 50 characters.")]
		public string ModuleName { get; set; }

		[Range(0, 100, ErrorMessage = "Mark must be between 0 and 100.")]
		public int? Mark { get; set; }

		[Range(0, 100, ErrorMessage = "Weighting must be between 0 and 100.")]
		public int? Weighting { get; set; }
	}
}
