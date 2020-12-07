using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public BlackSceneController blackscene;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartButton();
        }
    }
    public void StartButton()
    {
        StartCoroutine(StartTrans(1f));
    }
    IEnumerator StartTrans(float time)
    {
        blackscene.FadeBlack();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
