using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class GameMechanics : MonoBehaviour
{   

    [DllImport("__Internal")]
    private static extern void AdvRestartExtern();

    public Score _scoreScr;    
   
    public void RestartGame()
    {
        _scoreScr.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        Time.timeScale = 1;
    }

    public void OnAdvButton()
    {
        AdvRestartExtern();
    }

    public void OnAdReward()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);        
        Time.timeScale = 0;
    }

    public void StartTime()
    {
        Time.timeScale = 1;
    }
}


    

