using Easy.Common.Handlers;
using Easy.Common.Objects;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Security.Claims;

namespace LearningProject.Helpers
{
    public class UserProfileHandler : IUserProfileHandler
    {
        public UserProfileHandler(IHttpContextAccessor httpContextAccessor)
        {
            var currentUser = httpContextAccessor.HttpContext.User;
            if (currentUser == null)
                return;

            if (!currentUser.HasClaim(c => c.Type == ClaimTypes.UserData))
                return;

            var userData= currentUser.Claims.Single(c=>c.Type == ClaimTypes.UserData).Value;  

            this.Current= JsonConvert.DeserializeObject<UserProfile>(userData);

        }
        public UserProfile Current { get; set; } = new UserProfile();
    }
}
