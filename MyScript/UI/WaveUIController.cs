using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveUIController : MonoBehaviour
{
    Animator ani;
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetWave(int wave)
    {
        
        StartCoroutine(AnimationDelay(3f,wave));
    }
    IEnumerator AnimationDelay(float time,int wave)
    {
        ani = GetComponent<Animator>();
        text = GetComponent<TextMeshProUGUI>();
        if (text) text.SetText("WAVE " + (wave + 1).ToString());
        ani.SetBool("IsDisable", false);
        yield return new WaitForSeconds(time);
        ani.SetBool("IsDisable", true);
    }
}
