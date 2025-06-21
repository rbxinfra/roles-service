namespace Roblox.Roles;

using System.Linq;
using System.Collections.Generic;

using Operations;

using Enums;
using Entities;
using Models;

/// <summary>
/// Operation to get all members of a role set paged.
/// </summary>
public class GetRoleMembersOperation : IResultOperation<GetRoleMembersPagedRequest, ICollection<RoleMemberPayload>>
{
    /// <inheritdoc cref="IResultOperation{TInput, TOutput}"/>
    public (ICollection<RoleMemberPayload> Output, OperationError Error) Execute(GetRoleMembersPagedRequest request)
    {
        if (request.StartRowIndex < 1) return (null, new("{0} must be greater than 0", nameof(request.StartRowIndex)));
        if (request.MaximumRows < 1) return (null, new("{0} must be greater than 0", nameof(request.MaximumRows)));

        RoleSet roleSet = null;

        if (request.ID.HasValue) roleSet = RoleSet.Get(request.ID.Value);
        if (!string.IsNullOrEmpty(request.Name)) roleSet = RoleSet.GetByName(request.Name);

        if (roleSet == null) return (null, new OperationError(RoleSetError.RoleSetDoesNotExist));

        var userRoleSets = UserRoleSet.GetUserRoleSetsByRoleSetIDPaged(
            roleSet.ID,
            request.StartRowIndex,
            request.MaximumRows
        );

        return (userRoleSets.Select(userRoleSet => new RoleMemberPayload(userRoleSet.UserID, userRoleSet.Created)).ToArray(), null);
    }
}
