namespace Models
{
    public enum StatutCompte
    {
        Actif = 1,
        Bloque = 2,
        Ferme = 3
    }

    public enum TypeCompte
    {
        Epargne = 1,
        Courant = 2
    }

    public class Compte
    {
        public int Id { get; set; }

        public string Numero { get; set; }

        public string Titulaire { get; set; }

        public TypeCompte Type { get; set; }

        public decimal Solde { get; set; }

        public DateTime DateCreation { get; set; }

        public StatutCompte Statut { get; set; }

        public DateTime? DateDeblocage { get; set; }

        public List<Transaction> Transactions { get; set; } = new();
    }

}