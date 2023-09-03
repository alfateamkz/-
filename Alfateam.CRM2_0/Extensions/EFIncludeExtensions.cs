using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Alfateam.CRM2_0.Extensions
{
    public static class EFIncludeExtensions
    {
        public static IIncludableQueryable<T, List<OrganizationOffice>> IncludeAvailability<T>(this IQueryable<T> dbset) where T : AvailabilityModel
        {
            return dbset.Include(o => o.Availability).ThenInclude(o => o.AllowedOrganizations)
                        .Include(o => o.Availability).ThenInclude(o => o.DisallowedOrganizations)
                        .Include(o => o.Availability).ThenInclude(o => o.AllowedOffices)
                        .Include(o => o.Availability).ThenInclude(o => o.DisallowedOffices);
        }
    }
}
