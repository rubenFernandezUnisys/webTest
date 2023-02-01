using System;
using System.Collections.Generic;

namespace TestApp.MVC.Data;

public partial class Persona
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public DateTime? FechaNacimiento { get; set; }
}
