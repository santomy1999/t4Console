using System;
using System.Collections.Generic;

namespace t4Console.Models;

public partial class Page
{
    public int PageId { get; set; }

    public string? PageTitle { get; set; }

    public string? PageDescription { get; set; }

    public string? PageIdentifier { get; set; }

    public virtual ICollection<Domain> Domains { get; } = new List<Domain>();

    public virtual ICollection<Field> Fields { get; } = new List<Field>();
}
