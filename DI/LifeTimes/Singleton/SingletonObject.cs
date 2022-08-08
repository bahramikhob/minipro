using System;

namespace DI.LifeTimes
{
    public class SingletonObject : ISingletonObject
    {
        private string _id;
        public SingletonObject()
        {
            _id = Guid.NewGuid().ToString();
        }
        public string GetId()
        {
            return _id;
        }
    }
}
