using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAD.Server._00016438.DAL.Models
{
	public abstract class BaseEntity
	{
		public DateTime CreatedAt { get; set; } 

		public DateTime? UpdatedAt { get; set; }
	}
}
