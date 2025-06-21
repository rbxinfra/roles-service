namespace Roblox.Roles;

using System;
using System.Linq;
using System.Collections.Generic;

using EventLog;
using Operations;

using Enums;
using Models;
using Entities;

/// <summary>
/// Operation to get all members of a role set paged.
/// </summary>
public class GetRoleMembersOperation : IResultOperation<GetRoleMembersPagedRequest, ICollection<RoleMemberPayload>>
{
    private readonly ILogger _Logger;

    /// <summary>
    /// Constructs a new instance of <see cref="GetRoleMembersOperation"/>.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/></param>
    /// <exception cref="ArgumentNullException">
    /// - <paramref name="logger"/> cannot be null.
    /// </exception>
    public GetRoleMembersOperation(ILogger logger)
    {
        _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc cref="IResultOperation{TInput, TOutput}"/>
    public (ICollection<RoleMemberPayload> Output, OperationError Error) Execute(GetRoleMembersPagedRequest request)
    {
        if (request.StartRowIndex < 1) return (null, new("{0} must be greater than 0", nameof(request.StartRowIndex)));
        if (request.MaximumRows < 1) return (null, new("{0} must be greater than 0", nameof(request.MaximumRows)));

        RoleSet roleSet = null;

        if (request.ID.HasValue) roleSet = RoleSet.Get(request.ID.Value);
        if (!string.IsNullOrEmpty(request.Name)) roleSet = RoleSet.GetByName(request.Name);

        if (roleSet == null) return (null, new OperationError(RoleSetError.RoleSetDoesNotExist));

        _Logger.Information(
            "GetRoleMembers, Role ID = {0}, Role Name = {1}, StartRowIndex = {2}, MaximumRows = {3}",
            roleSet.ID,
            request.Name,
            request.StartRowIndex,
            request.MaximumRows
        );

        var userRoleSets = UserRoleSet.GetUserRoleSetsByRoleSetIDPaged(
            roleSet.ID,
            request.StartRowIndex,
            request.MaximumRows
        );

        return (userRoleSets.Select(userRoleSet => new RoleMemberPayload(userRoleSet.UserID, userRoleSet.Created)).ToArray(), null);
    }
}
