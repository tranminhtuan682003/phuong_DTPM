using phuong.DTPM;
public class Program
{
    public static void Main(string[] args)
    {
        // 1. Singleton Pattern - DatabaseConnection (kết nối cơ sở dữ liệu duy nhất)
        DatabaseConnection.Instance.Connect();

        // 2. Factory Pattern - AccountFactory (tạo tài khoản mới)
        var factory = new AccountFactory();
        BankAccount account = factory.CreateAccount("Savings");
        account.DisplayAccountType();

        // 3. Decorator Pattern - InsuranceDecorator (thêm tính năng bảo hiểm cho tài khoản)
        var insuredAccount = new InsuranceDecorator(account);
        insuredAccount.DisplayAccountType();

        // 4. Proxy Pattern - AccountProxy (kiểm soát quyền truy cập vào tài khoản)
        var user = new User { HasAccess = true };
        var proxyAccount = new AccountProxy(account, user);
        proxyAccount.DisplayAccountType();

        // 5. Observer Pattern - Account với BalanceChanged (theo dõi thay đổi số dư)
        var observedAccount = new Account();
        observedAccount.BalanceChanged += message => Console.WriteLine(message);
        observedAccount.Deposit(500);

        // 6. Strategy Pattern - TransactionFeeStrategy (tính phí giao dịch)
        var savingsStrategy = new SavingsFeeStrategy();
        var transactionFacade = new TransactionFacade(new Account(), savingsStrategy);
        transactionFacade.ExecuteTransaction(1000);

        // 7. Facade Pattern - TransactionFacade (thực hiện giao dịch)
        transactionFacade.ExecuteTransaction(300);

        // 8. Command Pattern - DepositCommand (thực hiện lệnh giao dịch và hoàn tác)
        var depositCommand = new DepositCommand(observedAccount, 200);
        depositCommand.Execute();
        depositCommand.Undo();

        // 9. Template Method Pattern - Transaction (quy trình giao dịch cụ thể)
        var domesticTransaction = new DomesticTransaction();
        domesticTransaction.ExecuteTransaction(250);

        // 10. Adapter Pattern - UserVerificationAdapter (xác minh khách hàng từ dịch vụ bên ngoài)
        var verification = new UserVerificationAdapter();
        bool isVerified = verification.Verify("John Doe", "123456");
        Console.WriteLine($"User verified: {isVerified}");

        // 11. Thêm Notification Service (Service Pattern - gửi thông báo)
        INotificationService smsService = new SmsNotificationService();
        smsService.Send("Your balance has been updated.", "123456789");

        // 12. Chức năng Ghi lại Lịch sử Giao dịch (Memento Pattern)
        AccountWithHistory account1 = new AccountWithHistory { Balance = 1000 };
        account1.Balance += 200; // Tăng số dư
        account1.Restore(); // Khôi phục lại số dư trước đó

        // 13. Xác thực Giao dịch Nâng cao (Chain of Responsibility Pattern)
        var identityHandler = new IdentityVerificationHandler();
        var balanceHandler = new BalanceCheckHandler(1000);
        identityHandler.SetNext(balanceHandler);
        identityHandler.Handle(500); // Sẽ thực hiện qua chuỗi xác thực

        // 14. Tích hợp Analytics cho Giao dịch (Observer Pattern mở rộng)
        ObservableAccount account2 = new ObservableAccount();
        AnalyticsService analytics = new AnalyticsService();
        account2.TransactionProcessed += analytics.TrackTransaction;
        account2.Deposit(300); // Gửi thông tin đến AnalyticsService mỗi khi giao dịch

        // 15. Cơ chế Cash-back cho Khách Hàng VIP (State Pattern)
        ObservableAccount vipAccount = new ObservableAccount();
        AccountState state = new VipState();
        state.HandleTransaction(vipAccount, 1000); // Ứng dụng trạng thái VIP

        // 16. Cơ chế Caching cho Kết nối API (Proxy Pattern mở rộng - caching API response)
        IApiService apiService = new ApiServiceProxy();
        Console.WriteLine(apiService.GetData("query1")); // Gọi API
        Console.WriteLine(apiService.GetData("query1")); // Lấy từ cache
    }
}
