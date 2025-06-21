namespace Roblox.Roles.Models;

using System;
using System.Runtime.Serialization;

using Roblox.Roles.Entities;

/// <summary>
/// Represents the result of an <see cref="UserRoleSet"/> entity.
/// </summary>
public class UserRoleSetPayload
{
    /// <summary>
    /// The ID of the <see cref="UserRoleSet"/>.
    /// </summary>
    [DataMember(Name = "id")]
    public long ID { get; set; }

    /// <summary>
    /// The ID of the User associated with the <see cref="UserRoleSet"/>.
    /// </summary>
    [DataMember(Name = "userID")]
    public long UserID { get; set; }

    /// <summary>
    /// The ID of the <see cref="RoleSet"/> associated with the <see cref="UserRoleSet"/>.
    /// </summary>
    [DataMember(Name = "roleSetID")]
    public int RoleSetID { get; set; }

    /// <summary>
    /// The date the <see cref="UserRoleSet"/> was created.
    /// </summary>
    [DataMember(Name = "created")]
    public DateTime Created { get; set; }

    /// <summary>
    /// The date the <see cref="UserRoleSet"/> was last updated.
    /// </summary>
    [DataMember(Name = "updated")]
    public DateTime Updated { get; set; }

    /// <summary>
    /// Constructs a new <see cref="UserRoleSetPayload"/> class from a <see cref="UserRoleSet"/>.
    /// </summary>
    /// <param name="userRoleSet">The <see cref="UserRoleSet"/> to convert.</param>
    internal UserRoleSetPayload(UserRoleSet userRoleSet)
    {
        ID = userRoleSet.ID;
        UserID = userRoleSet.UserID;
        RoleSetID = userRoleSet.RoleSetID;
        Created = userRoleSet.Created;
        Updated = userRoleSet.Updated;
    }
}
