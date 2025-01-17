namespace LibraryPOO_Project;

public class ebook:resource
{
    private string title, author, genre, link;
    private int id;
    private DateTime publishingDate;
    private int availableStock;

    public string Link
    {
        get => link;
        set => link = value;
    }
    
    public ebook(int id, string title, string author, string genre, DateTime publishingDate,
        int availableStock, string link) : base("ebook", id, title, author, genre, publishingDate, availableStock)
    {
        this.link = link;
    }
}