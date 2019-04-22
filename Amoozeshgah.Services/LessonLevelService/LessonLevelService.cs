using Amoozeshgah.Core.UoW;
using System.Collections.Generic;

using System;
using System.Linq;
using Amoozeshgah.ViewModel;
using AutoMapper;
using Amoozeshgah.Domain.Entities;
using System.Threading.Tasks;
using Amoozeshgah.Common.Domain;
using static Amoozeshgah.Common.Enums;

namespace Amoozeshgah.Services
{
    public class LessonLevelService : Service, ILessonLevelService
    {
        public LessonLevelService(IUnitOfWork uow) : base(uow) { }

        public IEnumerable<LessonLevel> GetLessonLevels()
        {
            var siteId = WebUserInfo.SiteId;
            var educationalCenter = uow.Repository<EducationalCenter>().Get(e => e.Id == siteId);

          //  var categoryItemId = educationalCenter.CategoryItemId;
            var categoryItemId = 1;

            //var lessonLevels = uow.Repository<LessonLevel>().GetAll(ll => ll.CategoryId == categoryItemId).ToList();

            //switch (categoryItemId)
            //{
            //    case 1: return lessonLevels;
            //    case 2: return 
            //}




            if (categoryItemId == (int)CategoryItemCode.LanguageCenter)
            {
                return new List<LessonLevel>
                    {
                        new LessonLevel
                        {
                            Id=1,
                            Name="مقدماتی"

                        },
                        new LessonLevel
                        {
                            Id=2,
                            Name="میانی"

                        },
                        new LessonLevel
                        {
                            Id=3,
                            Name="پیشرفته"

                        }
                    };
            }

            else if (categoryItemId == (int)CategoryItemCode.ElementaryScienceficCenter)
            {
                return new List<LessonLevel>
                    {
                        new LessonLevel
                        {
                            Id=1,
                            Name="ابتدایی"

                        }
                    };
            }
            else if (categoryItemId == (int)CategoryItemCode.FirstLevelScienceficCenter)
            {
                return new List<LessonLevel>
                    {
                        new LessonLevel
                        {
                            Id=4,
                            Name="ابتدایی"

                        },
                         new LessonLevel
                        {
                            Id=5,
                            Name="متوسطه اول"

                        }

                    };
            }
            else if (categoryItemId == (int)CategoryItemCode.SecondLevelAndKonkorScienceficCenter)
            {
                return new List<LessonLevel>
                    {
                        new LessonLevel
                        {
                            Id=4,
                            Name="ابتدایی"

                        },
                         new LessonLevel
                        {
                            Id=5,
                            Name="متوسطه اول"

                        },
                         new LessonLevel
                        {
                            Id=6,
                            Name="متوسطه دوم و کنکور"

                        }
                    };
            }
            else
            {
                return null;
            }
        }
    }

}
