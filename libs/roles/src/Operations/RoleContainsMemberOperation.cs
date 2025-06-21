namespace Roblox.Roles;

using Operations;

using Enums;
using Models;
using Entities;

/// <summary>
/// Operation to check wether a user has a role.
/// </summary>
public class RoleContainsMemberOperation : IResultOperation<GetUserRoleSetRequest, bool>
{
    /// <inheritdoc cref="IResultOperation{TOutput}"/>
    public (bool Output, OperationError Error) Execute(GetUserRoleSetRequest request)
    {
        if (request.UserID == default(long)) return (false, new OperationError(UserRoleSetError.InvalidUserId));
        
        RoleSet roleSet = null;

        if (request.ID.HasValue) roleSet = RoleSet.Get(request.ID.Value);
        if (!string.IsNullOrEmpty(request.Name)) roleSet = RoleSet.GetByName(request.Name);

        if (roleSet == null) return (false, new OperationError(RoleSetError.RoleSetDoesNotExist));

        UserRoleSet userRoleSet = UserRoleSet.GetByUserIDAndRoleSetID(
            request.UserID,
            roleSet.ID
        );
        return (userRoleSet != null, null);
    }
}
