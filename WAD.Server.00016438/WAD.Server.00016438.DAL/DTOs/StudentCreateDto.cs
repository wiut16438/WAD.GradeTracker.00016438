﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAD.Server._00016438.DAL.DTOs
{
	public class StudentCreateDto
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email {  get; set; }
		public string Course { get; set; }
		public int Level { get; set; }
	}
}
