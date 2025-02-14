namespace MilaSaaS.Application.Common.Pagination;

public class PaginationResponse<T> where T: class
{
    private int _pageSize;

    public PaginationResponse(int totalItems, IReadOnlyCollection<T> items, int pageSize, int currentPage)
    {
        TotalItems = totalItems;
        Items = items;
        _pageSize = pageSize;
        CurrentPage = currentPage;
    }

    public bool HasNext => CurrentPage < TotalPages;
    
    public bool HasPrevious => CurrentPage > 1;
    public int CurrentPage { get; }

    public int TotalPages
    {
        get
        {
            var pages =  (double)(TotalItems / _pageSize);
            return (int)Math.Ceiling(pages);
        }
    }
    
    public int TotalItems { get; }
    
    public IReadOnlyCollection<T> Items { get; }
}