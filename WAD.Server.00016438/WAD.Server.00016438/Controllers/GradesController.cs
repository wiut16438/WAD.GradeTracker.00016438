using Microsoft.AspNetCore.Mvc;
using WAD.Server._00016438.DAL.Models;
using WAD.Server._00016438.DAL.Repositories;

namespace WAD.Server._00016438.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GradesController : ControllerBase
	{
		private readonly IGradesRepository _gradesRepository;

		public GradesController(IGradesRepository gradesRepository) {
			_gradesRepository = gradesRepository;
		}

		[HttpGet]
		public async Task<IEnumerable<Grade>> GetGrades()
		{
			return await _gradesRepository.GetAllGrades();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Grade>> GetGrade(int id)
		{
			var grade = await _gradesRepository.GetGradeById(id);

			if (grade == null)
			{
				return NotFound();
			}

			return Ok(grade);
		}


		[HttpPut("{id}")]
		public async Task<IActionResult> EditGrade(int id, Grade grade)
		{
			if (id != grade.Id)
			{
				return BadRequest();
			}

			await _gradesRepository.UpdateGrade(grade);
			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<Grade>> AddGrade(Grade grade)
		{
			await _gradesRepository.CreateGrade(grade);
			return CreatedAtAction(nameof(GetGrade), new { id = grade.Id }, grade);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteGrade(int id)
		{
			await _gradesRepository.DeleteGrade(id);
			return NoContent();
		}
	}
}
