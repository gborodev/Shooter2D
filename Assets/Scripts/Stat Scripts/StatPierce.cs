public class StatPierce : Stat
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
        return "Pierce";
    }

    public override StatType GetStatType()
    {
        return StatType.Pierce;
    }

    protected override void StatModified(int modifiedValue)
    {
        throw new System.NotImplementedException();
    }
}
