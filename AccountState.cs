namespace phuong.DTPM;
//5. Cơ chế Cash-back cho Khách Hàng VIP (State Pattern)
// Ý tưởng: Sử dụng State Pattern để thay đổi hành vi của tài khoản dựa trên trạng thái VIP.
// Tài khoản VIP có thể được nhận lại một phần tiền sau mỗi giao dịch.
public abstract class AccountState
{
    public abstract void HandleTransaction(ObservableAccount account, decimal amount);
}

public class RegularState : AccountState
{
    public override void HandleTransaction(ObservableAccount account, decimal amount) => account.Deposit(amount);
}

public class VipState : AccountState
{
    public override void HandleTransaction(ObservableAccount account, decimal amount)
    {
        account.Deposit(amount);
        decimal cashback = amount * 0.05m;
        account.Deposit(cashback);
        Console.WriteLine($"VIP cashback applied: {cashback}");
    }
}


