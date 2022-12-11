using System;
using System.Collections.Generic;
using UnityEngine;
namespace GameKit
{
    public sealed partial class EntityComponent : GameKitComponent
    {
        private const int DefaultPriority = 0;
        private IEntityManager m_EntityManager = null;
        private readonly List<IEntity> m_EntityResults = new List<IEntity>();
        public int EntityCount
        {
            get
            {
                return m_EntityManager.EntityCount;
            }
        }

        /// <summary>
        /// 获取实体组数量。
        /// </summary>
        public int EntityGroupCount
        {
            get
            {
                return m_EntityManager.EntityGroupCount;
            }
        }
    }
}
