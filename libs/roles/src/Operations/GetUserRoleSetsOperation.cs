namespace Roblox.Roles;

using System.Linq;
using System.Collections.Generic;

using Operations;

using Models;
using Entities;

/// <summary>
/// Operation to get all user role sets paged.
/// </summary>
public class GetUserRoleSetsOperation : IResultOperation<GetUserRoleSetsPagedRequest, ICollection<UserRoleSetPayload>>
{
    /// <inheritdoc cref="IResultOperation{TInput, TOutput}"/>
    public (ICollection<UserRoleSetPayload> Output, OperationError Error) Execute(GetUserRoleSetsPagedRequest request)
    {
        if (request.StartRowIndex < 1) return (null, new("{0} must be greater than 0", nameof(request.StartRowIndex)));
        if (request.MaximumRows < 1) return (null, new("{0} must be greater than 0", nameof(request.MaximumRows)));

        var userRoleSets = UserRoleSet.GetAllUserRoleSetsPaged(
            request.StartRowIndex, 
            request.MaximumRows
        );

        return (userRoleSets.Select(userRoleSet => new UserRoleSetPayload(userRoleSet)).ToArray(), null);
    }
}
