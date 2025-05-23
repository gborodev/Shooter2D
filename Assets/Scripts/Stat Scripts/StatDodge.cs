public class StatDodge : Stat
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
        return "Dodge";
    }

    public override StatType GetStatType()
    {
        return StatType.Dodge;
    }

    protected override void StatModified(int modifiedValue)
    {
        throw new System.NotImplementedException();
    }
}
