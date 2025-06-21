namespace Roblox.Roles.Models;

using System.Runtime.Serialization;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Request to get a RoleSet by Name or ID.
/// </summary>
[DataContract]
public class GetRoleSetRequest
{
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
