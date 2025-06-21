namespace Roblox.Roles.Enums;

/// <summary>
/// Represents an error that can occur when executing operations related to user role sets.
/// </summary>
public enum UserRoleSetError
{
    /// <summary>
    /// The User ID provided is invalid or not set.
    /// </summary>
    InvalidUserId = 1,

    /// <summary>
    /// No role set exists with the given ID or Name.
    /// </summary>
    UserRoleSetDoesNotExist = 2,

    /// <summary>
    /// No user exists with the given User ID.
    /// </summary>
    UserDoesNotExist = 3,
}
