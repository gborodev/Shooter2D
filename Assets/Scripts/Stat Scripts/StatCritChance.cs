public class StatCritChance : Stat
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
        return "Crit Chance";
    }

    public override StatType GetStatType()
    {
        return StatType.CritChance;
    }

    protected override void StatModified(int modifiedValue)
    {

    }
}
