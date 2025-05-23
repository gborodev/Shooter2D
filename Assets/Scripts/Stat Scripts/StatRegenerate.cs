public class StatRegenerate : Stat
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
        return "Regenerate";
    }

    public override StatType GetStatType()
    {
        return StatType.Regenerate;
    }

    protected override void StatModified(int modifiedValue)
    {
        throw new System.NotImplementedException();
    }
}
