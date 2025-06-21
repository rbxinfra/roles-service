namespace Roblox.Roles;

using System;

using EventLog;
using Platform.Membership;

/// <summary>
/// Implementation of <see cref="IRolesOperations"/>.
/// </summary>
/// <seealso cref="IRolesOperations"/>
public class RolesOperations : IRolesOperations
{
    /// <inheritdoc cref="IRolesOperations.AddRoleMember"/>
    public AddRoleMemberOperation AddRoleMember { get; }

    /// <inheritdoc cref="IRolesOperations.CreateRoleSet"/>
    public CreateRoleSetOperation CreateRoleSet { get; }

    /// <inheritdoc cref="IRolesOperations.GetRoleMembers"/>
    public GetRoleMembersOperation GetRoleMembers { get; }

    /// <inheritdoc cref="IRolesOperations.GetRoleSet"/>
    public GetRoleSetOperation GetRoleSet { get; }

    /// <inheritdoc cref="IRolesOperations.GetRoleSets"/>
    public GetRoleSetsOperation GetRoleSets { get; }

    /// <inheritdoc cref="IRolesOperations.GetUserRoleSets"/>
    public GetUserRoleSetsOperation GetUserRoleSets { get; }

    /// <inheritdoc cref="IRolesOperations.GetUserRoleSet"/>
    public GetUserRoleSetOperation GetUserRoleSet { get; }

    /// <inheritdoc cref="IRolesOperations.RemoveRoleMember"/>
    public RemoveRoleMemberOperation RemoveRoleMember { get; }

    /// <inheritdoc cref="IRolesOperations.RoleContainsMember"/>
    public RoleContainsMemberOperation RoleContainsMember { get; }

    /// <inheritdoc cref="IRolesOperations.UpdateRoleSet"/>
    public UpdateRoleSetOperation UpdateRoleSet { get; }


    /// <summary>
    /// Initializes a new instance of <see cref="RolesOperations"/>.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/> to use.</param>
    /// <param name="membershipDomainFactories">The <see cref="MembershipDomainFactories"/> to use.</param>
    /// <exception cref="ArgumentNullException">
    /// - <paramref name="membershipDomainFactories"/> is null.
    /// </exception>
    public RolesOperations(ILogger logger, MembershipDomainFactories membershipDomainFactories)
    {
        ArgumentNullException.ThrowIfNull(logger, nameof(logger));
        ArgumentNullException.ThrowIfNull(membershipDomainFactories, nameof(membershipDomainFactories));

        AddRoleMember      = new(logger, membershipDomainFactories);
        CreateRoleSet      = new(logger);
        GetRoleSets        = new(logger);
        GetUserRoleSets    = new(logger);
        GetRoleMembers     = new(logger);
        GetRoleSet         = new(logger);
        GetUserRoleSet     = new(logger);
        RemoveRoleMember   = new(logger);
        RoleContainsMember = new(logger);
        UpdateRoleSet      = new(logger);
    }
}
