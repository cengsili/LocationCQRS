using Borda.Service.DotnetCore.Entities;
using Location.Service.Domain.SeedWork;
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
        protected static void CheckRule(IBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }
    }
}
