using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Altinn.App.PlatformServices.Extensions;
using Altinn.App.Services.Interface;

namespace Finanstilsynet.Altinn
{
    public static class FullName
    {
        /// <summary>
        /// Concatenates part of name to full name. Parts are trimmed, null is
        /// interpreted as empty string.
        /// </summary>
        /// <example>
        /// Concat(" a ", null, " c ") // "a c"
        /// </example>
        public static string Concat(string? firstname, string? middlename, string? lastname)
        {
            var sb = new StringBuilder();

            firstname = firstname?.Trim() ?? string.Empty;
            middlename = middlename?.Trim() ?? string.Empty;
            lastname = lastname?.Trim() ?? string.Empty;

            sb.Append(firstname);
            if (!string.IsNullOrEmpty(firstname))
                sb.Append(' ');
            sb.Append(middlename);
            if (!string.IsNullOrEmpty(middlename))
                sb.Append(' ');
            sb.Append(lastname);
            return sb.ToString().Trim();
        }

        /// Returns full name of logged in user. Throws if user cannot be located.
        public static async Task<string> GetCurrentUserFullName(IHttpContextAccessor httpContextAccessor, IProfile profileService)
        {
            var userId = httpContextAccessor.HttpContext?.User.GetUserIdAsInt();
            if (!userId.HasValue)
                throw new ArgumentNullException(nameof(httpContextAccessor), "Unable to get currently logged in Altinn user");

            var userProfile = await profileService.GetUserProfile(userId.Value);
            return Concat(
                userProfile.Party.Person.FirstName,
                userProfile.Party.Person.MiddleName,
                userProfile.Party.Person.LastName
            );
        }
    }
}
