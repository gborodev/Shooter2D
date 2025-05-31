public class StatRangedDamage : Stat
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
        return "Ranged Damage";
    }

    public override StatType GetStatType()
    {
        return StatType.RangedDamage;
    }

    protected override void StatModified(int modifiedValue)
    {

    }
}
