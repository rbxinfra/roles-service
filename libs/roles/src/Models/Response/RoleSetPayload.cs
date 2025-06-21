namespace Roblox.Roles.Models;

using System.Runtime.Serialization;

using Roblox.Roles.Entities;

/// <summary>
/// Represents the result of an <see cref="RoleSet"/> entity.
/// </summary>
[DataContract]
public class RoleSetPayload
{
    /// <summary>
    /// The ID of the <see cref="RoleSet"/>.
    /// </summary>
    [DataMember(Name = "id")]
    public int ID { get; set; }

    /// <summary>
    /// The Name of the <see cref="RoleSet"/>.
    /// </summary>
    [DataMember(Name = "name")]
    public string Name { get; set; }

    /// <summary>
    /// The Rank of the <see cref="RoleSet"/>.
    /// </summary>
    [DataMember(Name = "rank")]
    public int Rank { get; set; }

    /// <summary>
    /// Constructs a new <see cref="RoleSetPayload"/> class from a <see cref="RoleSet"/>.
    /// </summary>
    /// <param name="roleSet">The <see cref="RoleSet"/> to convert.</param>
    internal RoleSetPayload(RoleSet roleSet)
    {
        ID = roleSet.ID;
        Name = roleSet.Name;
        Rank = roleSet.Rank;
    }
}
