namespace Domain.Entities
{
    public class Book
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TotalCopies { get; set; }
        public int CopiesInUse { get; set; }
        public string Type { get; set; }
        public string ISBN { get; set; }
        public string Category { get; set; }
        public string AvailableCopies => $"{TotalCopies - CopiesInUse}/{TotalCopies}";
        public string Authors => $"{LastName}, {FirstName}";
    }
}
