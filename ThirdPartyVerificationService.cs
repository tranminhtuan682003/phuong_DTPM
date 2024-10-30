namespace phuong.DTPM;

// 7. Adapter Pattern: User Verification
// Ứng dụng: Tích hợp một dịch vụ của bên thứ ba (như xác minh thông tin khách hàng) vào hệ thống mà không cần 
// thay đổi giao diện của hệ thống chính. Adapter giúp hệ thống của bạn tương tác dễ dàng với dịch vụ bên ngoài 
// mà không cần thay đổi cấu trúc mã nguồn.
public class ThirdPartyVerificationService
{
    public bool ValidateUserData(string name, string id) => true;
}

public interface IUserVerification
{
    bool Verify(string name, string id);
}

public class UserVerificationAdapter : IUserVerification
{
    private readonly ThirdPartyVerificationService _service = new();
    public bool Verify(string name, string id) => _service.ValidateUserData(name, id);
}
