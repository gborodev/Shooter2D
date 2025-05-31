public class StatMeleeDamage : Stat
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
        return "Melee Damage";
    }

    public override StatType GetStatType()
    {
        return StatType.MeleeDamage;
    }

    protected override void StatModified(int modifiedValue)
    {

    }
}
