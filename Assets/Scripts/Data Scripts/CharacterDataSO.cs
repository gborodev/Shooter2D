using System.Linq;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "Database/Character Data", fileName = "New Character Data")]
public class CharacterDataSO : ScriptableObject
{
    [Header("Character Info")]
    public string characterName;

    [Header("Character Stats")]
    public StatBase health;
    public StatBase regenerate;
    public StatBase toughness;
    public StatBase dodge;
    public StatBase swiftness;
    public StatBase luck;
    public StatBase globalDamage;
    public StatBase critChance;
    public StatBase attackRate;
    public StatBase rangedDamage;
    public StatBase pierce;
    public StatBase meleeDamage;
    public StatBase bleedChance;

    public string CharacterStatInfo { get; private set; }
    public StatBase GetStatBaseByType(StatType type)
    {
        return type switch
        {
            StatType.Health => health,
            StatType.Regenerate => regenerate,
            StatType.Toughness => toughness,
            StatType.Dodge => dodge,
            StatType.Swiftness => swiftness,
            StatType.Luck => luck,
            StatType.GlobalDamage => globalDamage,
            StatType.CritChance => critChance,
            StatType.AttackRate => attackRate,
            StatType.RangedDamage => rangedDamage,
            StatType.Pierce => pierce,
            StatType.MeleeDamage => meleeDamage,
            StatType.BleedChance => bleedChance,
            _ => null
        };
    }

    public void InitializeCharacterData()
    {
        if (StatManager.instance == null)
        {
            Debug.LogError("StatManager instance is null. Make sure it is initialized before calling InitializeCharacterData.");
            return;
        }

        IStatInfo[] statInfos = StatManager.instance.GetAllStatInfos();

        StringBuilder infoBuilder = new StringBuilder();

        var stats = statInfos
            .Select(info => (
                type: info.StatType,
                baseStat: GetStatBaseByType(info.StatType),
                displayName: info.StatName
            ))
            .Where(tuple => tuple.baseStat != null)
            .ToArray();

        foreach (var (type, baseStat, displayName) in stats)
        {
            if (StatManager.instance.TryGetStat(type, out Stat stat))
            {
                int value = baseStat.BaseValue - stat.StatBaseValue;
                float multiplier = baseStat.BaseMultiplier - stat.StatBaseMultiplier;

                if (value != 0)
                    infoBuilder.AppendLine(GenerateValueText(displayName, value));
                if (multiplier != 0)
                    infoBuilder.AppendLine(GenerateMultiplierText(displayName, multiplier));
            }
        }

        CharacterStatInfo = infoBuilder.ToString();
        if (string.IsNullOrEmpty(CharacterStatInfo))
        {
            CharacterStatInfo = "No stats available.";
        }
    }
    private string GenerateValueText(string statName, int value)
    {
        string valueInfo = value < 0 ? $"{value}" : $"+{value}";
        string colorInfo = value < 0 ? "red" : "green";

        return $"<color={colorInfo}>{valueInfo}</color> {statName}";
    }
    private string GenerateMultiplierText(string statName, float multiplier)
    {
        string modifierInfo = multiplier < 0 ? "decreased" : "increased";
        string colorInfo = multiplier < 0 ? "red" : "green";

        return $"{statName} modifiers {modifierInfo} by <color={colorInfo}>{(int)Mathf.Abs(multiplier * 100)}%</color>";
    }
}
