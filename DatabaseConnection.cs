namespace phuong.DTPM;
using System;

// 1. Singleton Pattern: Database Connection
// Ứng dụng: Đảm bảo rằng chỉ có một kết nối đến cơ sở dữ liệu trong suốt vòng đời của ứng dụng. 
// Điều này ngăn chặn việc tạo nhiều kết nối dư thừa, giúp tối ưu hiệu năng và quản lý tài nguyên tốt hơn.
public class DatabaseConnection
{
    private static DatabaseConnection? _instance;
    private DatabaseConnection() { }
    public static DatabaseConnection Instance => _instance ??= new DatabaseConnection();
    public void Connect() => Console.WriteLine("Connected to the database.");
}