namespace Roblox.Roles;

using System;

using EventLog;
using Operations;

using Enums;
using Models;
using Entities;

/// <summary>
/// Operation to check whether a User has a <see cref="RoleSet"/>.
/// </summary>
public class RoleContainsMemberOperation : IResultOperation<GetUserRoleSetRequest, bool>
{
    private readonly ILogger _Logger;

    /// <summary>
    /// Constructs a new instance of <see cref="RoleContainsMemberOperation"/>.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/></param>
    /// <exception cref="ArgumentNullException">
    /// - <paramref name="logger"/> cannot be null.
    /// </exception>
    public RoleContainsMemberOperation(ILogger logger)
    {
        _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc cref="IResultOperation{TOutput}"/>
    public (bool Output, OperationError Error) Execute(GetUserRoleSetRequest request)
    {
        if (request.UserID == default(long)) return (false, new OperationError(UserRoleSetError.InvalidUserId));
        if (string.IsNullOrEmpty(request.Name)) return (false, new OperationError(RoleSetError.InvalidRoleSetName));

        RoleSet roleSet = RoleSet.GetByName(request.Name);
        if (roleSet == null) return (false, new OperationError(RoleSetError.RoleSetDoesNotExist));

        _Logger.Information(
            "RoleContainsMember, User ID = {0}, Role Name = {1}, Role ID = {2}",
            request.UserID,
            request.Name,
            roleSet.ID
        );

        UserRoleSet userRoleSet = UserRoleSet.GetByUserIDAndRoleSetID(
            request.UserID,
            roleSet.ID
        );
        return (userRoleSet != null, null);
    }
}
