namespace phuong.DTPM;
// 14. Tích hợp Analytics cho Giao dịch (Observer Pattern mở rộng)
// Ý tưởng: Sử dụng Observer để ghi lại thông tin về các giao dịch và gửi dữ liệu đến dịch vụ phân tích. 
// Điều này cho phép theo dõi và phân tích thói quen chi tiêu hoặc bất thường trong giao dịch.
public class AnalyticsService
{
    public void TrackTransaction(decimal amount) => Console.WriteLine($"Tracking transaction of {amount}");
}

public class ObservableAccount
{
    public event Action<decimal>? TransactionProcessed;

    public void Deposit(decimal amount)
    {
        TransactionProcessed?.Invoke(amount);
        Console.WriteLine($"Deposited {amount}");
    }
}

