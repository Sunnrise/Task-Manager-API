using TaskManagerAPI.Application.DTOs;

namespace TaskManagerAPI.Application.Features.User.Commands.LoginUser
{
    public class LoginUserCommandResponse
    { 
    }
    public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
    {
        public Token Token { get; set; }
    }
    public class LoginUserFailureCommandResponse : LoginUserCommandResponse
    {
        public string ErrorMessage { get; set; }
    }
}
