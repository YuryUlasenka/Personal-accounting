using Repository.Interfaces;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        //private readonly Lazy<IEntityRepository> _entityRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            //_entityRepository = new Lazy<IEntityRepository>(() => new EntityRepository(repositoryContext));
        }

        //public IEntityRepository Entity = _entityRepository.Value;

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
