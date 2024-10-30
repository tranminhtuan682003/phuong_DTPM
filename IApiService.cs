namespace phuong.DTPM;
//16. Cơ chế Caching cho Kết nối API (Proxy Pattern mở rộng)
// Ý tưởng: Sử dụng Proxy Pattern để tạo một lớp caching nhằm giảm tải cho các yêu cầu đến API bên ngoài.
public interface IApiService
{
    string GetData(string query);
}

public class RealApiService : IApiService
{
    public string GetData(string query)
    {
        Console.WriteLine("Fetching from API...");
        return "Data from API"; // Giả lập dữ liệu
    }
}

public class ApiServiceProxy : IApiService
{
    private readonly RealApiService _realService = new();
    private readonly Dictionary<string, string> _cache = new();

    public string GetData(string query)
    {
        if (_cache.ContainsKey(query))
        {
            Console.WriteLine("Returning cached data.");
            return _cache[query];
        }
        var data = _realService.GetData(query);
        _cache[query] = data;
        return data;
    }
}

