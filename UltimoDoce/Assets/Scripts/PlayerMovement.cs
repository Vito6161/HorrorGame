using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Colisão com o chão")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float tamanhoDetector;
    [SerializeField] private LayerMask layerChão;

    [Header("Valores da movimentação")]
    [SerializeField] private float velocidade;
    [SerializeField] private float pulo;

    private Rigidbody2D rb;
    private float horizontal; 

    public int direção = 1;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(horizontal > 0.1f && direção < 0 || horizontal < -0.1f && direção > 0)
        {
            Virar();
        }
        
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, pulo);
        }
    }

    void Virar()
    {
        direção *= -1;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }


    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, tamanhoDetector, layerChão);
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * velocidade, rb.linearVelocity.y);
    }
}
