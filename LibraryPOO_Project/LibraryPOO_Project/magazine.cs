namespace LibraryPOO_Project;

public class magazine:resource
{
    private string title, author, genre, edition;
    private int id;
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
    
    public int Id
    {
        get => id;
    }
    
    public magazine(int id, string title, string author, string genre, DateTime publishingDate,
        int availableStock, string edition, int number) : base("magazine",id, title, author, genre, publishingDate, availableStock)
    {
        this.edition = edition;
        this.number = number;
    }
}