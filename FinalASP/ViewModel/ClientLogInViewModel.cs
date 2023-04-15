using System.ComponentModel.DataAnnotations;

namespace FinalASP.ViewModel
{
    public class ClientLogInViewModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
