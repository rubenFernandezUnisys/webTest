using System;
using System.Collections.Generic;

namespace TestApp.MVC.Data;

public partial class Oficina
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Codigo { get; set; }

    public string? Calle { get; set; }
}
