namespace Roblox.Roles;

using System;
using System.Linq;
using System.Collections.Generic;

using EventLog;
using Operations;

using Enums;
using Models;
using Entities;

/// <summary>
/// Operation to get all role sets a user has.
/// </summary>
public class GetUserRoleSetsOperation : IResultOperation<GetUserRoleSetsRequest, ICollection<RoleSetPayload>>
{
    private readonly ILogger _Logger;

    /// <summary>
    /// Constructs a new instance of <see cref="GetUserRoleSetsOperation"/>.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger"/></param>
    /// <exception cref="ArgumentNullException">
    /// - <paramref name="logger"/> cannot be null.
    /// </exception>
    public GetUserRoleSetsOperation(ILogger logger)
    {
        _Logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <inheritdoc cref="IResultOperation{TInput, TOutput}"/>
    public (ICollection<RoleSetPayload> Output, OperationError Error) Execute(GetUserRoleSetsRequest request)
    {
        if (request.userId == default(long)) return new(null, new OperationError(UserRoleSetError.InvalidUserId));

        _Logger.Information("GetUserRoleSets, User ID = {0}", request.userId);

        var userRoleSets = UserRoleSet.GetUserRoleSetsByUserIDPaged(
            request.userId,
            1,
            long.MaxValue
        );

        var result = userRoleSets
            .Select(userRoleSet =>
            {
                var roleSet = RoleSet.Get(userRoleSet.RoleSetID);
                return new RoleSetPayload(roleSet);
            })
            .ToArray();

        return (result, null);
    }
}
