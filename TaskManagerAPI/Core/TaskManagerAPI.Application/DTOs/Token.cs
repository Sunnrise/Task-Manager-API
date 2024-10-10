using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerAPI.Application.DTOs
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string RefreshToken { get; set; }
    }
}
