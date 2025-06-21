namespace Roblox.Roles;

using System;

using EventLog;
using Operations;

using Enums;
using Models;
using Entities;

/// <summary>
/// Operation to get a <see cref="UserRoleSet"/> by a User ID and <see cref="RoleSet.Name"/>.
/// </summary>
public class GetUserRoleSetOperation : IResultOperation<GetUserRoleSetRequest, UserRoleSetPayload>
{
    private readonly ILogger _Logger;

    /// <summary>
    /// Constructs a new instance of <see cref="GetUserRoleSetOperation"/>.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/></param>
    /// <exception cref="ArgumentNullException">
    /// - <paramref name="logger"/> cannot be null.
    /// </exception>
    public GetUserRoleSetOperation(ILogger logger)
    {
        _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc cref="IResultOperation{TInput, TOutput}"/>
    public (UserRoleSetPayload Output, OperationError Error) Execute(GetUserRoleSetRequest request)
    {
        if (request.UserID == default(long)) return (null, new(UserRoleSetError.InvalidUserId));
        if (string.IsNullOrWhiteSpace(request.Name)) return (null, new(RoleSetError.InvalidRoleSetName));

        RoleSet roleSet = RoleSet.GetByName(request.Name);
        if (roleSet == null) return (null, new OperationError(RoleSetError.RoleSetDoesNotExist));

        _Logger.Information(
            "GetUserRoleSets, User ID = {0}, Role Name = {1}, Role ID = {2}", 
            request.UserID, 
            request.Name, 
            roleSet.ID
        );

        UserRoleSet userRoleSet = UserRoleSet.GetByUserIDAndRoleSetID(
            request.UserID, 
            roleSet.ID
        );
        if (userRoleSet == null) return (null, new(UserRoleSetError.UserRoleSetDoesNotExist));

        return (new UserRoleSetPayload(userRoleSet), null);
    }
}
