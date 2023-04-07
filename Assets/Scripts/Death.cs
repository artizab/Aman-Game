using UnityEngine;

public class Death : MonoBehaviour
{
    public Lives livesScr;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Planets"))
        {
            Destroy(collision.gameObject);
            livesScr.TakeDamage();
        }
        else if (collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
        }
    }
}

