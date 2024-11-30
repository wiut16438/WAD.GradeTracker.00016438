using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD.Server._00016438.DAL.DTOs;
using WAD.Server._00016438.DAL.Models;
using WAD.Server._00016438.DAL.Repositories;

namespace WAD.Server._00016438.Controllers
{
	//00016438
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly IStudentsRepository _studentsRepository;
		private readonly IMapper _mapper;

		public StudentsController(IStudentsRepository studentsRepository, IMapper mapper)
        {
            _studentsRepository = studentsRepository;
			_mapper = mapper;
        }

		[HttpGet]
		public async Task<IEnumerable<StudentReadDto>> GetStudents()
		{
			var students = await _studentsRepository.GetAllStudents();
			return _mapper.Map<IEnumerable<StudentReadDto>>(students);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<StudentReadDto>> GetStudent(int id)
		{
			var student = await _studentsRepository.GetStudentById(id);

			if (student == null)
			{
				return NotFound();
			}

			return Ok(_mapper.Map<StudentReadDto>(student));
		}


		[HttpPut("{id}")]
		public async Task<IActionResult> EditStudent(int id, StudentUpdateDto studentUpdateDto)
		{
			if (id != studentUpdateDto.Id)
			{
				return BadRequest();
			}

			var student = await _studentsRepository.GetStudentById(id);
			if (student == null)
			{
				return NotFound();
			}

			_mapper.Map(studentUpdateDto, student);
			student.UpdatedAt = DateTime.UtcNow;
			await _studentsRepository.UpdateStudent(student);
			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<Student>> AddStudent([FromBody] StudentCreateDto studentCreateDto)
		{
			var student = _mapper.Map<Student>(studentCreateDto);
			student.CreatedAt = DateTime.UtcNow;
			await _studentsRepository.CreateStudent(student);
			return CreatedAtAction(nameof(GetStudent), new {id = student.Id}, student);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteStudent(int id)
		{
			var student = await _studentsRepository.GetStudentById(id);

			if (student == null)
			{
				return NotFound();
			}

			await _studentsRepository.DeleteStudent(id);
			return NoContent();
		}
	}
}
