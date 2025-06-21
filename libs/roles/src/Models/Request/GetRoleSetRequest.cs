namespace Roblox.Roles.Models;

using System.Runtime.Serialization;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Request to get a RoleSet by Name.
/// </summary>
[DataContract]
public class GetRoleSetRequest
{
    /// <summary>
    /// The Name of the RoleSet.
    /// </summary>
    [FromQuery(Name = "name")]
    public string Name { get; set; }
}
