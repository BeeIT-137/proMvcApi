using System;
using System.Collections.Generic;

namespace proMvcApi.Models;

public partial class Sach
{
    public int MaSach { get; set; }

    public string TenSach { get; set; } = null!;

    public string? TacGia { get; set; }

    public decimal Gia { get; set; }

    public int? NamXuatBan { get; set; }

    public int MaChuDe { get; set; }

    public virtual ChuDe MaChuDeNavigation { get; set; } = null!;
}
