using BookResourceSystem.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookResourceSystem.Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected RepositoryContext repositoryContext;

    public RepositoryBase(RepositoryContext repositoryContext)
    {
        this.repositoryContext = repositoryContext;
    }

    /// <inheritdoc/>
    public void Create(T entity)
    {
        repositoryContext.Set<T>().Add(entity);
    }

    /// <inheritdoc/>
    public IQueryable<T> FindAll(bool trackChanges)
    {
        if (!trackChanges)
        {
            return repositoryContext.Set<T>().AsNoTracking();
        }
        else
        {
            return repositoryContext.Set<T>();
        }
    }

    /// <inheritdoc/>
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        return !trackChanges ? repositoryContext.Set<T>().Where(expression).AsNoTracking()
            : repositoryContext.Set<T>().Where(expression);
    }
    /// <inheritdoc/>
    public void Update(T entity)
    {
        repositoryContext.Set<T>().Update(entity);
    }

    /// <inheritdoc/>
    public void Delete(T entity)
    {
        repositoryContext.Set<T>().Remove(entity);
    }



}

