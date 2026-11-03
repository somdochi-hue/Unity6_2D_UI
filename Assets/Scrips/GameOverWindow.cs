using System.Collections;
using TMPro;
using UnityEngine;

public class GameOverWindow : GenericWindow
{
    public TMP_Text leftStatLabel;
    public TMP_Text rightStatLabel;
    public TMP_Text leftStatValues;
    public TMP_Text rightStatValues;
    public TMP_Text textTotalScore;
    

    private int[] scores = new int[6];   // 작은 점수 6개
    private int totalScore;
    private Coroutine routine;

    public override void Open()
    {
        base.Open();
        if ( routine != null)
        {
            StopCoroutine(routine);
            routine = null;   // StopCoroutine을 쓴다면 무조건 null 만들어주기.
        }
        routine = StartCoroutine(CoResetScore());
    }

    IEnumerator CoResetScore()
    // 멈추는 시간을 넣고 싶다면 Coroutine으로 함수로 만들거나 변경해주기.
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = Random.Range(0 , 10000);
        }
        totalScore = Random.Range(0, 1000000000);

        leftStatLabel.text = string.Empty;
        rightStatLabel.text = string.Empty;
        leftStatValues.text = string.Empty;
        rightStatValues.text = string.Empty;

        for (int i = 0; i < scores.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            TMP_Text label = i < 3 ? leftStatLabel : rightStatLabel;
            TMP_Text value = i < 3 ? leftStatValues : rightStatValues;
            label.text += $"STAT {i + 1}\n";
            value.text += $"{scores[i]:D4}\n";
        }
        
        yield return new WaitForSeconds(0.5f);

        float elapsed = 0f;
        while (elapsed < 2f)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / 2f;
            int value = Mathf.RoundToInt(Mathf.Lerp(0, totalScore, t));
            textTotalScore.text = $"{totalScore:D9}";
            yield return null;
        }
        textTotalScore.text = $"{totalScore:D9}";
    }

    public void OnNext()
    {
        manager.Open(Windows.Start);
    }

}
