using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Morcego : MonoBehaviour
{
   
    [SerializeField] float velocidade;
    [SerializeField] private Transform patrulha1;
    [SerializeField] private Transform patrulha2;
    
    
    [SerializeField] private GameObject area;
    private TriggerArea colliderArea;


    private bool isPerseguindo = false;
    private GameObject player;


    bool ponto1 = false;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        colliderArea = area.GetComponent<TriggerArea>();
    }

    
    void Update()
    {
        if(colliderArea.naArea)
        {
            isPerseguindo = true;
        }
        else if(!colliderArea.naArea)
        {
            isPerseguindo = false;
        }

        if(isPerseguindo)
        {
            Perseguir();  
        }
        else
        {
            Patrulha();
        }
    }

    void Patrulha()
    {

        if(!ponto1)
        {
            Debug.Log("indo pro ponto 1");
            transform.position = Vector2.MoveTowards(transform.position, patrulha1.position, velocidade * Time.deltaTime);

            if(transform.position == patrulha1.position)
            {
                Debug.Log("chegou no ponto 1");
                ponto1 = true;
                return;
            }
        }

        if(ponto1)
        {
            Debug.Log("indo pro ponto 2");
            transform.position = Vector2.MoveTowards(transform.position, patrulha2.position, velocidade * Time.deltaTime);

            if(transform.position == patrulha2.position)
            {
                Debug.Log("chegou no ponto 2");
                ponto1 = false;
                return;
            }
        }
    }


    void Perseguir()
    {
        Debug.Log("perseguindo");
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, velocidade * Time.deltaTime);
    }

    
}

