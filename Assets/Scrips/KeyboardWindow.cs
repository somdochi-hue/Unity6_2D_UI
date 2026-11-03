using NUnit.Framework;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardWindow : GenericWindow
{
    public int maxCharacters = 7;
    public TMP_Text inputField;
    public GameObject rootKeyboard;
    private Button[] keys;
    private string inputText = string.Empty;
    private string inputTextWithCursor = "";
    private bool isCursoVisible;
    private float blinkTimer;
    private float blinkInterval = 0.5f;

    protected override void Awake()
    {
        base.Awake();
        keys = rootKeyboard.GetComponentsInChildren<Button>();
        foreach (Button button in keys)
        {
            TMP_Text text = button.GetComponentInChildren<TMP_Text>();
            string key = text.text;
            button.onClick.AddListener(() => Onkey(key));
        }
    }

    public override void Open()
    {
        blinkTimer = 0f;
        isCursoVisible = true;
        SetText(string.Empty);
        base.Open();
    }

    private void Update()
    {
        blinkTimer += Time.deltaTime;
        if (blinkTimer > blinkInterval)
        {
            blinkTimer = 0f;
            isCursoVisible = !isCursoVisible;
            UpdateInputField();
        }
    }

    private void SetText(string text)
    {
        if(text.Length > maxCharacters)
        {
            return;
        }
        inputText = text;
        inputTextWithCursor = inputText.Length < maxCharacters  ? $"{inputText}_" : inputText;
        UpdateInputField();
    }
    
    private void UpdateInputField()
    {
        inputField.text = isCursoVisible ? inputTextWithCursor : inputText;
    }

    public void OnClickCancel()
    {
        SetText(string.Empty);
    }

    public void OnClickDelete()
    {
        if (inputText.Length > 0 )
        {
            SetText(inputText.Substring(0, inputText.Length - 1));
        }
    }

    public void OnClickAccept()
    {
        manager.Open(Windows.Start);
    }

        public void Onkey(string key)
    {
        SetText($"{inputText}{key}");
    }
}
