
namespace utility_service.Interfaces
{
    public interface Repository
    {
        object FindById(Manager.Mysql databaseManager, object id);
        object Collect(Manager.Mysql databaseManager);
        object Save(Manager.Mysql databaseManager);
    }

}