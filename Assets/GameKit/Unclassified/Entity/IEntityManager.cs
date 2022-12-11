using GameKit;
using System;
using System.Collections.Generic;

namespace GameKit
{
    public interface IEntityManager
    {
        int EntityCount { get; }
        int EntityGroupCount { get; }
        void SetObjectPoolManager(IObjectPoolManager objectPoolManager);
        void SetEntityHelper(IEntityHelper entityHelper);
        bool HasEntityGroup(string entityGroupName);
        IEntityGroup GetEntityGroup(string entityGroupName);
        IEntityGroup[] GetAllEntityGroups();
        bool AddEntityGroup(string groupName, float releaseInterval, int instanceCapacity, float instanceExpireTime, int instancePriority = 0, object userData = null);
        bool HasEntity(int entityId);
        bool HasEntity(string entityAssetName);
        IEntity GetEntity(int entityId);
        IEntity GetEntity(string entityAssetName);
        IEntity[] GetEntities(string entityAssetName);
        IEntity[] GetAllEntities();
        void ShowEntity(int entityId, string entityAssetName, string entityGroupName, int priority = 0);
        void HideEntity(int entityId);
        int GetChildEntityCount(int parentEntityId);
        IEntity GetParentEntity(int childEntityId);
        IEntity GetChildEntity(int parentEntityId);
        IEntity[] GetChildEntities(int parentEntityId);

        void AttachEntity(int childEntityId, int parentEntityId, object userData);
        void DetachEntity(int childEntityId, object userData);
        void DetachChildEntities(int parentEntityId);
    }
}