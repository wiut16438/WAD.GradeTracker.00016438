using AutoMapper;
using WAD.Server._00016438.DAL.DTOs;
using WAD.Server._00016438.DAL.Models;

namespace WAD.Server._00016438.Profiles
{
	//00016438
	public class MappingProfile : Profile
	{
        public MappingProfile()
        {
            CreateMap<Student, StudentCreateDto>();
            CreateMap<Student, StudentReadDto>();
            CreateMap<Student, StudentUpdateDto>();
			CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentUpdateDto, Student>();

            CreateMap<Grade, GradeUpdateDto>();
            CreateMap<Grade, GradeDto>();
            CreateMap<GradeUpdateDto, Grade>();
            CreateMap<GradeDto, Grade>();

		}
    }
}
