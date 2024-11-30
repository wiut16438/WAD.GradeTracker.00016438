using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAD.Server._00016438.DAL.DTOs
{
	public class StudentCreateDto
	{
		[Required(ErrorMessage = "First name is required.")]
		[StringLength(100, ErrorMessage = "First name cannot exceed 100 characters.")]
		public string FirstName { get; set; }


		[Required(ErrorMessage = "Last name is required.")]
		[StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters.")]
		public string LastName { get; set; }


		[Required(ErrorMessage = "Email is required.")]
		[EmailAddress(ErrorMessage = "Please enter a valid email address.")]
		[StringLength(100, ErrorMessage = "Email cannot exceed 255 characters.")]
		public string Email {  get; set; }


		[Required(ErrorMessage = "Course name is required")]
		[StringLength(100, ErrorMessage = "Course name cannot exceed 100 characters.")]
		public string Course { get; set; }


		[Range(3, 6, ErrorMessage = "Level must be between 3 and 6.")]
		public int Level { get; set; }
	}
}
