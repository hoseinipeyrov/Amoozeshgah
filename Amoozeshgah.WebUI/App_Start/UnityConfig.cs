
using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Core.Repo;
using Amoozeshgah.Core.Report;
using Amoozeshgah.Core.UoW;
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.Services;
using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
using Unity.Mvc5;

namespace Amoozeshgah.WebUI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IDbContext, AppContext>(new HierarchicalLifetimeManager());

            // Roles
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType<IReportBank, ReportBank>(new HierarchicalLifetimeManager());
            // Services

            container.RegisterType<IDashboardService, DashboardService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserService, UserService>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserWithDetailService, SiteUserWithDetailService>(new HierarchicalLifetimeManager());
            container.RegisterType<IDepartmentService, DepartmentService>(new HierarchicalLifetimeManager());
            container.RegisterType<IDepartmentTypeService, DepartmentTypeService>(new HierarchicalLifetimeManager());
            container.RegisterType<IFieldService, FieldService>(new HierarchicalLifetimeManager());
            container.RegisterType<ILessonService, LessonService>(new HierarchicalLifetimeManager());
            container.RegisterType<ILessonLevelService, LessonLevelService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITeacherService, TeacherService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICourseService, CourseService>(new HierarchicalLifetimeManager());
            container.RegisterType<IClassroomService, ClassroomService>(new HierarchicalLifetimeManager());
            container.RegisterType<IClassroomTypeService, ClassroomTypeService>(new HierarchicalLifetimeManager());
            container.RegisterType<ISexService, SexService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITermService, TermService>(new HierarchicalLifetimeManager());

            


           // container.RegisterType<IOrganizationService, OrganizationService>(new HierarchicalLifetimeManager());


            //container.RegisterType<ILanguageService, LanguageService>(new HierarchicalLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}

