namespace BookResourceSystem.Entities.Models;

/// <summary>
/// 時間紀錄實體。具有建立時間與更新時間欄位。
/// </summary>
public abstract class TimeTrackedEntity
{
    /// <summary>
    /// 實體被建立的時間
    /// </summary>
    public DateTime CreatedAt { get; set; }
    /// <summary>
    /// 實體最後被更新的時間
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
