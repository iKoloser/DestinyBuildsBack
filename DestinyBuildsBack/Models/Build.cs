namespace DestinyBuildsBack.Models;

public class Build
{
    public int Id { get; set; }
    public string Nombre { get; set; }
        
    public int ClaseId { get; set; }
    public Clase Clase { get; set; }
        
    public int SubclaseId { get; set; }
    public Subclase Subclase { get; set; }
        
    public int ArmaPrincipalId { get; set; }
    public Arma ArmaPrincipal { get; set; }
        
    public int ArmaSecundariaId { get; set; }
    public Arma ArmaSecundaria { get; set; }
        
    public int ArmaTerciariaId { get; set; }
    public Arma ArmaTerciaria { get; set; }
        
    public int ArmaduraExoticaId { get; set; }
    public ArmaduraExotica ArmaduraExotica { get; set; }
        
    public string Mods { get; set; }
}