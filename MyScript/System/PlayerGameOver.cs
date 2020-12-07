using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerGameOver : MonoBehaviour
{
    public GameManger game_manager;
    private void OnDestroy()
    {
        // StartCoroutine(GameOver(1f));
        if(game_manager) game_manager.GameOver();
    }
    
}
