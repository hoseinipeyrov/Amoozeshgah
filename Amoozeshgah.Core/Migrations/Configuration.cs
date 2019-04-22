using Amoozeshgah.Core.Infrastructure;
using Amoozeshgah.Core.Seeds;
using Amoozeshgah.Core.Seeds.UserSeeds;
using Amoozeshgah.Domain.Entities;
using System.Data.Entity.Migrations;

namespace Amoozeshgah.Core.Migrations
{
    public class Configuration : DbMigrationsConfiguration<AppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AppContext context)
        {
            //  UserSeed.VandGrow(context);
            EstateStatusSeed.VandGrow(context);
            CourseHoldingTypeSeed.VandGrow(context);
            BankSeed.VandGrow(context);
            MaritalStatusSeed.VandGrow(context);
            ReligionSeed.VandGrow(context);
            EducationDegreeSeed.VandGrow(context);
            MilitaryStatusSeed.VandGrow(context);

            ShiftSeed.VandGrow(context);
            RoleSeed.VandGrow(context);
            MenuSeed.VandGrow(context);
            SexSeed.VandGrow(context);
            //ProvinceSeed.VandGrow(context);
            CategorySeed.VandGrow(context);
            SiteSeed.VandGrow(context);

            TeacherSeed.VandGrow(context);
            EducationalCenterUserSeed.VandGrow(context);
            StudentSeed.VandGrow(context);
            
            MenuSeed.VandGrow(context);
            RecruitmentTypeSeed.VandGrow(context);

            //OrganizationSeed.VandGrow(context);

            //DepartmentTypeSeed.VandGrow(context);
            //SiteSeed.VandGrow(context);
            //LanguageCenterUserRoleSeed.VandGrow(context);
            ClassroomTypeSeed.VandGrow(context);
            //MinistryOfEducationUserSeed.VandGrow(context);
            base.Seed(context);


        }
    }
}
