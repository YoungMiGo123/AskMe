namespace AskMe.Core.Core.Data.Interfaces
{
    public interface IAudit
    {
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool Deactivatated { get; set; }
        public DateTime DeactivatedDate { get; set; }
    }
}
