namespace Roblox.Roles.Entities;

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Roblox.Entities.Mssql;

internal class UserRoleSetDAL
{
    private const Roblox.MssqlDatabases.RobloxDatabase _Database = global::Roblox.MssqlDatabases.RobloxDatabase.RobloxRoles;

    public long ID { get; set; }
    public long UserID { get; set; }
    public int RoleSetID { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }

    private static UserRoleSetDAL BuildDAL(IDictionary<string, object> record)
    {
        var dal = new UserRoleSetDAL();
        dal.ID = (long)record["ID"];
        dal.UserID = (long)record["UserID"];
        dal.RoleSetID = (int)record["RoleSetID"];
        dal.Created = (DateTime)record["Created"];
        dal.Updated = (DateTime)record["Updated"];

        return dal;
    }

    internal void Delete()
    {
        _Database.Delete("UserRoleSets_DeleteUserRoleSetByID", ID);
    }

    internal void Insert()
    {
        var queryParameters = new SqlParameter[]
        {
            new SqlParameter("@ID", ID) { Direction = ParameterDirection.Output },
            new SqlParameter("@UserID", UserID),
            new SqlParameter("@RoleSetID", RoleSetID),
            new SqlParameter("@Created", Created),
            new SqlParameter("@Updated", Updated),
        };

        ID = _Database.Insert<long>("UserRoleSets_InsertUserRoleSet", queryParameters);
    }

    internal void Update()
    {
        var queryParameters = new SqlParameter[]
        {
            new SqlParameter("@ID", ID),
            new SqlParameter("@UserID", UserID),
            new SqlParameter("@RoleSetID", RoleSetID),
            new SqlParameter("@Created", Created),
            new SqlParameter("@Updated", Updated),
        };

        _Database.Update("UserRoleSets_UpdateUserRoleSetByID", queryParameters);
    }

    internal static UserRoleSetDAL Get(long id)
    {
        return _Database.Get(
            "UserRoleSets_GetUserRoleSetByID",
            id,
            BuildDAL
        );
    }

    public static UserRoleSetDAL GetByUserIDAndRoleSetID(long userID, int roleSetID)
    {
        if (userID == default(long)) 
            return null;
        if (roleSetID == default(int)) 
            return null;

        var queryParameters = new SqlParameter[]
        {
            new SqlParameter("@UserID", userID),
            new SqlParameter("@RoleSetID", roleSetID),
        };

        return _Database.Lookup(
            "UserRoleSets_GetUserRoleSetByUserIDAndRoleSetID",
            BuildDAL,
            queryParameters
        );
    }

    public static ICollection<long> GetAllUserRoleSetsPaged(long startRowIndex, long maximumRows)
    {
        if (startRowIndex < 1)
            throw new ApplicationException("Required value not specified: StartRowIndex.");
        if (maximumRows < 1)
            throw new ApplicationException("Required value not specified: MaximumRows.");

        var queryParameters = new SqlParameter[]
        {
            new SqlParameter("@StartRowIndex", startRowIndex),
            new SqlParameter("@MaximumRows", maximumRows)
        };

        return _Database.GetIDCollection<long>(
            "UserRoleSets_GetAllUserRoleSetIDs_Paged",
            queryParameters
        );
    }

    public static int GetTotalNumberOfUserRoleSets()
    {
        return _Database.GetCount<int>(
            "UserRoleSets_GetTotalNumberOfUserRoleSets"
        );
    }

    public static ICollection<long> GetUserRoleSetsByUserIDPaged(long userID, long startRowIndex, long maximumRows)
    {
        if (userID == default(long)) 
            throw new ArgumentException("Parameter 'userID' cannot be null, empty or the default value.");
        if (startRowIndex < 1)
            throw new ApplicationException("Required value not specified: StartRowIndex.");
        if (maximumRows < 1)
            throw new ApplicationException("Required value not specified: MaximumRows.");

        var queryParameters = new SqlParameter[]
        {
            new SqlParameter("@UserID", userID),
            new SqlParameter("@StartRowIndex", startRowIndex),
            new SqlParameter("@MaximumRows", maximumRows)
        };

        return _Database.GetIDCollection<long>(
            "UserRoleSets_GetUserRoleSetIDsByUserID_Paged",
            queryParameters
        );
    }

    public static ICollection<long> GetUserRoleSetsByRoleSetIDPaged(int roleSetID, long startRowIndex, long maximumRows)
    {
        if (roleSetID == default(int)) 
            throw new ArgumentException("Parameter 'roleSetID' cannot be null, empty or the default value.");
        if (startRowIndex < 1)
            throw new ApplicationException("Required value not specified: StartRowIndex.");
        if (maximumRows < 1)
            throw new ApplicationException("Required value not specified: MaximumRows.");

        var queryParameters = new SqlParameter[]
        {
            new SqlParameter("@RoleSetID", roleSetID),
            new SqlParameter("@StartRowIndex", startRowIndex),
            new SqlParameter("@MaximumRows", maximumRows)
        };

        return _Database.GetIDCollection<long>(
            "UserRoleSets_GetUserRoleSetIDsByRoleSetID_Paged",
            queryParameters
        );
    }
}
