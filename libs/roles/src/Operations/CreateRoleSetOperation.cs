namespace Roblox.Roles;

using System;

using EventLog;
using Operations;

using Enums;
using Models;
using Entities;

/// <summary>
/// Operation to create a new role set.
/// </summary>
public class CreateRoleSetOperation : IResultOperation<ModifyRoleSetRequest, RoleSetPayload>
{
    private readonly ILogger _Logger;

    /// <summary>
    /// Constructs a new instance of <see cref="CreateRoleSetOperation"/>.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/></param>
    /// <exception cref="ArgumentNullException">
    /// - <paramref name="logger"/> cannot be null.
    /// </exception>
    public CreateRoleSetOperation(ILogger logger)
    {
        _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc cref="IResultOperation{TInput, TOutput}"/>
    public (RoleSetPayload Output, OperationError Error) Execute(ModifyRoleSetRequest request)
    {
        if (string.IsNullOrEmpty(request.Name)) return (null, new(RoleSetError.InvalidRoleSetName));
        if (request.Rank == default(int)) return (null, new(RoleSetError.InvalidRoleSetRank));

        RoleSet roleSet = RoleSet.GetByName(request.Name);
        if (roleSet != null) return (null, new(RoleSetError.RoleSetAlreadyExists));

        _Logger.Information("CreateRoleSet, Name = {0}, Rank = {1}", request.Name, request.Rank);

        roleSet = new RoleSet();
        roleSet.Name = request.Name;
        roleSet.Rank = request.Rank;
        roleSet.Save();
        
        return (new RoleSetPayload(roleSet), null);
    }
}
