using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiCharacterInfo : MonoBehaviour
{
    public TMP_Text textLabel;
    public TMP_Text textName;
    public Image icon;
    public TMP_Text texHp;
    public TMP_Text texAtk;
    public TMP_Text texDef;
    public TMP_Text texSpeed;

    private CharacterData data;

    public void SetEmpty()
    {
        data = null;
        textName.text = string.Empty;
        icon.sprite = null;
        texHp.text = string.Empty;
        texAtk.text = string.Empty;
        texDef.text = string.Empty;
        texSpeed.text = string.Empty;
    }
    public void SetCharacter(string id)
    {
        SetCharacter(DataTableManager.CharacterTable.Get(id));
    }

    public void SetCharacter(CharacterData data)
    {
        if (data == null)
        {
            SetEmpty();
            return;
        }
        this.data = data;
        textLabel.text = data.Label.ToString();
        texHp.text = data.Hp.ToString();
        textName.text = data.StringName;
        icon.sprite = data.SpriteIcon;
        texHp.text = data.Hp.ToString();
        texAtk.text = data.Atk.ToString();
        texDef.text = data.Def.ToString();
        texSpeed.text = data.Speed.ToString();
    }
}
