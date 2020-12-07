using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackSceneController : MonoBehaviour
{
    Animator ani;
    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    public void FadeBlack()
    {
        if(ani) ani.SetBool("IsFadeBlack", true);
    }
    public void FadeTrans()
    {
        if (ani) ani.SetBool("IsFadeBlack", false);
    }
}
