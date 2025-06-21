namespace Roblox.Roles.Models;

using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Request to get a RoleSet by Name or ID.
/// </summary>
[DataContract]
public class GetRoleMembersPagedRequest
{
    /// <summary>
    /// The ID of the RoleSet.
    /// </summary>
    /// <remarks>Optional if <see cref="Name"/> is set.</remarks>
    [FromQuery(Name = "id")]
    public int? ID { get; set; }

    /// <summary>
    /// The Name of the RoleSet.
    /// </summary>
    /// <remarks>Optional if <see cref="ID"/> is set.</remarks>
    [FromQuery(Name = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets start row index.
    /// </summary>
    [FromQuery(Name = "startRowIndex")]
    [Required]
    [DefaultValue(1)]
    public int StartRowIndex { get; set; } = 1;

    /// <summary>
    /// Gets or sets the maximum rows.
    /// </summary>
    [FromQuery(Name = "maximumRows")]
    [Required]
    [DefaultValue(50)]
    public int MaximumRows { get; set; } = 50;
}
