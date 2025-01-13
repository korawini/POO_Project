namespace LibraryPOO_Project;

public class magazine:resource
{
    private string id, title, author, type, genre, link, edition;
    private DateTime publishingDate;
    private int availableStock, number;

    public string Edition
    {
        get => edition;
        set => edition = value;
    }

    public int Number
    {
        get => number;
        set => number = value;
    }
    
    public magazine(int id, string title, string author, string type, string genre, DateTime publishingDate,
        int availableStock, string edition, int number) : base(id, title, author, type, genre, publishingDate, availableStock)
    {
        this.edition = edition;
        this.number = number;
    }
}