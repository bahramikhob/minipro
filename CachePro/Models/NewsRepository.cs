namespace CachePro.Models
{
    public class NewsRepository
    {
        public int GetNewCount()
        {
            System.Threading.Thread.Sleep(4000);
            return 10;
        }

    }
}

