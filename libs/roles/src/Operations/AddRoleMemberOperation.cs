namespace Roblox.Roles;

using System;

using EventLog;
using Operations;
using Platform.Membership;

using Enums;
using Models;
using Entities;

/// <summary>
/// Operation for granting a <see cref="IUser"/> a <see cref="RoleSet"/>.
/// </summary>
public class AddRoleMemberOperation : IResultOperation<ModifyRoleMemberRequest, RoleSetPayload>
{
    private readonly ILogger _Logger;
    private readonly MembershipDomainFactories _MembershipDomainFactories;

    /// <summary>
    /// Constructs a new instance of <see cref="AddRoleMemberOperation"/>.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/></param>
    /// <param name="membershipDomainFactories">The <see cref="MembershipDomainFactories"/></param>
    /// <exception cref="ArgumentNullException">
    /// - <paramref name="logger"/> cannot be null.
    /// - <paramref name="membershipDomainFactories"/> cannot be null.
    /// </exception>
    public AddRoleMemberOperation(
        ILogger logger,
        MembershipDomainFactories membershipDomainFactories
    ) {
        _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _MembershipDomainFactories = membershipDomainFactories ?? throw new ArgumentNullException(nameof(_MembershipDomainFactories));
    }

    /// <inheritdoc cref="IResultOperation{TInput, TOutput}"/>
    public (RoleSetPayload Output, OperationError Error) Execute(ModifyRoleMemberRequest request)
    {
        if (request.UserID == default(long)) return (null, new OperationError(UserRoleSetError.InvalidUserId));
        if (string.IsNullOrWhiteSpace(request.Name)) return (null, new OperationError(RoleSetError.InvalidRoleSetName));

        IUser user = _MembershipDomainFactories.UserFactory.GetUser(request.UserID);
        if (user == null) return (null, new OperationError(UserRoleSetError.UserDoesNotExist));

        RoleSet roleSet = RoleSet.GetByName(request.Name);
        if (roleSet == null) return (null, new OperationError(RoleSetError.RoleSetDoesNotExist));

        _Logger.Information(
            "AddRoleMember, User ID = {0}, Role ID = {1}, Role Name = {2}", 
            user.Id, 
            roleSet.ID, 
            request.Name
        );

        UserRoleSet userRoleSet = new UserRoleSet();
        userRoleSet.UserID = user.Id;
        userRoleSet.RoleSetID = roleSet.ID;
        userRoleSet.Save();

        return (new RoleSetPayload(roleSet), null);
    }
}
