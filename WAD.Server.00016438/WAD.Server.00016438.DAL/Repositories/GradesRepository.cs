using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD.Server._00016438.DAL.Data;
using WAD.Server._00016438.DAL.Models;

namespace WAD.Server._00016438.DAL.Repositories
{
	public class GradesRepository : IGradesRepository
	{
		private readonly GradeTrackerDbContext _dbContext;

		public GradesRepository(GradeTrackerDbContext dbContext) {
			_dbContext = dbContext;
		}

		public async Task CreateGrade(Grade grade)
		{
			await _dbContext.Grades.AddAsync(grade);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteGrade(int id)
		{
			var grade = await _dbContext.Grades.FirstOrDefaultAsync(g => g.Id == id);

			if (grade != null)
			{
				_dbContext.Grades.Remove(grade);
				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Grade>> GetAllGrades()
		{
			var grades = await _dbContext.Grades.ToListAsync();
			return grades;
		}

		public async Task<Grade?> GetGradeById(int id)
		{
			var grade = await _dbContext.Grades.FirstOrDefaultAsync(g => g.Id == id);
			return grade;
		}

		public async Task UpdateGrade(Grade grade)
		{
			_dbContext.Entry(grade).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}


		//test mode
		public async Task<IEnumerable<Grade>> GetGradesByStudent(int studentId)
		{
			return await _dbContext.Grades.Where(g => g.Id == studentId).ToListAsync();
		}
	}
}
