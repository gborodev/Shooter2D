public class StatBleedChance : Stat
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
        return "Bleed Chance";
    }

    public override StatType GetStatType()
    {
        return StatType.BleedChance;
    }

    protected override void StatModified(int modifiedValue)
    {

    }
}
