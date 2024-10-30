namespace phuong.DTPM;

// 2. Factory Pattern: Account Factory
// Ứng dụng: Để tạo các loại tài khoản ngân hàng khác nhau(ví dụ: SavingsAccount, CheckingAccount) 
// mà không cần thay đổi logic khởi tạo trong các phần khác của chương trình.Điều này giúp việc mở rộng
// các loại tài khoản dễ dàng mà không cần sửa đổi nhiều mã nguồn.
public abstract class BankAccount
{
    public abstract void DisplayAccountType();
}

public class SavingsAccount : BankAccount
{
    public override void DisplayAccountType() => Console.WriteLine("Savings Account");
}

public class CheckingAccount : BankAccount
{
    public override void DisplayAccountType() => Console.WriteLine("Checking Account");
}

public class AccountFactory
{
    public BankAccount CreateAccount(string accountType)
    {
        return accountType switch
        {
            "Savings" => new SavingsAccount(),
            "Checking" => new CheckingAccount(),
            _ => throw new ArgumentException("Invalid account type")
        };
    }
}