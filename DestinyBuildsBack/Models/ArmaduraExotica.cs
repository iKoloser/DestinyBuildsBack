﻿namespace DestinyBuildsBack.Models;

public class ArmaduraExotica
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
        
    public int ClaseId { get; set; }
    public Clase Clase { get; set; }
}