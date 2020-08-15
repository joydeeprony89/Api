using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain
{
    public interface IDomainObject<TKey> where TKey : struct
    {
        TKey Id { get; set; }
    }
}
