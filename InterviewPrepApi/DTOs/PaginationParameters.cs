namespace InterviewPrepApi.DTOs;
/// <summary>
/// Параметры пагинации для постраничного вывода данных.
/// </summary>
public class PaginationParameters
{
    /// <summary>
    /// Максимально допустимое количество элементов на странице.
    /// </summary>
    public const int MaxPageSize = 50;
    
    private int _pageSize = 10;
    /// <summary>
    /// Номер страницы (начиная с 1).
    /// Значение по умолчанию — 1.
    /// </summary>
    public int PageNumber { get; set; } = 1;
    /// <summary>
    /// Количество элементов на странице.
    /// Если значение превышает MaxPageSize (50), то автоматически устанавливается 50.
    /// Значение по умолчанию — 10.
    /// </summary>
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
}