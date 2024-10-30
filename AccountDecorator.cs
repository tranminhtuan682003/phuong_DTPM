namespace phuong.DTPM;

// 5. Decorator Pattern: Insurance for Account
// Ứng dụng: Thêm các tính năng bổ sung(như bảo hiểm) vào tài khoản mà không cần thay đổi lớp tài khoản gốc. 
// Điều này giúp mở rộng tính năng cho tài khoản mà không làm thay đổi mã của lớp cơ bản, duy trì tính module và dễ bảo trì.
public abstract class AccountDecorator : BankAccount
{
    protected BankAccount _account;
    protected AccountDecorator(BankAccount account) => _account = account;
    public override void DisplayAccountType() => _account.DisplayAccountType();
}

public class InsuranceDecorator : AccountDecorator
{
    public InsuranceDecorator(BankAccount account) : base(account) { }
    public override void DisplayAccountType()
    {
        base.DisplayAccountType();
        Console.WriteLine("with Insurance");
    }
}