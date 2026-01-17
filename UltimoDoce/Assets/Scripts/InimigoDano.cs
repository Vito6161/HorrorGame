using UnityEngine;

public class InimigoDano : MonoBehaviour
{

    [SerializeField] int dano;

    private Vida vida;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        vida = player.GetComponent<Vida>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            CausarDano();
        }
    }

    void CausarDano() //função dos inimios
    {
        vida.setVida(dano);
    }


}
