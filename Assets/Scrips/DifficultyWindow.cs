using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyWindow : GenericWindow
{
    public enum Difficulty
    {
        None = -1,
        Easy,
        Normal,
        Hard,
    }
    public Toggle[] toggles;
    private const string DIFFICULTY_KEY = "SelectedDifficulty";

    public override void Open()
    {
        CurrentDifficulty = (Difficulty)PlayerPrefs.GetInt("Difficulty", 1);
        
        base.Open();
    }

    public override void Close()
    {
        PlayerPrefs.SetInt("Difficulty",(int)CurrentDifficulty);
        base.Close();
    }
    public void OnClickEasy(bool volue)
    {
        Debug.Log($"OnClickEasy: {volue}");
    }

    public void OnClickNormal(bool volue)
    {
        Debug.Log($"OnClickNormal: {volue}");
    }

    public void OnClickHard(bool volue)
    {
        Debug.Log($"OnClickHard: {volue}");
    }

    public Difficulty CurrentDifficulty
    {
        get
        {
            for (int i = 0; i < toggles.Length; ++i)
            {
                if(toggles[i].isOn)
                {
                    return(Difficulty)i;
                }
            }
            return Difficulty.None;
        }
        set
        {
            toggles[(int)value].isOn = true;           
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.SetInt("Difficulty", (int)CurrentDifficulty);
            // PlayerPrefs은 열거형 저장이 안됨, 열거형 int 변환은 위 부터 0으로 시작함.
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int index = (int)CurrentDifficulty;
            index = (int)Mathf.Repeat(index-1, toggles.Length);
            CurrentDifficulty = (Difficulty)index;
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            CurrentDifficulty = Difficulty.Normal;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CurrentDifficulty = Difficulty.Hard;
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            manager.Open(Windows.Start);
        }
    }
}
