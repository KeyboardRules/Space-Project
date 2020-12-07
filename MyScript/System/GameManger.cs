using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public BlackSceneController black_scene;
    public WaveUIController waveUI;
    public static bool tran_scene;
    void Start()
    {
        tran_scene = false;
    }
    public void GameOver()
    {
        tran_scene = true;
        StartCoroutine(GameOver(1.5f));
    }
    public void Wave(int wave_index)
    {
        if (waveUI) waveUI.SetWave(wave_index);
    }
    public void EndGame()
    {
        tran_scene = true;
        StartCoroutine(Ending(1.5f));
    }
    IEnumerator GameOver(float time)
    {
        if (black_scene) black_scene.FadeBlack();
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(5);
    }
    IEnumerator Ending(float time)
    {
        if (black_scene) black_scene.FadeBlack();
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(3);

    }
}
