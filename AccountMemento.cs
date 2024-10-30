namespace phuong.DTPM;
// 12.Chức năng Ghi lại Lịch sử Giao dịch (Memento Pattern)
// Ý tưởng: Sử dụng Memento để lưu lại trạng thái tài khoản sau mỗi giao dịch, cho phép khôi phục lại
//  trạng thái trước đó trong trường hợp có lỗi hoặc gian lận.
public class AccountMemento
{
    public decimal Balance { get; }
    public AccountMemento(decimal balance) => Balance = balance;
}

public class AccountWithHistory
{
    private decimal _balance;
    private Stack<AccountMemento> _history = new();

    public decimal Balance
    {
        get => _balance;
        set
        {
            _history.Push(new AccountMemento(_balance));
            _balance = value;
        }
    }

    public void Restore()
    {
        if (_history.Count > 0)
            _balance = _history.Pop().Balance;
    }
}
