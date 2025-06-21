namespace Roblox.Roles.Models;

using System.Runtime.Serialization;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Request to get all RoleSets a User has.
/// </summary>
[DataContract]
public class GetUserRoleSetsRequest
{
    /// <summary>
    /// The ID of the User.
    /// </summary>
    [FromQuery(Name = "userId")]
    public long userId { get; set; }
}
