using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WAD.Server._00016438.DAL.Models
{
    public class Grade : BaseEntity
    {
        public int Id { get; set; }

		[ForeignKey(nameof(StudentId))]
		public int StudentId { get; set; }

		[Required(ErrorMessage = "Please enter module name")]
		[StringLength(50, ErrorMessage = "Module name cannot be longer than 50 characters.")]
		public string ModuleName { get; set; }


		[Required(ErrorMessage = "Please enter mark.")]
		[Range(0, 100, ErrorMessage = "Mark must be between 0 and 100.")]
		public int Mark { get; set; }

		[Required(ErrorMessage = "Please enter weighting.")]
		[Range(0, 100, ErrorMessage = "Weighting must be between 0 and 100.")]
		public int Weighting { get; set; }


		[Required(ErrorMessage = "Status is required.")]
		[StringLength(50, ErrorMessage = "Status cann	ot be longer than 50 characters.")]
		public string Status { get; set; }

		[Required(ErrorMessage = "Please enter number of attempts.")]
		[Range(1, int.MaxValue, ErrorMessage = "Attempt must be at least 1.")]
		public int Attempt { get; set; }


		public Student? Student { get; set; }
    }
}
