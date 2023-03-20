using Microsoft.AspNetCore.Identity;

namespace CRUDCleanArchitecture.Core.Domain.IdentityEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        // add extra properties
        public string? PersonName { get; set; }

    }
}
