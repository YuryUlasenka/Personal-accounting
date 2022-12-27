namespace Repository.Interfaces
{
    public interface IRepositoryManager
    {
        IUserRepository UserRepository { get; }
        void Save();
    }
}
