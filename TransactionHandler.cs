namespace phuong.DTPM;

// 13. Xác thực Giao dịch Nâng cao(Chain of Responsibility Pattern)
// Ý tưởng: Tạo một chuỗi các bước xác thực để kiểm tra tính hợp lệ của giao dịch, 
// bao gồm xác minh danh tính, kiểm tra số dư, và kiểm tra các điều kiện bảo mật.
public abstract class TransactionHandler
{
    protected TransactionHandler? Next;
    public void SetNext(TransactionHandler next) => Next = next;
    public abstract void Handle(decimal amount);
}

public class IdentityVerificationHandler : TransactionHandler
{
    public override void Handle(decimal amount)
    {
        Console.WriteLine("Identity verified.");
        Next?.Handle(amount);
    }
}

public class BalanceCheckHandler : TransactionHandler
{
    private readonly decimal _balance;
    public BalanceCheckHandler(decimal balance) => _balance = balance;

    public override void Handle(decimal amount)
    {
        if (_balance >= amount)
        {
            Console.WriteLine("Sufficient balance.");
            Next?.Handle(amount);
        }
        else
        {
            Console.WriteLine("Insufficient balance.");
        }
    }
}
