using UnityEngine;
using UnityEngine.SceneManagement;

public class CallingMenu : MonoBehaviour
{ 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync("MenuScene");
        }
    }
}
