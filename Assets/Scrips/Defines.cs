public enum Languages
{
    Korean,
    English,
    Japanese,
}

public static class DataTables
{
    public static readonly string[] StringTableIDs =
    {
        "StringTableKr",
        "StringTableEn",
        "StringTableJp",
    };
    public static string String => StringTableIDs[(int)Variables.languages];
}

public static class Variables
{
    public static Languages languages;
}