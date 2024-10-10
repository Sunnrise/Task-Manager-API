using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAPI.Application.Features.User.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(): base("User not found e-mail or password incorrect")
        {
            
        }

        public UserNotFoundException(string? message) : base(message)
        {
        }

        public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
