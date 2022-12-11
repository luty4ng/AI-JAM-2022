using GameKit;
using System;
using System.Collections.Generic;

namespace GameKit
{
    public partial class EntityManager
    {
        public sealed class EntityObject : ObjectBase
        {
            protected internal override void Release(bool isShutdown)
            {
                throw new NotImplementedException();
            }
        }
    }
}