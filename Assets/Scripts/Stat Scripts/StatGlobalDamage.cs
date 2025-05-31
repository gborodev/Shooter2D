public class StatGlobalDamage : Stat
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
        return "Global Damage";
    }

    public override StatType GetStatType()
    {
        return StatType.GlobalDamage;
    }

    protected override void StatModified(int modifiedValue)
    {

    }
}
