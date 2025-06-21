namespace Roblox.Roles.Models;

using System.Runtime.Serialization;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Request to get an UserRoleSet by User ID and RoleSet Name.
/// </summary>
[DataContract]
public class GetUserRoleSetRequest
{
    /// <summary>
    /// The ID of the User.
    /// </summary>
    [FromQuery(Name = "userId")]
    public long UserID { get; set; }

    /// <summary>
    /// The Name of the RoleSet.
    /// </summary>
    [FromQuery(Name = "name")]
    public string Name { get; set; }
}
