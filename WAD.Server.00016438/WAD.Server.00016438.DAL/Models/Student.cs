using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WAD.Server._00016438.DAL.DTOs;

namespace WAD.Server._00016438.DAL.Models
{
	//Student Id: 00016438
	public class Student : BaseEntity
	{
		public int Id { get; set; }

		[Required]
		[StringLength(100)]
		public string FirstName { get; set; }

		[Required]
		[StringLength(100)]
		public string LastName { get; set; }

		[Required]
		[EmailAddress]
		[StringLength(100)]
		public string Email { get; set; }

		[Required]
		[StringLength(100)]
		public string Course { get; set; }


		[Required]
		[Range(3, 6)]
		public int Level { get; set; }

		public ICollection<Grade>? Grades { get; set; }
	}
}
