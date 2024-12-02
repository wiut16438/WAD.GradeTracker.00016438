using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD.Server._00016438.DAL.Models;

namespace WAD.Server._00016438.DAL.Repositories
{
	public interface IGradesRepository
	{
		Task<IEnumerable<Grade>> GetAllGrades();
		Task<Grade?> GetGradeById(int id);
		Task CreateGrade(Grade grade);
		Task UpdateGrade(Grade grade);
		Task DeleteGrade(int id);

		//Test mode
		Task<IEnumerable<Grade>> GetGradesByStudent(int studentId);
	}
}
