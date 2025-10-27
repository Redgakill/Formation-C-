using ConsoleApp1;

const String path = @"C:\\Users\\Lilian\\Documents\\C#\\CoursSupDeVinci_C#.csv";

#region recuperation CSV

Dictionary<int,Person> persons = new Dictionary<int, Person>(); 

var lignes = File.ReadAllLines(path);

for (int i = 1; i < lignes.Length; i++)
{
    String line = lignes[i];
    Person person = new Person();
    
    person.Lastname = line.Split(',')[1];
    person.Firstname = line.Split(',')[2];
    person.Birthdate = ConvertToDateTime(line.Split(',')[3]);
    person.Taille = Int32.Parse(line.Split(',')[5]);
    
    List<String> details = line.Split(',')[4].Split(';').ToList();
    
    person.AdressDetails = new Detail(details[0], int.Parse(details[1]), details[2]);
    
    persons.Add(int.Parse(line.Split(',')[0]), person);
    
}
#endregion

#region renseigne à la main

// Person person1 = new Person();
// Person person2 = new Person();
//
// Console.WriteLine("Quelle est le nom de P1 ?");
// person1.Lastname = Console.ReadLine();
// Console.WriteLine("Quelle est le nom de P2 ?");
// person2.Lastname = Console.ReadLine();
//
// Console.WriteLine("Quelle est le prénom de P1 ?");
// person1.Firstname = Console.ReadLine();
// Console.WriteLine("Quelle est le prénom de P2 ?");
// person2.Firstname = Console.ReadLine();
//
// Console.WriteLine("Quelle est votre Date de Naissance de P1 (au format JJ/MM/YYYY) ?");
// String birthDate1 = Console.ReadLine();
// Console.WriteLine("Quelle est votre Date de Naissance P2 (au format JJ/MM/YYYY) ?");
// String birthDate2 = Console.ReadLine();
//
// Console.WriteLine("Quelle est l'adresse de P1 (au format rue,codePostal,Ville) ?");
// String address1 = Console.ReadLine();
// Console.WriteLine("Quelle est l'adresse de P2 (au format rue,codePostal,Ville) ?");
// String address2 = Console.ReadLine();
//
// List<String> listAdress = address1.Split(",").ToList();
// List<String> listAdress2 = address2.Split(",").ToList();
//
// person1.AdressDetails = new Detail(listAdress[0], Int32.Parse(listAdress[1]), listAdress[2]);
// person2.AdressDetails = new Detail(listAdress2[0], Int32.Parse(listAdress2[1]), listAdress2[2]);

    #endregion

#region Taille moyenne

double tailleMoyenne = persons.Average(person => person.Value.Taille);

Dictionary<int, Person> tallerPersons = persons.Where(person => person.Value.Taille > tailleMoyenne)
    .ToDictionary(person => person.Key, person => person.Value);

//Console.WriteLine($"Il y a {tallerPersons.Count.ToString()} personnes qui sont plus grandes que la moyenne ");
                  
#endregion

#region boucle affiche toute la classe

// foreach (KeyValuePair<int, Person> person in persons)
// {
// Console.WriteLine($"Bonjour {person.Value.Firstname} {person.Value.Lastname},");
// Console.WriteLine($"tu as {person.Value.getYearsOld().ToString()} ans et tu habites au {person.Value.AdressDetails.Street}" +
//                   $" {person.Value.AdressDetails.ZipCode.ToString()} {person.Value.AdressDetails.City}.");

// }

#endregion

#region Console.WriteLine Exo 1 qui est plus quand des deux

    // if (person1.getYearsOld() > person2.getYearsOld())
// {
//     Console.WriteLine($"{person1.Firstname} {person1.Lastname} est plus agé(e) que {person2.Firstname} {person2.Lastname} de {(person1.getYearsOld() - person2.getYearsOld()).ToString()} an(s)");
// }
// else if (person1.getYearsOld() < person2.getYearsOld())
// {
//     Console.WriteLine($"{person2.Firstname} {person2.Lastname} est plus agé(e) que {person1.Firstname} {person1.Lastname} de {(person2.getYearsOld() - person1.getYearsOld()).ToString()} an(s)");
// }
// else
// {
//     Console.WriteLine($"{person1.Firstname} {person1.Lastname} a le même age que {person2.Firstname} {person2.Lastname}");
// }

    #endregion

#region Date de naissance
DateTime ConvertToDateTime(String date)
{
    if (DateTime.TryParse(date, out DateTime birthdate))
    {
        return  birthdate;
    }
    else
    {
        Console.WriteLine($"La date de P1 est mal renseignée");
        return DateTime.Now;
    }
}
#endregion

#region Exercice 4

Classe B2 = new Classe("B2", persons.Values.ToList(), "Sup De Vinci", "Bachelier 2");
int id = 0;

List<Person> GrandEleve = B2.Eleve.Where(eleve => eleve.Taille > tailleMoyenne && eleve.AdressDetails.City == "Nantes").OrderByDescending(eleve => eleve.Taille).ToList(); // Création d'une liste qui comprend les élèves selon certain critères (taille supérieur a la moyenne, ou l'adresse comprend Nantes) puis trier par ordre décroissant

Console.WriteLine("Les personnes les plus grandes de la classe sont :");

foreach (Person person in GrandEleve) // Un boucle permettant d'afficher toute les informations conforme a la liste
{
    id++; // Incrementation de l'id après chaque boucle pour pouvoir classé les tailles
    double taille = person.Taille / 100.00; // Permet de mettre la taille en mètre
    Console.WriteLine($"{id} - {person.Firstname} - {taille} m");
}


#endregion