namespace DGI.Domain.Entities
{
    public interface IBase
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        //public string? CreatedBy { get; set; }
        //public string? DeletedBy { get; set; }
        //public string? UpdatedBy { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }

    }
    public class BaseEntity : IBase
    {
        public string Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        //public string? CreatedBy { get; set; }
        //public string? DeletedBy { get; set; }
        //public string? UpdatedBy { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }

    }
}
