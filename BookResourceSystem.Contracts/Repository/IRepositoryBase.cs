using System.Linq.Expressions;

namespace BookResourceSystem.Contracts.Repository;

public interface IRepositoryBase<T>
{
    /// <summary>
    /// 建立實體
    /// </summary>
    /// <param name="entity"></param>
    void Create(T entity);

    /// <summary>
    /// 取得所有實體
    /// </summary>
    /// <param name="trackChanges"></param>
    /// <returns></returns>
    IQueryable<T> FindAll(bool trackChanges);

    /// <summary>
    /// 取得符合條件的實體
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="trackChanges"></param>
    /// <returns></returns>
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

    /// <summary>
    /// 更新實體
    /// </summary>
    /// <param name="entity"></param>
    void Update(T entity);

    /// <summary>
    /// 刪除實體
    /// </summary>
    /// <param name="entity"></param>
    void Delete(T entity);
}

