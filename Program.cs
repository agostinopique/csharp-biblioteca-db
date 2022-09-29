// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Console.WriteLine("Hello, World!");




#region Instructions

//Esercizio:

//Si vuole progettare un sistema per la gestione di una biblioteca. Gli utenti si possono registrare al sistema, fornendo:

//cognome,
//nome,
//email,
//password,
//recapito telefonico,

//Gli utenti registrati possono effettuare dei prestiti sui documenti che sono di vario tipo (libri, DVD). I documenti sono caratterizzati da:

//un codice identificativo di tipo stringa (ISBN per i libri, numero seriale per i DVD),
//titolo,
//anno,
//settore(storia, matematica, economia, …),
//stato(In Prestito, Disponibile),
//uno scaffale in cui è posizionato,
//un autore (Nome, Cognome).

//Per i libri si ha in aggiunta il numero di pagine, mentre per i dvd la durata.
//L’utente deve poter eseguire delle ricerche per codice o per titolo e, eventualmente, effettuare dei prestiti registrando il periodo (Dal/Al) del prestito e il documento.
//Deve essere possibile effettuare la ricerca dei prestiti dato nome e cognome di un utente.


// Crea lite 
#endregion Instructions

#region User

// Chiedo all'utente se é registrato o no. Alla risposta verra inviato al form di registrazione o di login
void AreYouRegistered()
{
Console.WriteLine("Sei registrato? (si/no)");
string userAnswer = Console.ReadLine();

Console.WriteLine(CheckUser(userAnswer));
}

AreYouRegistered();

List<User> users = new List<User>
{

    new User("Francesco", "Arrighi", "france.arri@gmail,com", "FranceArrighi", 123265497),
    new User("Lorenzo", "Franceschini", "lore.france@gmail,com", "FranceArrighi", 123654987),
    new User("Agostino", "Pique", "ago.pique@gmail.com", "AgoPike", 1232654987)

};

List<Book> books = new List<Book>
{

    new Book("12364558859965555", "Il Signore dei Fardelli", 1952, "fantasy", false, "AR356", "J. R. R. Tolkien", 256),
    new Book("12364558859964255", "La Compagnia del Fardello", 1955, "fantasy", false, "AR356", "J. R. R. Tolkien", 223),
    new Book("12364558859961234", "Il diario di Anna Frank", 1948, "biografia", false, "BF456", "Anna Frank", 189),
    new Book("12364558859969856", "The call of Cthulu", 1952, "horror", false, "FK4556", "Howard Phillips Lovecraft", 452),
    new Book("12364558812345676", "Frankenstein", 1850, "drammatico", false, "ND458", "Mary Shelly", 184),
    new Book("12364558859969856", "Il Piacere", 1889, "romanzo", false, "FK4556", "Gabriele D'Annunzio", 136)

};
string CheckUser(string userAnswer)
{

if (userAnswer == "si")
{
// L'utente dice di essere registrato e pu§o andare alla pagina di login
Console.WriteLine("Insersci il tuo nome: ");
string userName1 = Console.ReadLine();
Console.WriteLine("Inserisci il cognome");
string userSurname1 = Console.ReadLine();

// Effettuo la ricerca tra gli utenti registrati
foreach (User user in users)
{
if (user.Name == userName1 && user.Surname == userSurname1)
{
// Se registrato passa avanti 
return "Accesso effettuato";

}
else
{
// Se non é presente in DB chiediamo nuovamente se é registrato 

AreYouRegistered();
return "Non sei presente nel sistema";
}
}
}

Console.WriteLine("Inserisci il tuo nome");
string userName = Console.ReadLine();

Console.WriteLine("Inserisci il cognome");
string userSurname = Console.ReadLine();

Console.WriteLine("Inserisci il tuo indirizzo email");
string userEmail = Console.ReadLine();

Console.WriteLine("Inserisci il tuo numero di telefono");
int userNumber = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Inserisci la tua passsword");
string userPassword = Console.ReadLine();


users.Add(new User(userName, userSurname, userEmail, userPassword, userNumber));
return "Registrazione effettuata con successo";

}



public class User
{
    public string Name { get; set; }
    public string Surname { set; get; }
    public string Email { set; get; }
    public string Password { set; get; }
    public int PhoneNumber { set; get; }

    // Constructor
    public User(string name, string surname, string email, string password, int phoneNumber)
    {
        this.Name = name;
        this.Surname = surname;
        this.Email = email;
        this.Password = password;
        this.PhoneNumber = phoneNumber;
    }

}

#endregion User

#region Book
public class Book : Document
{
    public int TotalPages { set; get; }

    public Book(string code, string title, int year, string section, bool loaned, string shelf, string author, int totalPages) : base(code, title, year, section, loaned, shelf, author)
    {
        this.TotalPages = totalPages;
    }

}

#endregion Book

#region DVD

public class Dvd : Document
{
    public int Duration { set; get; }

    public Dvd(string code, string title, int year, string section, bool loaned, string shelf, string author, int duration) : base(code, title, year, section, loaned, shelf, author)
    {
        this.Duration = duration;
    }

}

#endregion DVD

#region Document

public class Document
{
    public string Code { set; get; }
    public string Title { get; set; }
    public int Year { get; set; }
    public string Section { get; set; }
    public bool Loaned { get; set; }
    public string Shelf { get; set; }
    public string Author { get; set; }

    public Document(string code, string title, int year, string section, bool loaned, string shelf, string author)
    {
        this.Code = code;
        this.Title = title;
        this.Year = year;
        this.Section = section;
        this.Loaned = loaned;
        this.Shelf = shelf;
        this.Author = author;
    }
}

#endregion Document