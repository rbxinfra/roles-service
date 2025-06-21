namespace Roblox.Roles.Enums;

using System.ComponentModel;

/// <summary>
/// Represents an error that can occur when executing operations related to user role sets.
/// </summary>
public enum UserRoleSetError
{
    /// <summary>
    /// The User ID provided is invalid or not set.
    /// </summary>
    [DescriptionAttribute("Invalid or missing user ID.")]
    InvalidUserId = 1,

    /// <summary>
    /// No role set exists with the given ID or Name.
    /// </summary>
    [DescriptionAttribute("The requested user role does not exist.")]
    UserRoleSetDoesNotExist = 2,

    /// <summary>
    /// No user exists with the given User ID.
    /// </summary>
    [DescriptionAttribute("The requested user does not exist.")]
    UserDoesNotExist = 3,
}
