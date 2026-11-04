using UnityEngine;

public class FilePathExample : MonoBehaviour
{
    void Start()
    {
        Debug.Log($"persistentDataPath: {Application.persistentDataPath}");
        Debug.Log($"dataPath: {Application.dataPath}");
        Debug.Log($"streamingAssetsPath: {Application.streamingAssetsPath}");
    }
}

/*
persistentDataPath: C:/Users/somdochi/AppData/LocalLow/DefaultCompany/Unity6_ 2D_UI
dataPath: C:/Users/somdochi/Unity6_ 2D_UI/Assets
streamingAssetsPath: C:/Users/somdochi/Unity6_ 2D_UI/Assets/StreamingAssets
*/


// 파일 경로 확인.