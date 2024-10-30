namespace phuong.DTPM;

// 3. Strategy Pattern: Transaction Fee Calculation
// Ứng dụng: Thay đổi cách tính phí giao dịch cho các loại tài khoản khác nhau(Savings, Checking). Thay vì hard - code 
// logic tính phí, chúng ta có thể áp dụng các chiến lược tính phí khác nhau tùy vào loại tài khoản.
public interface ITransactionFeeStrategy
{
    decimal CalculateFee(decimal amount);
}

public class SavingsFeeStrategy : ITransactionFeeStrategy
{
    public decimal CalculateFee(decimal amount) => amount * 0.02m;
}

public class CheckingFeeStrategy : ITransactionFeeStrategy
{
    public decimal CalculateFee(decimal amount) => amount * 0.01m;
}