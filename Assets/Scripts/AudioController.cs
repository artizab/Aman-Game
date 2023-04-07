using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioObj;
    [SerializeField] private GameObject _musicBtn;
    [SerializeField] private Sprite _musicOn;
    [SerializeField] private Sprite _musicOff;

    private void Awake()
    {
        _audioObj.volume = PlayerPrefs.GetFloat("AudioStatus");
    }
        
    private void Update()
    {
        if(_audioObj.volume > 0f)
        {
            _musicBtn.GetComponent<Image>().sprite = _musicOn;
            PlayerPrefs.SetFloat("AudioStatus", _audioObj.volume);
        }
        else
        {
            _musicBtn.GetComponent<Image>().sprite = _musicOff;
            PlayerPrefs.SetFloat("AudioStatus", _audioObj.volume);
        }
    }

    public void OnSwitchMusic()
    {
        if (_audioObj.volume > 0f)
        {
            _audioObj.volume = 0f;
            
        }
        else
        {
            _audioObj.volume = 0.3f;            
        }
    }

    public void MusicOn()
    {
        _audioObj.volume = 0.3f;
    }

    public void MusicOff()
    {
        _audioObj.volume = 0f;
    }
}


