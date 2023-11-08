using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities
{
    public abstract class Entity
    {
        public long Id { get; protected set; }

        protected void ValidateId(long id)
        {
            if (id < 0)
                DomainExceptionValidation.When(id < 0, "Invalid id value.");

            this.Id = id;
        }
    }
}
