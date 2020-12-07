using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public BlackSceneController blackscene;
    public void RetryButton()
    {
        StartCoroutine(StartTrans(1f));
    }
    IEnumerator StartTrans(float time)
    {
        blackscene.FadeBlack();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(1);

    }
}
