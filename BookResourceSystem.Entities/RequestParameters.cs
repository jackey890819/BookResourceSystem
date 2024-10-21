namespace BookResourceSystem.Entities;

public abstract class RequestParameters
{
    protected const int defaultPageSize = 10;
    protected const int maxPageSize = 50;
    //private int _pageSize = 10;

    public int? PageNumber { get; set; } = 1;

    public int? PageSize { get; set; } = defaultPageSize;
    //{
    //    get { return _pageSize; }
    //    set
    //    {
    //        _pageSize = (value > maxPageSize) ? maxPageSize : value;
    //        //if (value is not null)
    //        //{
    //        //    // 檢查是否超過最大存取頁數
    //        //    _pageSize = (int)((value > maxPageSize) ? maxPageSize : value);
    //        //}
    //    }
    //}

    /// <summary>
    /// 取得符合制度的
    /// </summary>
    /// <returns></returns>
    public int GetPageNumber()
    {
        if (PageNumber is not null && PageNumber > 0)
            return (int)PageNumber;
        return 1;
    }

    public int GetPageSize()
    {
        if (PageSize is not null && PageSize > 0 )
        {
            if (PageSize > maxPageSize) return maxPageSize;
            return (int)PageSize;
        }
        return defaultPageSize;
    }

    /// <summary>
    /// 排序字串
    /// </summary>
    public string? OrderBy { get; set; }

    /// <summary>
    /// 用於Data Shaping
    /// </summary>
    //public string? Fields { get; set; }
}
