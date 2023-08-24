using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    GameObject WinImage, LoseImage;

    public void WinImageMethod()
    {
        WinImage.SetActive(true);
    }
    public void LoseImageMethod()
    {
        LoseImage.SetActive(true);
    }
    public void Continue()
    {
        int nowLevel = PlayerPrefs.GetInt("lvl");
        nowLevel++;
        PlayerPrefs.SetInt("lvl", nowLevel);
        SceneeLoad(1);
    }
    public void SceneeLoad(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
    
}
