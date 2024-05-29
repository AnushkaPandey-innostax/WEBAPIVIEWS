
using Microsoft.AspNetCore.Identity;

namespace WEBAPIVIEWS.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}

