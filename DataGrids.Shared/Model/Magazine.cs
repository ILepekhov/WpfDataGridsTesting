namespace DataGrids.Shared.Model;

public sealed record Magazine
{
    public Guid Id { get; }
    public char Column { get; }
    public int Row { get; }
    public IReadOnlyCollection<MagazineSlot> Slots { get; }

    public Magazine(char column, int row)
    {
        Id = Guid.NewGuid();
        Column = column;
        Row = row;
        Slots = CreateSlots(this).ToArray();
    }

    public override string ToString()
    {
        return $"{Column}{Row}";
    }

    private static IEnumerable<MagazineSlot> CreateSlots(Magazine magazine)
    {
        for (var i = 0; i < 10; i++)
        {
            yield return new MagazineSlot(magazine, i);
        }
    }
}
