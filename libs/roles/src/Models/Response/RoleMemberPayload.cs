namespace Roblox.Roles.Models;

using System;
using System.Runtime.Serialization;

using Roblox.Roles.Entities;

/// <summary>
/// Represents the result of an <see cref="UserRoleSet"/> entity.
/// </summary>
[DataContract]
public class RoleMemberPayload
{
    /// <summary>
    /// The members User ID.
    /// </summary>
    [DataMember(Name = "userID")]
    public long UserID { get; set; }

    /// <summary>
    /// The Date the user obtained the Role.
    /// </summary>
    [DataMember(Name = "memberSince")]
    public DateTime MemberSince { get; set; }

    /// <summary>
    /// Constructs a new <see cref="RoleSetPayload"/> class.
    /// </summary>
    /// <param name="userId">The members User ID.</param>
    /// <param name="memberSince">The date the UserRoleSet was created.</param>
    internal RoleMemberPayload(long userId, DateTime memberSince)
    {
        UserID = userId;
        MemberSince = memberSince;
    }
}
