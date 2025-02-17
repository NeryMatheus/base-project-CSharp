namespace base_project_CSharp.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public Task Commit();
    }
}
