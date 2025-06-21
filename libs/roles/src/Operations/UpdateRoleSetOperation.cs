namespace Roblox.Roles;

using Operations;

using Enums;
using Models;
using Entities;

/// <summary>
/// Operation to update a <see cref="RoleSet"/> by <see cref="RoleSet.ID"/>.
/// </summary>
public class UpdateRoleSetOperation : IOperation<ModifyRoleSetRequest>
{
    /// <inheritdoc cref="IResultOperation{TOutput}"/>
    public OperationError Execute(ModifyRoleSetRequest request)
    {
        RoleSet roleSet = RoleSet.Get(request.ID);
        if (roleSet == null) return new(RoleSetError.RoleSetDoesNotExist);

        if (!string.IsNullOrEmpty(request.Name))
            roleSet.Name = request.Name;
        if (request.Rank != default(int)) 
            roleSet.Rank = request.Rank;

        roleSet.Save();
        return null;
    }
}
