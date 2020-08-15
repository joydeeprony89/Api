using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain
{
    public abstract class DomainObject<TKey> : IDomainObject<TKey> where TKey : struct
    {
        public TKey Id { get; set; }
    }
}
