namespace phuong.DTPM;
using System.Collections.Generic;
// 4. Observer Pattern: Balance Notification
// Ứng dụng: Để gửi thông báo mỗi khi số dư tài khoản thay đổi, giúp các phần khác của hệ thống 
// (ví dụ: gửi SMS hoặc email) được cập nhật mà không cần gọi trực tiếp. Đây là giải pháp linh hoạt 
// cho việc mở rộng chức năng mà không cần sửa mã nguồn trong lớp chính.
public class Account
{
    public event Action<string>? BalanceChanged;
    private decimal _balance;

    public decimal Balance
    {
        get => _balance;
        set
        {
            _balance = value;
            BalanceChanged?.Invoke($"New balance is {_balance}");
        }
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"Deposited {amount}, new balance: {Balance}");
    }
}