using UnityEngine;

public class Vida : MonoBehaviour
{

    [Header("Vida")]
    [SerializeField] public int vida;
    [SerializeField] public int vidaMaxima;
    private Rigidbody2D rb;

    void Start()
    {
        vida = vidaMaxima;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void setVida(int quantidade)
    {
        vida -= quantidade;

        rb.AddForce(new Vector2(500, 0));

        if(vida > vidaMaxima)
        {
            vida = vidaMaxima;
        }

        else if(vida <= 0)
        {
            Morte();
        }
    }

    public void Morte()
    {
        Destroy(gameObject);
    }
}
