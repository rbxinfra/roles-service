namespace Roblox.Roles;

using System;
using System.Linq;
using System.Collections.Generic;

using EventLog;
using Operations;

using Models;
using Entities;

/// <summary>
/// Operation to get all <see cref="UserRoleSet"/>.
/// </summary>
public class GetUserRoleSetsOperation : IResultOperation<ICollection<UserRoleSetPayload>>
{
    private readonly ILogger _Logger;

    /// <summary>
    /// Constructs a new instance of <see cref="GetUserRoleSetsOperation"/>.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/></param>
    /// <exception cref="ArgumentNullException">
    /// - <paramref name="logger"/> cannot be null.
    /// </exception>
    public GetUserRoleSetsOperation(ILogger logger)
    {
        _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc cref="IResultOperation{TInput, TOutput}"/>
    public (ICollection<UserRoleSetPayload> Output, OperationError Error) Execute()
    {
        _Logger.Information("GetUserRoleSets");

        var userRoleSets = UserRoleSet.GetAllUserRoleSetsPaged(
            1,
            long.MaxValue
        );

        return (userRoleSets.Select(userRoleSet => new UserRoleSetPayload(userRoleSet)).ToArray(), null);
    }
}
