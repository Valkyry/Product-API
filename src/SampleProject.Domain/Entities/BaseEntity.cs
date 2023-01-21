using System.ComponentModel.DataAnnotations;

namespace SampleProject.Domain.Entities
{
    public abstract class BaseEntity<TStruct> where TStruct : struct
    {
        public TStruct Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
