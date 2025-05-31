public class StatSwiftness : Stat
{
    public override string GetDescription()
    {
        throw new System.NotImplementedException();
    }

    public override string GetStatInfo()
    {
        throw new System.NotImplementedException();
    }

    public override string GetStatName()
    {
        return "Swiftness";
    }

    public override StatType GetStatType()
    {
        return StatType.Swiftness;
    }

    protected override void StatModified(int modifiedValue)
    {

    }
}
