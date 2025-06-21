namespace Roblox.Roles.Models;

using System.Runtime.Serialization;

/// <summary>
/// Request to add or remove a UserRoleSet.
/// </summary>
[DataContract]
public class ModifyRoleMemberRequest
{
    /// <summary>
    /// The ID of the User.
    /// </summary>
    [DataMember(Name = "userId")]
    public long UserID { get; set; }

    /// <summary>
    /// The ID of the RoleSet.
    /// </summary>
    /// <remarks>Optional if <see cref="Name"/> is set.</remarks>
    [DataMember(Name = "id")]
    public int? ID { get; set; }

    /// <summary>
    /// The Name of the RoleSet.
    /// </summary>
    /// <remarks>Optional if <see cref="ID"/> is set.</remarks>
    [DataMember(Name = "name")]
    public string Name { get; set; }
}
