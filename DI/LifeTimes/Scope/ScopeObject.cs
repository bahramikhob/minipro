using System;
using System.Collections.Generic;
using System.Linq;

namespace DI.LifeTimes
{
    public class ScopeObject : IScopeObject
    {
        private string _id;
        public ScopeObject()
        {
            _id = Guid.NewGuid().ToString();
        }
        public string GetId()
        {
            return _id;
        }
    }
}
