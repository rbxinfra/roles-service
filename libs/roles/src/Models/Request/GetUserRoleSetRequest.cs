namespace Roblox.Roles.Models;

using System.Runtime.Serialization;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Request to get an UserRoleSet by User ID and RoleSet Name or ID.
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
    /// The ID of the RoleSet. Optional if <see cref="Name"/> is set.
    /// </summary>
    [FromQuery(Name = "id")]
    public int? ID { get; set; }

    /// <summary>
    /// The Name of the RoleSet. Optional if <see cref="ID"/> is set.
    /// </summary>
    [FromQuery(Name = "name")]
    public string Name { get; set; }
}
