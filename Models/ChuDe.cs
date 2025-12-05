using System;
using System.Collections.Generic;

namespace proMvcApi.Models;

public partial class ChuDe
{
    public int MaChuDe { get; set; }

    public string TenChuDe { get; set; } = null!;

    public string? MoTa { get; set; }

    public virtual ICollection<Sach> Saches { get; set; } = new List<Sach>();
}
