namespace RevitCommandLine.UI.CommandLine.Models
{
    public enum AutoCompleteFilterMode
    {
        None = 0,
        StartsWith = 1,
        StartsWithCaseSensitive = 2,
        StartsWithOrdinal = 3,
        StartsWithOrdinalCaseSensitive = 4,
        Contains = 5,
        ContainsCaseSensitive = 6,
        ContainsOrdinal = 7,
        ContainsOrdinalCaseSensitive = 8,
        Equals = 9,
        EqualsCaseSensitive = 10,
        EqualsOrdinal = 11,
        EqualsOrdinalCaseSensitive = 12,
        Custom = 13,
    }
}
