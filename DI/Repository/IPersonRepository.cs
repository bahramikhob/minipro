using DI.Domain;

namespace DI.Repository
{
    public interface IPersonRepository
    {
        void AddPerson(Person person);
    }
}