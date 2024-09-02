using MediatR;

public class ConfirmResetCodeCommand : IRequest<bool>
{
    public string Email { get; set; }
    public string ResetCode { get; set; }
    public Guid userId { get; set; }
    public string NewPassword { get; set; }
}
