namespace Roblox.Roles;

/// <summary>
/// Operations for roles.
/// </summary>
public interface IRolesOperations
{
    /// <summary>
    /// Gets the <see cref="AddRoleMemberOperation"/>.
    /// </summary>
    AddRoleMemberOperation AddRoleMember { get; }

    /// <summary>
    /// Gets the <see cref="CreateRoleSetOperation"/>.
    /// </summary>
    CreateRoleSetOperation CreateRoleSet { get; }

    /// <summary>
    /// Gets the <see cref="GetRoleMembersOperation"/>.
    /// </summary>
    GetRoleMembersOperation GetRoleMembers { get; }

    /// <summary>
    /// Gets the <see cref="GetRoleSetOperation"/>.
    /// </summary>
    GetRoleSetOperation GetRoleSet { get; }

    /// <summary>
    /// Gets the <see cref="GetRoleSetsOperation"/>.
    /// </summary>
    GetRoleSetsOperation GetRoleSets { get; }

    /// <summary>
    /// Gets the <see cref="GetUserRoleSetsOperation"/>.
    /// </summary>
    GetUserRoleSetsOperation GetUserRoleSets { get; }

    /// <summary>
    /// Gets the <see cref="GetUserRoleSetOperation"/>.
    /// </summary>
    GetUserRoleSetOperation GetUserRoleSet { get; }

    /// <summary>
    /// Gets the <see cref="RemoveRoleMemberOperation"/>.
    /// </summary>
    RemoveRoleMemberOperation RemoveRoleMember { get; }

    /// <summary>
    /// Gets the <see cref="RoleContainsMemberOperation"/>.
    /// </summary>
    RoleContainsMemberOperation RoleContainsMember { get; }

    /// <summary>
    /// Gets the <see cref="UpdateRoleSetOperation"/>.
    /// </summary>
    UpdateRoleSetOperation UpdateRoleSet { get; }
}
