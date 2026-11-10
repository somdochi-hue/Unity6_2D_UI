using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public enum CharacterTypes
{
    CHAR_1_NAME,
    CHAR_2_NAME,
    CHAR_3_NAME,
    CHAR_4_NAME,
}

public class CharacterData
{
    public string Id { get; set; }
    public CharacterTypes Type { get; set; }
    public string Label { get; set; }
    public string Name { get; set; }
    public int Hp { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public int Speed { get; set; }
    public string Icon { get; set; }

    public string StringName => DataTableManager.StringTable.Get(Name);
    public Sprite SpriteIcon => Resources.Load<Sprite>($"Icon/{Icon}");

}


