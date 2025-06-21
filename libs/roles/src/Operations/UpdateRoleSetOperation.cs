namespace Roblox.Roles;

using System;

using EventLog;
using Operations;

using Enums;
using Models;
using Entities;

/// <summary>
/// Operation to update a <see cref="RoleSet"/> by <see cref="RoleSet.ID"/>.
/// </summary>
public class UpdateRoleSetOperation : IOperation<ModifyRoleSetRequest>
{
    private readonly ILogger _Logger;

    /// <summary>
    /// Constructs a new instance of <see cref="UpdateRoleSetOperation"/>.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/></param>
    /// <exception cref="ArgumentNullException">
    /// - <paramref name="logger"/> cannot be null.
    /// </exception>
    public UpdateRoleSetOperation(ILogger logger)
    {
        _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc cref="IResultOperation{TOutput}"/>
    public OperationError Execute(ModifyRoleSetRequest request)
    {
        RoleSet roleSet = RoleSet.Get(request.ID);
        if (roleSet == null) return new(RoleSetError.RoleSetDoesNotExist);

        _Logger.Information(
            "UpdateRoleSet, Role Name = {0}, Role ID = {1}, Role Rank = {2}",
            request.Name,
            roleSet.ID,
            request.Rank
        );

        if (!string.IsNullOrEmpty(request.Name)) roleSet.Name = request.Name;
        if (request.Rank != default(int))  roleSet.Rank = request.Rank;

        roleSet.Save();
        return null;
    }
}
