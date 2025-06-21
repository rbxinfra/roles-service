namespace Roblox.Roles;

using System.Linq;
using System.Collections.Generic;

using Operations;

using Models;
using Entities;

/// <summary>
/// Operation to get all role sets.
/// </summary>
public class GetRoleSetsOperation : IResultOperation<ICollection<RoleSetPayload>>
{
    /// <inheritdoc cref="IResultOperation{TInput, TOutput}"/>
    public (ICollection<RoleSetPayload> Output, OperationError Error) Execute()
    {
        var roleSets = RoleSet.GetAll();
        var results = roleSets.Select(roleSet => new RoleSetPayload(roleSet)).ToList();

        return (results, null);
    }
}
