
using Amoozeshgah.Common.DateConverter;
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using AutoMapper;
[assembly: WebActivatorEx.PreApplicationStartMethod(
 typeof(Amoozeshgah.Services.AutoMapperConfig), "Initialize")]


namespace Amoozeshgah.Services
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.AllowNullCollections = true;
                config.AllowNullDestinationValues = true;

                config.CreateMap<User, TermDto>().ReverseMap();
                config.CreateMap<Menu, MenuDto>().ReverseMap();
                config.CreateMap<MenuItem, MenuItemDto>().ForMember(dest => dest.Url, opt => opt.MapFrom(src => $"/{src.Controller}/{src.Action}"));
                config.CreateMap<Department, DepartmentDto>().ForMember(dest => dest.DepartmentTypeName, opt => opt.MapFrom(src => src.DepartmentType.Name));
                config.CreateMap<DepartmentDto, Department>();
                config.CreateMap<Field, FieldDto>().ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId));
                config.CreateMap<FieldDto, Field>();
                config.CreateMap<Lesson, LessonDto>().ReverseMap();
                config.CreateMap<Teacher, TeacherDto>().ReverseMap();
                config.CreateMap<Classroom, ClassroomDto>().ReverseMap();
                config.CreateMap<DepartmentType, DepartmentTypeDto>().ReverseMap();
                config.CreateMap<Course, CourseDto>();
                config.CreateMap<CourseDto, Course>()
                    .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDateJalali.ToGeorgianDateTime()));

                config.CreateMap<Term, TermDto>()
                .ForMember(dest => dest.StartDateShamsi, opt => opt.MapFrom(src => src.StartDate.ToJalalDateTime(DateFormat.YearMonthDay)))
                .ForMember(dest => dest.EndDateShamsi, opt => opt.MapFrom(src => src.EndDate.ToJalalDateTime(DateFormat.YearMonthDay)));
                config.CreateMap<TermDto, Term>()
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDateShamsi.ToGeorgianDateTime()))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDateShamsi.ToGeorgianDateTime()));




            });
        }
    }
}