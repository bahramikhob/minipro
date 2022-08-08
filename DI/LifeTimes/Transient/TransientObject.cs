using System;

namespace DI.LifeTimes
{
    public class TransientObject : ITransientObject
    {
        private string _id;
        public TransientObject()
        {
            _id = Guid.NewGuid().ToString();
        }
        public string GetId()
        {
            return _id;
        }
    }
}
