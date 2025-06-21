namespace Roblox.Roles.Service.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Web.Framework.Services.Http;

using Models;

/// <summary>
/// Default controller.
/// </summary>
[Route("")]
[ApiController]
#if DEBUG
[AllowAnonymous]
#endif
public class DefaultController : Controller
{
    private readonly IOperationExecutor _OperationExecutor;
    private readonly IRolesOperations _RolesOperations;

    /// <summary>
    /// Construct a new instance of <see cref="DefaultController"/>
    /// </summary>
    /// <param name="operationExecutor">The <see cref="IOperationExecutor"/></param>
    /// <param name="apiControlPlaneOperations">The <see cref="IRolesOperations"/></param>
    /// <exception cref="ArgumentNullException">
    /// - <paramref name="operationExecutor"/> cannot be null.
    /// - <paramref name="apiControlPlaneOperations"/> cannot be null.
    /// </exception>
    public DefaultController(IOperationExecutor operationExecutor, IRolesOperations apiControlPlaneOperations)
    {
        _OperationExecutor = operationExecutor ?? throw new ArgumentNullException(nameof(operationExecutor));
        _RolesOperations = apiControlPlaneOperations ?? throw new ArgumentNullException(nameof(apiControlPlaneOperations));
    }

    /// <summary>
    /// Grants the specified user a roleset.
    /// </summary>
    /// <param name="request">The <see cref="ModifyRoleMemberRequest"/></param>
    /// <response code="400">The user or roleset is invalid.</response>
    /// <response code="500">An error occurred.</response>
    /// <response code="503">Service unavailable.</response>
    [HttpPost]
    [Route($"/v1/{nameof(AddRoleMember)}")]
    [ProducesResponseType(200, Type = typeof(RoleSetPayload))]
    [ProducesResponseType(500)]
    [ProducesResponseType(503)]
    public IActionResult AddRoleMember(ModifyRoleMemberRequest request)
        => _OperationExecutor.Execute(_RolesOperations.AddRoleMember, request);

    /// <summary>
    /// Creates a new roleset.
    /// </summary>
    /// <param name="request">The <see cref="ModifyRoleSetRequest"/></param>
    /// <response code="400">The roleset name or rank is invalid.</response>
    /// <response code="500">An error occurred.</response>
    /// <response code="503">Service unavailable.</response>
    [HttpPost]
    [Route($"/v1/{nameof(CreateRoleSet)}")]
    [ProducesResponseType(200, Type = typeof(RoleSetPayload))]
    [ProducesResponseType(500)]
    [ProducesResponseType(503)]
    public IActionResult CreateRoleSet(ModifyRoleSetRequest request)
        => _OperationExecutor.Execute(_RolesOperations.CreateRoleSet, request);

    /// <summary>
    /// Gets all users with the specified roleset.
    /// </summary>
    /// <response code="400">The roleset does not exist.</response>
    /// <response code="500">An error occurred.</response>
    /// <response code="503">Service unavailable.</response>
    [HttpGet]
    [Route($"/v1/{nameof(GetRoleMembers)}")]
    [ProducesResponseType(200, Type = typeof(ICollection<RoleMemberPayload>))]
    [ProducesResponseType(500)]
    [ProducesResponseType(503)]
    public IActionResult GetRoleMembers(GetRoleMembersPagedRequest request)
        => _OperationExecutor.Execute(_RolesOperations.GetRoleMembers, request);

    /// <summary>
    /// Gets a roleset by the name.
    /// </summary>
    /// <param name="request">The <see cref="GetRoleSetRequest"/></param>
    /// <response code="400">The roleset name is invalid.</response>
    /// <response code="500">An error occurred.</response>
    /// <response code="503">Service unavailable.</response>
    [HttpGet]
    [Route($"/v1/{nameof(GetRoleSet)}")]
    [ProducesResponseType(200, Type = typeof(RoleSetPayload))]
    [ProducesResponseType(500)]
    [ProducesResponseType(503)]
    public IActionResult GetRoleSet(GetRoleSetRequest request)
        => _OperationExecutor.Execute(_RolesOperations.GetRoleSet, request);

    /// <summary>
    /// Gets all rolesets.
    /// </summary>
    /// <response code="500">An error occurred.</response>
    /// <response code="503">Service unavailable.</response>
    [HttpGet]
    [Route($"/v1/{nameof(GetRoleSets)}")]
    [ProducesResponseType(200, Type = typeof(ICollection<RoleSetPayload>))]
    [ProducesResponseType(500)]
    [ProducesResponseType(503)]
    public IActionResult GetRoleSets()
        => _OperationExecutor.Execute(_RolesOperations.GetRoleSets);

    /// <summary>
    /// Gets all rolesets a user has.
    /// </summary>
    /// <response code="400">The user id is invalid.</response>
    /// <response code="500">An error occurred.</response>
    /// <response code="503">Service unavailable.</response>
    [HttpGet]
    [Route($"/v1/{nameof(GetUserRoleSets)}")]
    [ProducesResponseType(200, Type = typeof(ICollection<UserRoleSetPayload>))]
    [ProducesResponseType(500)]
    [ProducesResponseType(503)]
    public IActionResult GetUserRoleSets(GetUserRoleSetsRequest request)
        => _OperationExecutor.Execute(_RolesOperations.GetUserRoleSets, request);

    /// <summary>
    /// Gets a user roleset by the user id and roleset name.
    /// </summary>
    /// <param name="request">The <see cref="GetUserRoleSetRequest"/></param>
    /// <response code="400">The user id or roleset name is invalid.</response>
    /// <response code="500">An error occurred.</response>
    /// <response code="503">Service unavailable.</response>
    [HttpGet]
    [Route($"/v1/{nameof(GetUserRoleSet)}")]
    [ProducesResponseType(200, Type = typeof(UserRoleSetPayload))]
    [ProducesResponseType(500)]
    [ProducesResponseType(503)]
    public IActionResult GetUserRoleSet(GetUserRoleSetRequest request)
        => _OperationExecutor.Execute(_RolesOperations.GetUserRoleSet, request);

    /// <summary>
    /// Removes a users roleset.
    /// </summary>
    /// <param name="request">The <see cref="ModifyRoleMemberRequest"/></param>
    /// <response code="400">The roleset does not exist or the user id is invalid.</response>
    /// <response code="500">An error occurred.</response>
    /// <response code="503">Service unavailable.</response>
    [HttpPost]
    [Route($"/v1/{nameof(RemoveRoleMember)}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    [ProducesResponseType(503)]
    public IActionResult RemoveRoleMember(ModifyRoleMemberRequest request)
        => _OperationExecutor.Execute(_RolesOperations.RemoveRoleMember, request);

    /// <summary>
    /// Gets whether a user has a roleset or not.
    /// </summary>
    /// <param name="request">The <see cref="GetUserRoleSetRequest"/></param>
    /// <response code="400">The roleset does not exist.</response>
    /// <response code="500">An error occurred.</response>
    /// <response code="503">Service unavailable.</response>
    [HttpGet]
    [Route($"/v1/{nameof(RoleContainsMember)}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    [ProducesResponseType(503)]
    public IActionResult RoleContainsMember(GetUserRoleSetRequest request)
        => _OperationExecutor.Execute(_RolesOperations.RoleContainsMember, request);

    /// <summary>
    /// Updates a roleset.
    /// </summary>
    /// <param name="request">The <see cref="ModifyRoleSetRequest"/></param>
    /// <response code="400">The roleset does not exist.</response>
    /// <response code="500">An error occurred.</response>
    /// <response code="503">Service unavailable.</response>
    [HttpPost]
    [Route($"/v1/{nameof(UpdateRoleSet)}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    [ProducesResponseType(503)]
    public IActionResult UpdateRoleSet(ModifyRoleSetRequest request)
        => _OperationExecutor.Execute(_RolesOperations.UpdateRoleSet, request);
}
