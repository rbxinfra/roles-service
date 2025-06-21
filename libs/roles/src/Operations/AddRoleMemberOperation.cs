namespace Roblox.Roles;

using Operations;
using Platform.Membership;

using Enums;
using Models;
using Entities;

/// <summary>
/// Operation for granting a user a role set.
/// </summary>
public class AddRoleMemberOperation : IResultOperation<ModifyRoleMemberRequest, RoleSetPayload>
{
    private readonly MembershipDomainFactories _membershipDomainFactories;

    /// <summary>
    /// Constructs a new instance of <see cref="AddRoleMemberOperation"/>.
    /// </summary>
    /// <param name="membershipDomainFactories">The <see cref="MembershipDomainFactories"/> to use.</param>
    public AddRoleMemberOperation(MembershipDomainFactories membershipDomainFactories)
    {
        _membershipDomainFactories = membershipDomainFactories;
    }

    /// <inheritdoc cref="IResultOperation{TInput, TOutput}"/>
    public (RoleSetPayload Output, OperationError Error) Execute(ModifyRoleMemberRequest request)
    {
        if (request.UserID == default(long)) return (null, new OperationError(UserRoleSetError.InvalidUserId));

        IUser user = _membershipDomainFactories.UserFactory.GetUser(request.UserID);
        if (user == null) return (null, new OperationError(UserRoleSetError.UserDoesNotExist));

        RoleSet roleSet = null;

        if (request.ID.HasValue) roleSet = RoleSet.Get(request.ID.Value);
        if (!string.IsNullOrWhiteSpace(request.Name)) roleSet = RoleSet.GetByName(request.Name);

        if (roleSet == null) return (null, new OperationError(RoleSetError.RoleSetDoesNotExist));

        UserRoleSet userRoleSet = new UserRoleSet();
        userRoleSet.UserID = user.Id;
        userRoleSet.RoleSetID = roleSet.ID;
        userRoleSet.Save();

        return (new RoleSetPayload(roleSet), null);
    }
}
