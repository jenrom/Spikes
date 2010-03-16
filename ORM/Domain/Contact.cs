using System.Data.Objects.DataClasses;

namespace OrmSpikes.Domain
{
    [EdmEntityType(Name = "Contact", NamespaceName = "OrmSpikes.Domain")]
    public class Contact
    {
        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false)]
        public virtual int Id { get; set; }

        [EdmScalarProperty(IsNullable = false)]
        public virtual string Name { get; set; }

        public virtual Domain.Address Address { get; set; }
    }
}