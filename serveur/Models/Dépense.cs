namespace serveur.Models
{
    public class Dépense
    {
      
            public int Id { get; set; }
            public string Nom { get; set; }        
            public double Montant { get; set; }
            public DateTime Date { get; set; }
            public string Categorie { get; set; }   
        }
    
}
