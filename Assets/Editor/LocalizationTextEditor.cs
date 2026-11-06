using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LocalizationText))]
public class LocalizationTextEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var text = target as LocalizationText;  // 다운캐스팅

        var newId = EditorGUILayout.TextField("String ID", text.stringId);
        var newLang = (Languages)EditorGUILayout.EnumPopup("Language", text.editorLang);  // 다운캐스팅

        if (newId != text.stringId || newLang != text.editorLang)
        {
            text.stringId = newId;
            text.editorLang = newLang;
            text.OnChangedLanguage(text.editorLang);
            EditorUtility.SetDirty(text);  // 원하는 타이밍에 갱신하기 위해 넣는 함수.
        }
    }
}