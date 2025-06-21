namespace Roblox.Roles.Enums;

/// <summary>
/// Represents an error that can occur when executing operations related to role sets.
/// </summary>
public enum RoleSetError
{
    /// <summary>
    /// The RoleSet ID provided is invalid or not set.
    /// </summary>
    InvalidRoleSetId = 1,

    /// <summary>
    /// No role set exists with the given ID or Name.
    /// </summary>
    RoleSetDoesNotExist = 2,
    
    /// <summary>
    /// A role set with the given Name already exists.
    /// </summary>
    RoleSetAlreadyExists = 3,

    /// <summary>
    /// The name provided is invalid or not set.
    /// </summary>
    RoleSetNameInvalid = 4,

    /// <summary>
    /// The rank provided is invalid or not set.
    /// </summary>
    RoleSetRankInvalid = 5,
}
