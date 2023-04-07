using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Score scoreScr;
    [SerializeField] private Lives livesScr;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Planets"))
        {
            Destroy(collision.gameObject);
            scoreScr.IncreaseScore();
            scoreScr.IncreaseTopScore();
        }
        else if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
            _animator.SetTrigger("TakeDmg");
            livesScr.TakeDamage();
        }
    }
}

