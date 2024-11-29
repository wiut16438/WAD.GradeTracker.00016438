using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAD.Server._00016438.DAL.Models
{
    public class Grade
    {
        public int Id { get; set; }

		[ForeignKey(nameof(StudentId))]
		public int StudentId { get; set; }

		[Range(0, 100, ErrorMessage = "Weighting must be between 0 and 100.")]
		public int Weighting { get; set; }

		[Range(0, 100, ErrorMessage = "Mark must be between 0 and 100.")]
		public int Mark { get; set; }

		[Required(ErrorMessage = "Status is required.")]
		[StringLength(50, ErrorMessage = "Status cannot be longer than 50 characters.")]
		public string Status { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Attempt must be at least 1.")]
		public int Attempt { get; set; }

        public Student Student { get; set; }
    }
}
