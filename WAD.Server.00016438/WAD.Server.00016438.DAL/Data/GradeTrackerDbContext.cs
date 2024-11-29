using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD.Server._00016438.DAL.Models;

namespace WAD.Server._00016438.DAL.Data
{
	public class GradeTrackerDbContext : DbContext
	{
		public GradeTrackerDbContext(DbContextOptions<GradeTrackerDbContext> options) : base(options) { }
		public DbSet<Student> Students { get; set; }
		public DbSet<Grade> Grades { get; set; }
	}
}
