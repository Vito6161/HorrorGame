using Unity.VisualScripting;
using UnityEngine;

public class Projetil : MonoBehaviour
{
    [SerializeField] int dano;
    [SerializeField] private LayerMask layerInimigos;


    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("detectando colisão projetil");

        GameObject inimigo = other.gameObject;
        if(inimigo.layer == 7)
        {
            Debug.Log("aaaaaaaaaaaaaaa");
            Vida vidaInimigo = inimigo.GetComponent<Vida>();

            vidaInimigo.setVida(dano);
        }
        
            Destroy(gameObject);
    
        
    }
}
