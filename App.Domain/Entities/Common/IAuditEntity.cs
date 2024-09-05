namespace App.Domain.Entities.Common
{
    public interface IAuditEntity
    {
        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }
    }
}