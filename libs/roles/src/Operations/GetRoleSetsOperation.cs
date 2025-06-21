namespace Roblox.Roles;

using System;
using System.Linq;
using System.Collections.Generic;

using EventLog;
using Operations;

using Models;
using Entities;

/// <summary>
/// Operation to get all <see cref="RoleSet"/>.
/// </summary>
public class GetRoleSetsOperation : IResultOperation<ICollection<RoleSetPayload>>
{
    private readonly ILogger _Logger;

    /// <summary>
    /// Constructs a new instance of <see cref="GetRoleSetsOperation"/>.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/></param>
    /// <exception cref="ArgumentNullException">
    /// - <paramref name="logger"/> cannot be null.
    /// </exception>
    public GetRoleSetsOperation(ILogger logger)
    {
        _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc cref="IResultOperation{TInput, TOutput}"/>
    public (ICollection<RoleSetPayload> Output, OperationError Error) Execute()
    {
        var roleSets = RoleSet.GetAll();
        return (roleSets.Select(roleSet => new RoleSetPayload(roleSet)).ToList(), null);
    }
}
