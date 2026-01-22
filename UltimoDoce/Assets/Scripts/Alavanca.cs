using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class Alavanca : MonoBehaviour
{

    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject block;
    [SerializeField] private Transform spawn;
    [SerializeField] private Transform spawnBlock;
    [SerializeField] private AudioManager manager;

    private Manager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("manager").GetComponent<Manager>();;

    }


    void OnTriggerStay2D(Collider2D other)
    {
       
        if(Input.GetKey(KeyCode.E) && !gameManager.primeiraAlavanca /*&& other.CompareTag("Player")*/)
        {
            
            Instantiate(prefab, spawn.position, spawn.rotation);
            gameManager.primeiraAlavanca = true;

            manager.PlayMusica(true);
            manager.PlayStinger(manager.stinger1, true);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        

        if(gameManager.primeiraAlavanca && !gameManager.segundaAlavanca && other.CompareTag("Player"))
        {
            Instantiate(block, spawnBlock.position, spawnBlock.rotation);

            gameManager.segundaAlavanca = true;

            manager.PlayMusica(false);
            manager.PlayStinger(manager.stinger1, false);
            manager.PlayStinger(manager.stinger2, true);
            
        }
    }
}
