namespace phuong.DTPM;

// 6. Command Pattern: Transaction Commands
// Ứng dụng: Tạo các lệnh giao dịch(như gửi tiền, rút tiền) và cho phép thực hiện lại hoặc hoàn tác lệnh. 
// Đây là giải pháp hữu ích cho hệ thống giao dịch, đặc biệt là khi cần thao tác với các thao tác phải hoàn tác 
// hoặc lịch sử lệnh giao dịch.
public interface ICommand
{
    void Execute();
    void Undo();
}

public class DepositCommand : ICommand
{
    private readonly Account _account;
    private readonly decimal _amount;

    public DepositCommand(Account account, decimal amount)
    {
        _account = account;
        _amount = amount;
    }

    public void Execute() => _account.Deposit(_amount);
    public void Undo() => _account.Deposit(-_amount);
}