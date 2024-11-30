using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAD.Server._00016438.DAL.DTOs;
using WAD.Server._00016438.DAL.Models;
using WAD.Server._00016438.DAL.Repositories;

namespace WAD.Server._00016438.Controllers
{
	//00016438
	[Route("api/[controller]")]
	[ApiController]
	public class GradesController : ControllerBase
	{
		private readonly IGradesRepository _gradesRepository;
		private readonly IMapper _mapper;

		public GradesController(IGradesRepository gradesRepository, IMapper mapper) {
			_gradesRepository = gradesRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IEnumerable<GradeDto>> GetGrades()
		{
			var grades = await _gradesRepository.GetAllGrades();
			return _mapper.Map<IEnumerable<GradeDto>>(grades);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<GradeDto>> GetGrade(int id)
		{
			var grade = await _gradesRepository.GetGradeById(id);

			if (grade == null)
			{
				return NotFound();
			}

			return Ok(_mapper.Map<GradeDto>(grade));
		}


		[HttpPut("{id}")]
		public async Task<IActionResult> EditGrade(int id, GradeUpdateDto gradeUpdateDto)
		{
			if (id != gradeUpdateDto.Id)
			{
				return BadRequest();
			}

			var grade = await _gradesRepository.GetGradeById(gradeUpdateDto.Id);

			if (grade == null)
			{
				return NotFound();
			}

			_mapper.Map(gradeUpdateDto, grade);
			grade.UpdatedAt = DateTime.UtcNow;
			grade.Status = gradeUpdateDto.Mark >= 40 ? "Pass" : "Fail";

			await _gradesRepository.UpdateGrade(grade);
			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<Grade>> AddGrade([FromBody] GradeDto gradeDto)
		{
			var grade = _mapper.Map<Grade>(gradeDto);

			grade.CreatedAt = DateTime.UtcNow;
			grade.Status = gradeDto.Mark >= 40 ? "Pass" : "Fail";

			await _gradesRepository.CreateGrade(grade);
			return CreatedAtAction(nameof(GetGrade), new { id = grade.Id }, grade);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteGrade(int id)
		{
			var grade = await _gradesRepository.GetGradeById(id);

			if (grade == null)
			{
				return NotFound();
			}

			await _gradesRepository.DeleteGrade(id);
			return NoContent();
		}
	}
}
