using System;
using System.Collections.Generic;

namespace t4Console.Models;

public partial class Domain
{
    public int DomainId { get; set; }

    public string? DomainName { get; set; }

    public int? FieldId { get; set; }

    public string? AttributeValue { get; set; }

    public int? DomainSeq { get; set; }

    public int? PageId { get; set; }

    public virtual Field? Field { get; set; }

    public virtual Page? Page { get; set; }
}
