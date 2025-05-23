using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stat : MonoBehaviour, IStatInfo
{
    public event Action OnStatChanged;

    [Header("Base Values")]
    [SerializeField] private StatBase _statBase;

    private List<StatModifier> _modifiers = new List<StatModifier>();

    public string StatName => GetStatName();
    public StatType StatType => GetStatType();
    public string StatInfo => GetStatInfo();
    public string Description => GetDescription();

    public int StatBaseValue => _statBase.BaseValue;
    public float StatBaseMultiplier => _statBase.BaseMultiplier;

    protected virtual void Awake() { }
    protected virtual void Start() { }

    private void OnValidate()
    {
        gameObject.name = $"Stat {StatName}";
    }

    public virtual void AddModifier(StatModifier modifier)
    {
        _modifiers.Add(modifier);

        StatModified(CalculateValue());

        OnStatChanged?.Invoke();
    }
    public virtual void RemoveModifier(StatModifier modifier)
    {
        _modifiers.Remove(modifier);

        StatModified(CalculateValue());

        OnStatChanged?.Invoke();
    }

    private int CalculateValue()
    {
        int value = _statBase.BaseValue;
        float multiplier = _statBase.BaseMultiplier;

        for (int i = 0; i < _modifiers.Count; i++)
        {
            if (_modifiers[i].ModifierType is ModifierType.Flat)
            {
                value += (int)_modifiers[i].ModifierValue;
            }
            else if (_modifiers[i].ModifierType is ModifierType.Multiplier)
            {
                multiplier += _modifiers[i].ModifierValue;
            }
        }

        float finalValue = value * (1 + multiplier);
        return Mathf.RoundToInt(finalValue);
    }

    protected abstract void StatModified(int modifiedValue);
    public abstract string GetStatName();
    public abstract StatType GetStatType();
    public abstract string GetStatInfo();
    public abstract string GetDescription();
}

[Serializable]
public class StatBase
{
    [SerializeField] private int _baseValue = 0;
    [SerializeField] private float _baseMultiplier = 1.0f;

    public int BaseValue => _baseValue;
    public float BaseMultiplier => _baseMultiplier;
}

public class StatModifier
{
    [SerializeField] private ModifierType _modifierType;
    [SerializeField] private float _modifierValue;

    public ModifierType ModifierType => _modifierType;
    public float ModifierValue => _modifierValue;

    public StatModifier(ModifierType modifierType, float modifierValue)
    {
        _modifierType = modifierType;
        _modifierValue = modifierValue;
    }
}

public enum StatType
{
    //Characteristic Elements
    Health,
    Regenerate,
    Toughness,
    Dodge,
    Swiftness,
    Luck,
    GlobalDamage,
    CritChance,
    AttackRate,

    //Ranged Weapon Elements
    RangedDamage,
    Pierce,

    //Melee Weapon Elements
    MeleeDamage,
    BleedChance,
}

public enum ModifierType
{
    Flat,
    Multiplier,
}
