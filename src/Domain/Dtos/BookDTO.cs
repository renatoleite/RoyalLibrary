namespace Domain.Dtos
{
    public class BookDTO
    {
        public BookDTO(string title, string authors, string type, string iSBN, string category, string availableCopies)
        {
            Title = title;
            Authors = authors;
            Type = type;
            ISBN = iSBN;
            Category = category;
            AvailableCopies = availableCopies;
        }

        public string Title { get; set; }
        public string Authors { get; set; }
        public string Type { get; set; }
        public string ISBN { get; set; }
        public string Category { get; set; }
        public string AvailableCopies { get; set; }
    }
}
