namespace Roblox.Roles.Entities;

using System;
using System.Collections.Generic;

using Roblox.Data;
using Roblox.Caching;
using Roblox.Data.Interfaces;
using Roblox.Caching.Interfaces;

internal class UserRoleSet : IRobloxEntity<long, UserRoleSetDAL>
{
    private UserRoleSetDAL _EntityDAL;

    /// <inheritdoc cref="ICacheableObject{TIndex}.ID"/>
    public long ID
    {
        get { return _EntityDAL.ID; }
    }

    public long UserID
    {
        get { return _EntityDAL.UserID; }
        set { _EntityDAL.UserID = value; }
    }

    public int RoleSetID
    {
        get { return _EntityDAL.RoleSetID; }
        set { _EntityDAL.RoleSetID = value; }
    }

    public DateTime Created
    {
        get { return _EntityDAL.Created; }
    }

    public DateTime Updated
    {
        get { return _EntityDAL.Updated; }
    }

    public UserRoleSet()
    { 
        _EntityDAL = new UserRoleSetDAL();
    }

    internal void Delete()
    {
        EntityHelper.DeleteEntity(
            this,
            _EntityDAL.Delete
        );
    }

    internal void Save()
    {
        EntityHelper.SaveEntity(
            this, 
            () =>
            {
                _EntityDAL.Created = DateTime.Now;
                _EntityDAL.Updated = _EntityDAL.Created;
                _EntityDAL.Insert();
            }, 
            () =>
            {
                _EntityDAL.Updated = DateTime.Now;
                _EntityDAL.Update();
            }
        );
    }

    internal static UserRoleSet Get(long id)
    {
        return EntityHelper.GetEntity<long, UserRoleSetDAL, UserRoleSet>(
            EntityCacheInfo, 
            id, 
            () => UserRoleSetDAL.Get(id)
        );
    }

    public static UserRoleSet GetByUserIDAndRoleSetID(long userID, int roleSetID)
    {
        return EntityHelper.GetEntityByLookup<long, UserRoleSetDAL, UserRoleSet>(
            EntityCacheInfo,
            string.Format("UserID:{0}_RoleSetID:{1}", userID, roleSetID),
            () => UserRoleSetDAL.GetByUserIDAndRoleSetID(userID, roleSetID)
        );
    }

    public static ICollection<UserRoleSet> GetAllUserRoleSetsPaged(long startRowIndex, long maximumRows)
    {
        var collectionId = "GetAllUserRoleSetsPaged";

        return EntityHelper.GetEntityCollection<UserRoleSet, long>(
            EntityCacheInfo,
            CacheManager.UnqualifiedNonExpiringCachePolicy,
            collectionId,
            () =>
            {
                return UserRoleSetDAL.GetAllUserRoleSetsPaged(
                    startRowIndex + 1,
                    maximumRows
                );
            },
            Get
        );
    }

    public static int GetTotalNumberOfUserRoleSets()
    {
        var countId = "GetTotalNumberOfUserRoleSets";

        return EntityHelper.GetEntityCount<int>(
            EntityCacheInfo,
            CacheManager.UnqualifiedNonExpiringCachePolicy,
            countId,
            () => UserRoleSetDAL.GetTotalNumberOfUserRoleSets()
        );
    }

    public static ICollection<UserRoleSet> GetUserRoleSetsByUserIDPaged(long userID, long startRowIndex, long maximumRows)
    {
        var collectionId = string.Format("GetUserRoleSetsByUserIDPaged_UserID:{0}_StartRowIndex:{1}_MaximumRows:{2}", userID, startRowIndex, maximumRows);

        return EntityHelper.GetEntityCollection<UserRoleSet, long>(
            EntityCacheInfo,
            new CacheManager.CachePolicy(
                CacheManager.CacheScopeFilter.Qualified,
                string.Format("UserID:{0}", userID)
            ),
            collectionId,
            () =>
            {
                return UserRoleSetDAL.GetUserRoleSetsByUserIDPaged(
                    userID,
                    startRowIndex + 1,
                    maximumRows
                );
            },
            Get
        );
    }

    public static ICollection<UserRoleSet> GetUserRoleSetsByRoleSetIDPaged(int roleSetID, long startRowIndex, long maximumRows)
    {
        var collectionId = string.Format("GetUserRoleSetsByRoleSetIDPaged_RoleSetID:{0}_StartRowIndex:{1}_MaximumRows:{2}", roleSetID, startRowIndex, maximumRows);

        return EntityHelper.GetEntityCollection<UserRoleSet, long>(
            EntityCacheInfo,
            new CacheManager.CachePolicy(
                CacheManager.CacheScopeFilter.Qualified,
                string.Format("RoleSetID:{0}", roleSetID)
            ),
            collectionId,
            () =>
            {
                return UserRoleSetDAL.GetUserRoleSetsByRoleSetIDPaged(
                    roleSetID,
                    startRowIndex + 1,
                    maximumRows
                );
            },
            Get
        );
    }

    #region IRobloxEntity Members

    /// <inheritdoc cref="IRobloxEntity{TIndex, TDal}.Construct(TDal)"/>
    public void Construct(UserRoleSetDAL dal)
    {
        _EntityDAL = dal;
    }

    #endregion IRobloxEntity Members

    #region ICacheableObject Members

    /// <inheritdoc cref="ICacheableObject.CacheInfo"/>
    public CacheInfo CacheInfo
    {
        get { return EntityCacheInfo; }
    }

    /// <inheritdoc cref="ICacheableObject.CacheInfo"/>
    public static CacheInfo EntityCacheInfo = new CacheInfo(
        new CacheabilitySettings(collectionsAreCacheable: false, countsAreCacheable: false, entityIsCacheable: true, idLookupsAreCacheable: true, hasUnqualifiedCollections: false, idLookupsAreCaseSensitive: false),
        typeof(UserRoleSet).ToString(),
        true
    );

    /// <inheritdoc cref="ICacheableObject.BuildEntityIDLookups"/>
    public IEnumerable<string> BuildEntityIDLookups()
    {
        yield return string.Format("UserID:{0}_RoleSetID:{1}", UserID, RoleSetID);
        yield break;
    }

    /// <inheritdoc cref="ICacheableObject.BuildStateTokenCollection"/>
    public IEnumerable<StateToken> BuildStateTokenCollection()
    {
        yield return new StateToken(string.Format("UserID:{0}", UserID));
        yield return new StateToken(string.Format("RoleSetID:{0}", RoleSetID));
        yield break;
    }

    #endregion ICacheableObject Members
}
