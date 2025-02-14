namespace MilaSaaS.Application.Common.Pagination;

public class PaginationRequest
{
    private int _page = 0;
    public int Page 
    {
        get => _page <= 0 ? 0 : _page;
        set => _page = value;
    }

    public int CurrentPage => _page;

    private int _pageSize = 20;
    public int ItemsPerPage
    {
        get => _pageSize == 0 ? 20 : _pageSize;
        set => _pageSize = value;
    }
}