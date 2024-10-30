namespace phuong.DTPM;

// 10. Proxy Pattern: Account Access Proxy
// Ứng dụng: Tạo một proxy cho Account để kiểm soát quyền truy cập.Proxy đảm bảo chỉ những người dùng có quyền truy cập 
// mới có thể thực hiện các thao tác nhạy cảm với tài khoản. Điều này bảo vệ tài khoản và tăng tính bảo mật của hệ thống.
public class User
{
    public bool HasAccess { get; set; }
}

public class AccountProxy : BankAccount
{
    private readonly BankAccount _realAccount;
    private readonly User _user;

    public AccountProxy(BankAccount realAccount, User user)
    {
        _realAccount = realAccount;
        _user = user;
    }

    public override void DisplayAccountType()
    {
        if (_user.HasAccess)
        {
            _realAccount.DisplayAccountType();
        }
        else
        {
            Console.WriteLine("Access Denied.");
        }
    }
}