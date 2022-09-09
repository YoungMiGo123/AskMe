using AskMe.Core.Core.Data.Interfaces;

namespace AskMe.Core.Core.Data.Entities
{
    public class Lead : IAudit
    {
        public string Email { get; set; }
        public bool Subscribed { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Deactivatated { get; set; }
        public DateTime DeactivatedDate { get; set; }
    }
}
