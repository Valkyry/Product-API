using SampleProject.Application.DTO;

namespace SampleProject.Application.Identity
{
    public partial class Authenticate
    {
        public class Response
        {
            public string UserId { get; set; }
            public string Name { get; set; }
            public string Token { get; set; }
        }
    }
}
