using UnityEngine;
using System.Runtime.InteropServices;

public class Lives : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();
    public AudioController _audioScr;

    [SerializeField] private GameObject[] _lives;
    [SerializeField] private int _health = 3;
    [SerializeField] public GameObject _gameOverScreen;
    [SerializeField] private GameObject _itemSpawner;   
    
    public void TakeDamage()
    {
        _health--;
        switch (_health)
        {
            case 2:
                Destroy(_lives[2]);
                break;
            case 1:
                Destroy(_lives[1]);
                break;
            case 0:
                Destroy(_lives[0]);
                _gameOverScreen.SetActive(true);
                Destroy(_itemSpawner);
                ShowAdv();
                //_audioScr.MusicOff();
                break;
        }
    }
}

   




    






