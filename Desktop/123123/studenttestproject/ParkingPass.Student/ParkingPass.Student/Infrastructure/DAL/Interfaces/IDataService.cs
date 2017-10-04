namespace ParkingPass.Student.Infrastructure.DAL.Interfaces
{
    public interface IDataService<T>
    {
        bool Save(T obj);
        T Get();
        bool Remove();
        bool Update(T obj);
        bool Exist();
    }
}
