using System;
using System.Collections.Generic;

namespace t4Console.Models;

public partial class Field
{
    public int FieldId { get; set; }

    public string? FieldName { get; set; }

    public string? FieldDescription { get; set; }

    public string? FieldType { get; set; }

    public int? PageId { get; set; }

    public string? DisplayName { get; set; }

    public int? Sequence { get; set; }

    public virtual ICollection<Domain> Domains { get; } = new List<Domain>();

    public virtual Page? Page { get; set; }
}
