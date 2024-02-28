namespace Application.UseCases.ListBooksUseCase.Models
{
    public class ListBooksInput
    {
        public string Term { get; set; }
        public Operation Operation { get; set; }
        public int Items { get; set; }
        public int Page { get; set; }
    }
}
