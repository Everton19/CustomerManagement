namespace CustomerManagement.Interfaces
{
    public interface IUnit
    {
        void Commit();
        Task CommitAsync();
    }
}
