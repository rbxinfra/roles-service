namespace Roblox.Roles;

using Operations;

using Enums;
using Models;
using Entities;

/// <summary>
/// Operation to get a <see cref="UserRoleSet"/> by User ID and <see cref="RoleSet.ID"/> or <see cref="RoleSet.Name"/>.
/// </summary>
public class GetUserRoleSetOperation : IResultOperation<GetUserRoleSetRequest, UserRoleSetPayload>
{
    /// <inheritdoc cref="IResultOperation{TInput, TOutput}"/>
    public (UserRoleSetPayload Output, OperationError Error) Execute(GetUserRoleSetRequest request)
    {
        if (request.UserID == default(long)) return (null, new(UserRoleSetError.InvalidUserId));

        RoleSet roleSet = null;

        if (request.ID.HasValue) roleSet = RoleSet.Get(request.ID.Value);
        if (!string.IsNullOrWhiteSpace(request.Name)) roleSet = RoleSet.GetByName(request.Name);

        if (roleSet == null) return (null, new OperationError(RoleSetError.RoleSetDoesNotExist));

        UserRoleSet userRoleSet = UserRoleSet.GetByUserIDAndRoleSetID(
            request.UserID, 
            roleSet.ID
        );
        if (userRoleSet == null) return (null, new(UserRoleSetError.UserRoleSetDoesNotExist));

        return (new UserRoleSetPayload(userRoleSet), null);
    }
}
