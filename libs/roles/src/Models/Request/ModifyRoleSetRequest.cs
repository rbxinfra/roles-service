namespace Roblox.Roles.Models;

using System.Runtime.Serialization;

/// <summary>
/// Request to modify a RoleSet.
/// </summary>
[DataContract]
public class ModifyRoleSetRequest
{
    /// <summary>
    /// The ID of the RoleSet.
    /// </summary>
    [DataMember(Name = "id")]
    public int ID { get; set; }

    /// <summary>
    /// The Name of the RoleSet.
    /// </summary>
    [DataMember(Name = "name")]
    public string Name { get; set; }

    /// <summary>
    /// The Rank of the RoleSet.
    /// </summary>
    [DataMember(Name = "rank")]
    public int Rank { get; set; }
}
