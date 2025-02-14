namespace MilaSaaS.Application.Common.Pagination;

public static class PaginationExtension
{
    public static PaginationResponse<T> ToPaginatedResponse<T>(this List<T> list, int totalItems, IReadOnlyCollection<T> items, int pageSize, int currentPage) where T: class
    {
        return new PaginationResponse<T>(totalItems, items, pageSize, currentPage);
    }
    
    public static PaginationResponse<T> ToPaginatedResponse<T>(this List<T> list, int totalItems, int pageSize, int currentPage) where T: class
    {
        return new PaginationResponse<T>(totalItems, list, pageSize, currentPage);
    }
    
    public static PaginationResponse<T> ToPaginatedResponse<T>(this List<T> list, int pageSize, int currentPage) where T: class
    {
        var totalItems = list.Count();
        return new PaginationResponse<T>(totalItems, list, pageSize, currentPage);
    }
}