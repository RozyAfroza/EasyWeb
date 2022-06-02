using Easy.Common.Enums;
using Easy.Common.Handlers;
using LearningProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProject.Helpers
{
    public  class PermissionHandler : IPermissionHandler
    {
        private readonly IUserProfileHandler _userProfileHandler;
        private readonly TestDbContext _context;

        public PermissionHandler(IUserProfileHandler userProfileHandler, TestDbContext context)
        {
            _userProfileHandler = userProfileHandler;
            _context = context;
        }

        public bool HasPermission(int permissionID)
        {
            if (IsAdmin())
                return true;

            bool hasPermission = _context.UserPermissions
                .Any(up => up.UserId == _userProfileHandler.Current.UserID
                           && up.PermissionNo == permissionID);
                         
            return hasPermission;
        }

        public async Task<bool> HasPermissionAsync(int permissionID)
        {
            if (await IsAdminAsync())
                return true;

            bool hasPermission = await _context.UserPermissions
                .AnyAsync(up => up.UserId == _userProfileHandler.Current.UserID
                           && up.PermissionNo == permissionID);

            return hasPermission;
        }

        public bool IsAdmin()
        {
            var userCredential = _context.UserCredentials
               .Single(up => up.EntityId == _userProfileHandler.Current.UserID);

            return userCredential.UserTypeID == (int)UserTypeEnum.Admin
                   || userCredential.UserTypeID == (int)UserTypeEnum.Super;
        }

        public async Task<bool> IsAdminAsync()
        {
            var userCredential = await _context.UserCredentials
               .SingleAsync(up => up.EntityId == _userProfileHandler.Current.UserID);
                             ;

            return userCredential.UserTypeID == (int)UserTypeEnum.Admin
                   || userCredential.UserTypeID == (int)UserTypeEnum.Super;
        }

        public bool IsSuper()
        {
            var userCredential =  _context.UserCredentials
              .Single(up => up.EntityId == _userProfileHandler.Current.UserID);

            return userCredential.UserTypeID == (int)UserTypeEnum.Super;
        }

        public async Task<bool> IsSuperAsync()
        {
            var userCredential =await _context.UserCredentials
             .SingleAsync(up => up.EntityId == _userProfileHandler.Current.UserID);

            return userCredential.UserTypeID == (int)UserTypeEnum.Super;
        }
    }
}
