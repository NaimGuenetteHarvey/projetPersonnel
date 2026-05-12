namespace serveur.Models
{
    public class Investissement
    {
        public int id { get; set; }
        public string Nom { get; set; }             
        public string Categorie { get; set; }       
        public double MontantInvesti { get; set; }  
        public double ValeurActuelle { get; set; }   
        public DateTime Date { get; set; }
    }
}
