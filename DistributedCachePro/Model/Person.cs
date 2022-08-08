namespace DistributedCachePro
{
    public class Person
    {
        public int id { get; set; }
        public string fullname { get; set; }
        public override string ToString()
        {
            return id + " " + fullname;
        }
    }
}
