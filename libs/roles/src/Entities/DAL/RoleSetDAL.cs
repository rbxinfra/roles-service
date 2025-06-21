namespace Roblox.Roles.Entities;

using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

using Roblox.Entities.Mssql;

internal class RoleSetDAL
{
    private const Roblox.MssqlDatabases.RobloxDatabase _Database = global::Roblox.MssqlDatabases.RobloxDatabase.RobloxRoles;

    public int ID { get; set; }
    public string Name { get; set; }
    public int Rank { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }

    private static RoleSetDAL BuildDAL(IDictionary<string, object> record)
    {
        var dal = new RoleSetDAL();
        dal.ID = (int)record["ID"];
        dal.Name = (string)record["Name"];
        dal.Rank = (int)record["Rank"];
        dal.Created = (DateTime)record["Created"];
        dal.Updated = (DateTime)record["Updated"];

        return dal;
    }

    internal void Delete()
    {
        _Database.Delete("RoleSets_DeleteRoleSetByID", ID);
    }

    internal void Insert()
    {
        var queryParameters = new SqlParameter[]
        {
            new SqlParameter("@ID", ID) { Direction = ParameterDirection.Output },
            new SqlParameter("@Name", Name),
            new SqlParameter("@Rank", Rank),
            new SqlParameter("@Created", Created),
            new SqlParameter("@Updated", Updated),
        };

        ID = _Database.Insert<int>("RoleSets_InsertRoleSet", queryParameters);
    }

    internal void Update()
    {
        var queryParameters = new SqlParameter[]
        {
            new SqlParameter("@ID", ID),
            new SqlParameter("@Name", Name),
            new SqlParameter("@Rank", Rank),
            new SqlParameter("@Created", Created),
            new SqlParameter("@Updated", Updated),
        };

        _Database.Update("RoleSets_UpdateRoleSetByID", queryParameters);
    }

    internal static RoleSetDAL Get(int id)
    {
        return _Database.Get(
            "RoleSets_GetRoleSetByID",
            id,
            BuildDAL
        );
    }

    public static RoleSetDAL GetByName(string name)
    {
        if (string.IsNullOrEmpty(name))
            return null;

        var queryParameters = new SqlParameter[]
        {
            new SqlParameter("@Name", name),
        };

        return _Database.Lookup(
            "RoleSets_GetRoleSetByName",
            BuildDAL,
            queryParameters
        );
    }

    public static ICollection<int> GetAll()
    {
        return _Database.GetIDCollection<int>(
            "RoleSets_GetAllRoleSetIDs"
        );
    }
}
