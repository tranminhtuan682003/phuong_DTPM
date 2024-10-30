namespace phuong.DTPM;

// 9. Template Method Pattern: Transaction Process
// Ứng dụng: Định nghĩa quy trình cơ bản cho một giao dịch và cho phép các lớp con ghi đè một số bước cụ thể
// (như DomesticTransaction).Điều này giúp giữ nguyên cấu trúc tổng thể của quy trình nhưng vẫn có sự linh hoạt 
// cho từng loại giao dịch khác nhau.
public abstract class Transaction
{
    public void ExecuteTransaction(decimal amount)
    {
        ValidateAccount();
        ProcessTransaction(amount);
        NotifyCustomer();
    }

    protected abstract void ProcessTransaction(decimal amount);
    protected virtual void ValidateAccount() => Console.WriteLine("Account validated.");
    protected virtual void NotifyCustomer() => Console.WriteLine("Customer notified.");
}

public class DomesticTransaction : Transaction
{
    protected override void ProcessTransaction(decimal amount) => Console.WriteLine($"Processing domestic transaction of {amount}.");
}