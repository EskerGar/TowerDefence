using System.Collections;
using System.Collections.Generic;
using Enemies;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class Restart : MonoBehaviour
{
    [Inject] private TimeController time;
    public void RestartGame()
    {
        time.PauseOff();
        SceneManager.LoadScene("GameScene");
        
    }
}
