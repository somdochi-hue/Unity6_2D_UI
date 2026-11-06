using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using UnityEditor.Localization.Editor;

// #define DEF_EDITOR  // 개발자 운영툴 

[RequireComponent(typeof(TMP_Text))]  // typeof에 할당된 것을 오브제트에서 찾아서 무조건 고정해주는 함수.
[ExecuteInEditMode]  // play 버튼 안 눌러도 활성화 함수.
public class LocalizationText : MonoBehaviour
{
    // private TextMeshProUGUI Text;
    private TMP_Text text;

    public string stringId;

#if UNITY_EDITOR  // 전처리 기능 컴파일에 넣고 뺄 수 있다. !UNITY_EDITOR !느낌표를 넣어주면 뺀다.
    public Languages editorLang;
#endif

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
#if UNITY_EDITOR
        if(!Application.isPlaying)
        {
            OnChangedLanguage(editorLang);
            return;
        }
#endif

        Variables.OnLanguageChanged += OnChangedLanguage;
        OnChangedLanguage();
    }

    private void ODisable()
    {
#if UNITY_EDITOR
        if(!Application.isPlaying)
        {
            return;
        }
#endif
        Variables.OnLanguageChanged -= OnChangedLanguage;
        
    }

    public void OnChangedLanguage()
    {
        text.text = DataTableManager.StringTable.Get(stringId);
    }

#if UNITY_EDITOR
    public void OnChangedLanguage(Languages lang)
    {
        var tableId = DataTableIds.StringTableIDs[(int)lang];
        var stringTable = DataTableManager.Get<StringTable>(tableId);
        text.text = stringTable.Get(stringId);
    }

    [ContextMenu("Apply Editor Lang To All Active")]
    private void ApplyEditorLangToAllActive()
    {
        LocalizationText[] all = FindObjectsByType<LocalizationText>(FindObjectsSortMode.None);  // 소팅 안함.  // 배열을 만들어줌.
        foreach (var textItem in all)
        {
            textItem.editorLang = editorLang;
            textItem.OnChangedLanguage(editorLang);
        }
    }
#endif
}
