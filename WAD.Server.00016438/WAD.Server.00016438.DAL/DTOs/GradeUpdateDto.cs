﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAD.Server._00016438.DAL.DTOs
{
	public class GradeUpdateDto
	{
		public int Id { get; set; }
		public string ModuleName { get; set; }
		public int? Mark { get; set; }
		public int? Weighting { get; set; }
		public string Status { get; set; }
		public int? Attempt { get; set; }
	}
}
