using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
  public void SceneLoad()
  {
        SceneManager.LoadScene(1);
        print(1);
  }
  public void QuitAPP()
  {
        Application.Quit();
        print("2");
  }  
  
}
