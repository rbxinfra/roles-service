namespace Roblox.Roles;

using System;

using EventLog;
using Operations;

using Enums;
using Models;
using Entities;

/// <summary>
/// Operation for removing a user from a <see cref="RoleSet"/>.
/// </summary>
public class RemoveRoleMemberOperation : IOperation<ModifyRoleMemberRequest>
{
    private readonly ILogger _Logger;

    /// <summary>
    /// Constructs a new instance of <see cref="RemoveRoleMemberOperation"/>.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/></param>
    /// <exception cref="ArgumentNullException">
    /// - <paramref name="logger"/> cannot be null.
    /// </exception>
    public RemoveRoleMemberOperation(ILogger logger)
    {
        _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc cref="IResultOperation{TOutput}"/>
    public OperationError Execute(ModifyRoleMemberRequest request)
    {
        if (request.UserID == default(long)) return new OperationError(UserRoleSetError.InvalidUserId);
        if (string.IsNullOrWhiteSpace(request.Name)) return new OperationError(RoleSetError.InvalidRoleSetName);

        RoleSet roleSet = RoleSet.GetByName(request.Name);
        if (roleSet == null) return new OperationError(RoleSetError.RoleSetDoesNotExist);

        _Logger.Information(
            "RemoveRoleMember, User ID = {0}, Role Name = {1}, Role ID = {2}", 
            request.UserID, 
            request.Name, 
            roleSet.ID
        );

        UserRoleSet userRoleSet = UserRoleSet.GetByUserIDAndRoleSetID(
            request.UserID, 
            roleSet.ID
        );
        userRoleSet?.Delete();
        return null;
    }
}
