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
	public class StudentsRepository : IStudentsRepository
	{
		private readonly GradeTrackerDbContext _dbContext;

		public StudentsRepository(GradeTrackerDbContext dbContext) { 
			_dbContext = dbContext;
		}
		public async Task CreateStudent(Student student)
		{
			await _dbContext.Students.AddAsync(student);
			await _dbContext.SaveChangesAsync();
		}

		public async Task DeleteStudent(int id)
		{
			var student = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);

			if (student != null)
			{
				_dbContext.Students.Remove(student);
				await _dbContext.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Student>> GetAllStudents()
		{
			var students = await _dbContext.Students.ToListAsync();
			return students;
		}

		public async Task<Student?> GetStudentById(int id)
		{
			var student = await _dbContext.Students.Include(s => s.Grades).FirstOrDefaultAsync(s => s.Id == id);

			return student;
		}

		public async Task UpdateStudent(Student student)
		{
			_dbContext.Entry(student).State = EntityState.Modified;
			await _dbContext.SaveChangesAsync();
		}
	}
}
