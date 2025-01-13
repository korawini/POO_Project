namespace LibraryPOO_Project;

public class ebook:resource
{
    private string id, title, author, type, genre, link;
    private DateTime publishingDate;
    private int availableStock;

    public string Link
    {
        get => link;
        set => link = value;
    }
    
    public ebook(int id, string title, string author, string type, string genre, DateTime publishingDate,
        int availableStock, string link) : base(id, title, author, type, genre, publishingDate, availableStock)
    {
        this.link = link;
    }
}