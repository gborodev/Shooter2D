public interface IStatInfo
{
    string StatName { get; }
    StatType StatType { get; }
    string StatInfo { get; }
    string Description { get; }
}
