using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities
{
    public abstract class Entity
    {
        protected long Id { get; set; }

        protected void ValidateId(long id)
        {
            if (id < 0)
                DomainExceptionValidation.When(id < 0, "Invalid id value.");

            this.Id = id;
        }
    }
}
