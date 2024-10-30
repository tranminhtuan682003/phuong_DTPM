namespace phuong.DTPM;

// 8. Facade Pattern: Transaction Management
// Ứng dụng: Cung cấp một giao diện đơn giản để thực hiện toàn bộ quy trình giao dịch. Thay vì phải gọi từng bước như 
// tính phí, kiểm tra số dư, và cập nhật tài khoản, TransactionFacade đơn giản hóa quá trình này thành một phương thức 
// duy nhất, giúp mã rõ ràng và dễ sử dụng hơn.
public class TransactionFacade
{
    private readonly Account _account;
    private readonly ITransactionFeeStrategy _feeStrategy;

    public TransactionFacade(Account account, ITransactionFeeStrategy feeStrategy)
    {
        _account = account;
        _feeStrategy = feeStrategy;
    }

    public void ExecuteTransaction(decimal amount)
    {
        var fee = _feeStrategy.CalculateFee(amount);
        _account.Deposit(amount - fee);
        Console.WriteLine($"Transaction completed with fee {fee}");
    }
}