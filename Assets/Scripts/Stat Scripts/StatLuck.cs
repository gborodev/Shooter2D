public class StatLuck : Stat
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
        return "Luck";
    }

    public override StatType GetStatType()
    {
        return StatType.Luck;
    }

    protected override void StatModified(int modifiedValue)
    {

    }
}
