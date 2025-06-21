namespace Roblox.Roles;

using System;

using EventLog;
using Operations;

using Enums;
using Models;
using Entities;

/// <summary>
/// Operation to get a <see cref="RoleSet"/> by <see cref="RoleSet.Name"/>.
/// </summary>
public class GetRoleSetOperation : IResultOperation<GetRoleSetRequest, RoleSetPayload>
{
    private readonly ILogger _Logger;

    /// <summary>
    /// Constructs a new instance of <see cref="GetRoleSetOperation"/>.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/></param>
    /// <exception cref="ArgumentNullException">
    /// - <paramref name="logger"/> cannot be null.
    /// </exception>
    public GetRoleSetOperation(ILogger logger)
    {
        _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc cref="IResultOperation{TOutput}"/>
    public (RoleSetPayload Output, OperationError Error) Execute(GetRoleSetRequest request)
    {
        if (string.IsNullOrEmpty(request.Name)) return (null, new OperationError(RoleSetError.InvalidRoleSetName));

        _Logger.Information("GetRoleSet, Role Name = {0}", request.Name);

        RoleSet roleSet = RoleSet.GetByName(request.Name);        
        if (roleSet == null) return (null, new OperationError(RoleSetError.RoleSetDoesNotExist));

        return (new RoleSetPayload(roleSet), null);
    }
}
