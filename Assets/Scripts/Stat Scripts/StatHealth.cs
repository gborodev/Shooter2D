public class StatHealth : Stat
{
    public int CurrentHealth { get; private set; }
    public int MaxHealth { get; private set; }

    protected override void Start()
    {
        base.Start();
    }

    protected override void StatModified(int modifiedValue)
    {

    }

    public override string GetDescription()
    {
        return "";
    }

    public override string GetStatInfo()
    {
        return "";
    }

    public override string GetStatName()
    {
        return "Health";
    }

    public override StatType GetStatType()
    {
        return StatType.Health;
    }
}
