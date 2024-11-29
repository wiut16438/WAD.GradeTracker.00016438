using Microsoft.AspNetCore.Mvc;
using WAD.Server._00016438.DAL.Models;
using WAD.Server._00016438.DAL.Repositories;

namespace WAD.Server._00016438.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly IStudentsRepository _studentsRepository;

		public StudentsController(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

		[HttpGet]
		public async Task<IEnumerable<Student>> GetStudents()
		{
			return await _studentsRepository.GetAllStudents();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Student>> GetStudent(int id)
		{
			var student = await _studentsRepository.GetStudentById(id);

			if (student == null)
			{
				return NotFound();
			}

			return Ok(student);
		}


		[HttpPut("{id}")]
		public async Task<IActionResult> EditStudent(int id, Student student)
		{
			if (id != student.Id)
			{
				return BadRequest();
			}

			await _studentsRepository.UpdateStudent(student);
			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<Student>> AddStudent(Student student)
		{
			await _studentsRepository.CreateStudent(student);
			return CreatedAtAction(nameof(GetStudent), new {id = student.Id}, student);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteStudent(int id)
		{
			await _studentsRepository.DeleteStudent(id);
			return NoContent();
		}
	}
}
