using System;

namespace CongestionTaxCalculator.Models
{
    public class BaseEntity<T> : SoftDelete where T : struct
    {
        public T Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime? LastUpdateOn { get; set; }

        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType()) return false;
            var otherId = obj as BaseEntity<T>;
            return otherId != null && otherId.Id.Equals(Id);
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public virtual void Delete()
        {
            IsDeleted = true;
            DeletedOn = DateTime.Now;
        }
    }

    public class SoftDelete
    {
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedOn { get; set; }
    }
}
