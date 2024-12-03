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
	//Student Id: 00016438
	public class Grade : BaseEntity
    {
        public int Id { get; set; }

		[ForeignKey(nameof(StudentId))]
		public int StudentId { get; set; }

		[Required]
		[StringLength(50)]
		public string ModuleName { get; set; }

		[Required]
		[Range(0, 100)]
		public int Mark { get; set; }

		[Required]
		[Range(0, 100)]
		public int Weighting { get; set; }


		[Required]
		[StringLength(50)]
		public string Status { get; set; }


		public Student? Student { get; set; }
    }
}
