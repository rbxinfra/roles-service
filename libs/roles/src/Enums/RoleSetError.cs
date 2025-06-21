namespace Roblox.Roles.Enums;

using System.ComponentModel;

/// <summary>
/// Represents an error that can occur when executing operations related to role sets.
/// </summary>
public enum RoleSetError
{
    /// <summary>
    /// The RoleSet ID provided is invalid or not set.
    /// </summary>
    [Description("Invalid or missing role ID.")]
    InvalidRoleSetId = 1,

    /// <summary>
    /// No role set exists with the given ID or Name.
    /// </summary>
    [Description("The requested role does not exist.")]
    RoleSetDoesNotExist = 2,

    /// <summary>
    /// A role set with the given Name already exists.
    /// </summary>
    [Description("A role with this name already exists.")]
    RoleSetAlreadyExists = 3,

    /// <summary>
    /// The name provided is invalid or not set.
    /// </summary>
    [Description("Invalid or missing role name.")]
    InvalidRoleSetName = 4,

    /// <summary>
    /// The rank provided is invalid or not set.
    /// </summary>
    [Description("Invalid or missing role rank.")]
    InvalidRoleSetRank = 5,
}
