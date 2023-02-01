using System;
using System.Collections.Generic;

namespace TestApp.MVC.Data;

public partial class Admin
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;
}
