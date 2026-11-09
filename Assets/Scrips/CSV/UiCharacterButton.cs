using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiCharacterButton : MonoBehaviour
{
    public Image icon;
    public TMP_Text textName;
    public Button button;
    private CharacterData data;

    public void SetEmpty()
    {
        data = null;
        icon.sprite = null;
        textName.text = string.Empty;
    }

    public void SetCharacter(string CharacterId)
    {
        SetCharacter(DataTableManager.CharacterTable.Get(CharacterId));
    }

    public void SetCharacter(CharacterData data)
    {
        if(data == null)
        {
            SetEmpty();
            return;
        }
        this.data = data;
        icon.sprite = data.SpriteIcon;
        textName.text = data.StringName;
    }
}
