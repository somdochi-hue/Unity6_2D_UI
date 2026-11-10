public enum Languages
{
    Korean,
    English,
    Japanese,
}

public static class DataTableIds
{
    public static readonly string[] StringTableIDs =
    {
        "StringTableKr",
        "StringTableEn",
        "StringTableJp",
    };
    public static string String => StringTableIDs[(int)Variables.Language];
    public static readonly string Item = "ItemTable";
    public static readonly string Character = "CharacterTable";
}

public static class Variables
{
    public static event System.Action OnLanguageChanged;
    private static Languages language = Languages.Korean;

    public static Languages Language
    {
        get => language;
        set
        {
            if(language == value)
            {
                return;
            }

            language = value;
            DataTableManager.ChangedLanguage(language);
            OnLanguageChanged?.Invoke();
        }

    }
}