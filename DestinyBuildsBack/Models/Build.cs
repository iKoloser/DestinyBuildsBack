namespace DestinyBuildsBack.Models;

public class Build
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public int ClaseId { get; set; }
    public int SubclaseId { get; set; }
    public int ArmaPrincipalId { get; set; }
    public int ArmaSecundariaId { get; set; }
    public int ArmaTerciariaId { get; set; }
    public int ArmaduraExoticaId { get; set; }

    public string Mods { get; set; }
}
