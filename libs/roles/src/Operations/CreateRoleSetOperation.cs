namespace Roblox.Roles;

using Operations;

using Enums;
using Models;
using Entities;

/// <summary>
/// Operation to create a new role set.
/// </summary>
public class CreateRoleSetOperation : IResultOperation<ModifyRoleSetRequest, RoleSetPayload>
{
    /// <inheritdoc cref="IResultOperation{TInput, TOutput}"/>
    public (RoleSetPayload Output, OperationError Error) Execute(ModifyRoleSetRequest request)
    {
        if (string.IsNullOrEmpty(request.Name)) return (null, new(RoleSetError.RoleSetNameInvalid));
        if (request.Rank == default(int)) return (null, new(RoleSetError.RoleSetRankInvalid));

        RoleSet roleSet = RoleSet.GetByName(request.Name);
        if (roleSet != null) return (null, new(RoleSetError.RoleSetAlreadyExists));

        roleSet = new RoleSet();
        roleSet.Name = request.Name;
        roleSet.Rank = request.Rank;
        roleSet.Save();
        
        return (new RoleSetPayload(roleSet), null);
    }
}
