using Borda.Service.DotnetCore.Entities;
using System;

namespace Location.Domain
{
    public class BaseEntity : IEntity<int>, ISoftDelete, IAuditableEntity
    {
        
        public int Id { get; set; }

        public int RecordStatus { get; set; }

        public DateTime CreatedDate { get; set; }

        public Guid CreatedByUserGuid { get; set; }

        public DateTime UpdatedDate { get; set; }

        public Guid UpdatedByUserGuid { get; set; }
    }
}
