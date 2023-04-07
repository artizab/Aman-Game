using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public float _speed;
    private float horizontalMove;

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        transform.Translate(horizontalMove, 0, 0);
    }

    public void OnRight()
    {
        horizontalMove = _speed;
    }

    public void OnLeft()
    {
        horizontalMove = -_speed;
    }

    public void Stop()
    {
        horizontalMove = 0;
    }

}











