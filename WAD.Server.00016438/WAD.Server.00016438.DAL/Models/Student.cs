using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WAD.Server._00016438.DAL.Models
{
	public class Student
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Please enter your first name.")]
		[StringLength(100, ErrorMessage = "First name cannot exceed 100 characters.")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Please enter your last name.")]
		[StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters.")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Please enter your valid email.")]
		[EmailAddress(ErrorMessage = "Please enter a valid email address.")]
		[StringLength(255)]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please enter your course of study.")]
		[StringLength(100, ErrorMessage = "Course name cannot exceed 100 characters.")]
		public string Course { get; set; }

		[Required(ErrorMessage = "Please enter your level of study.")]
		[Range(3, 6, ErrorMessage = "Level of study must be between 3 and 6.")]
		public int Level { get; set; }

		public ICollection<Grade> Grades { get; set; }
	}
}
