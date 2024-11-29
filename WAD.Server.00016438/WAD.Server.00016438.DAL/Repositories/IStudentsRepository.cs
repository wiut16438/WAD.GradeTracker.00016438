using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAD.Server._00016438.DAL.Models;

namespace WAD.Server._00016438.DAL.Repositories
{
	public interface IStudentsRepository
	{
		Task<IEnumerable<Student>> GetAllStudents();
		Task<Student?> GetStudentById(int id);

		Task CreateStudent(Student student);

		Task UpdateStudent(Student student);

		Task DeleteStudent(int id);
	}
}
