﻿
using Amoozeshgah.Domain.Entities;
using Amoozeshgah.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amoozeshgah.Services
{
    public interface IOrganizationService
    {
        IEnumerable<Organization> GetAllProvincess();
        IEnumerable<Organization> GetAllAreas();

    }
}
