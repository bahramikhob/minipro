namespace CachePro.Models
{
    public interface ICacheAdapter
    {
        TOutput Get<TOutput>(string key);
        void Set<TInput>(string key, TInput input);
    }
}
