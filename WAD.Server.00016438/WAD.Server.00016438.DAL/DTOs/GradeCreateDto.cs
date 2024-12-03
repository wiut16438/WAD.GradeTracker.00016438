using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAD.Server._00016438.DAL.DTOs
{
	public class GradeCreateDto
	{
		[Required(ErrorMessage = "Module name is required.")]
		[StringLength(50, ErrorMessage = "Module name cannot exceed 50 characters.")]
		public string ModuleName { get; set; }

		[Required(ErrorMessage = "Mark is required.")]
		[Range(0, 100, ErrorMessage = "Mark must be between 0 and 100.")]
		public int Mark { get; set; }

		[Required(ErrorMessage = "Weighting is required.")]
		[Range(0, 100, ErrorMessage = "Weighting must be between 0 and 100.")]
		public int Weighting { get; set; }


		[Required(ErrorMessage = "StudentId is required.")]
		public int StudentId { get; set; }
	}
}
