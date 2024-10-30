namespace phuong.DTPM;
// 11.Thêm Notification Service (Service Pattern)
// Ý tưởng: Thêm một dịch vụ gửi thông báo giúp gửi SMS, email hoặc push notification cho khách hàng khi có giao dịch quan 
// trọng xảy ra, như giao dịch lớn, thay đổi số dư, hay hoạt động đăng nhập bất thường.
public interface INotificationService
{
    void Send(string message, string recipient);
}

public class SmsNotificationService : INotificationService
{
    public void Send(string message, string recipient) => Console.WriteLine($"Sending SMS to {recipient}: {message}");
}

public class EmailNotificationService : INotificationService
{
    public void Send(string message, string recipient) => Console.WriteLine($"Sending Email to {recipient}: {message}");
}
