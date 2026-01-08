using UnityEngine;

public class Vida : MonoBehaviour
{

    [Header("Vida")]
    [SerializeField] public int vida;
    [SerializeField] public int vidaMaxima;

    void Start()
    {
        vida = vidaMaxima;
    }

    public void setVida(int quantidade)
    {
        vida += quantidade;

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
