namespace ConsoleApp1;

public class Classe
{
    private string nom;
    private List<Person> eleve;
    private string ecole;
    private string niveau;

    public Classe(string nom, List<Person> eleve, string ecole, string niveau)
    {
        this.nom = nom;
        this.eleve = eleve;
        this.ecole = ecole;
        this.niveau = niveau;
    }

    public string Nom
    {
        get => nom;
        set => nom = value;
    }
    public List<Person> Eleve
    {
        get => eleve;
        set => eleve = value;
    }
    public string Ecole
    {
        get => ecole;
        set => ecole = value;
    }
    public string Niveau
    {
        get => niveau;
        set => niveau = value;
    }

}