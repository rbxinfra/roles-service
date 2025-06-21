namespace Roblox.Roles;

using Operations;

using Enums;
using Models;
using Entities;

/// <summary>
/// Operation to get a <see cref="RoleSet"/> by <see cref="RoleSet.ID"/> or <see cref="RoleSet.Name"/>.
/// </summary>
public class GetRoleSetOperation : IResultOperation<GetRoleSetRequest, RoleSetPayload>
{
    /// <inheritdoc cref="IResultOperation{TOutput}"/>
    public (RoleSetPayload Output, OperationError Error) Execute(GetRoleSetRequest request)
    {
        RoleSet roleSet = null;
        
        if (request.ID.HasValue) roleSet = RoleSet.Get(request.ID.Value);
        if (!string.IsNullOrEmpty(request.Name)) roleSet = RoleSet.GetByName(request.Name);

        if (roleSet == null) return (null, new OperationError(RoleSetError.RoleSetDoesNotExist));

        return (new RoleSetPayload(roleSet), null);
    }
}
