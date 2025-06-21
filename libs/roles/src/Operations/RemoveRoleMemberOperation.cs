namespace Roblox.Roles;

using Operations;

using Enums;
using Models;
using Entities;

/// <summary>
/// Operation for removing a user from a <see cref="RoleSet"/>.
/// </summary>
public class RemoveRoleMemberOperation : IOperation<ModifyRoleMemberRequest>
{
    /// <inheritdoc cref="IResultOperation{TOutput}"/>
    public OperationError Execute(ModifyRoleMemberRequest request)
    {
        if (request.UserID == default(long)) return new OperationError(UserRoleSetError.InvalidUserId);

        RoleSet roleSet = null;

        if (request.ID.HasValue) roleSet = RoleSet.Get(request.ID.Value);
        if (!string.IsNullOrWhiteSpace(request.Name)) roleSet = RoleSet.GetByName(request.Name);

        if (roleSet == null) return new OperationError(RoleSetError.RoleSetDoesNotExist);

        UserRoleSet userRoleSet = UserRoleSet.GetByUserIDAndRoleSetID(
            request.UserID, 
            roleSet.ID
        );
        userRoleSet?.Delete();
        return null;
    }
}
