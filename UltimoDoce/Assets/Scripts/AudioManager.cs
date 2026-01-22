using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource sfx;
    [SerializeField] private AudioSource musicaAV;

    [Header("Audios")]
    [SerializeField] public AudioClip background;
    [SerializeField] public AudioClip adaptativa;
    [SerializeField] public AudioClip stinger1;
    [SerializeField] public AudioClip stinger2;


    public void Start()
    {
        music.clip = background;
        music.Play();
    }

    public void PlayMusica(bool ligar)
    {
        if(ligar)
        {
            Debug.Log("play musica");
            musicaAV.clip = adaptativa;
            musicaAV.Play();
        }
        else
        {
            musicaAV.Stop();
        }
    
    }
    
    public void PlayStinger(AudioClip stinger, bool ligar)
    {
        if(stinger == stinger2)
        {
            sfx.PlayOneShot(stinger2);
        }

        if(ligar && stinger != stinger2)
        {
            Debug.Log("play stinger 1");
            sfx.clip = stinger;
            sfx.Play();
        }
        if(!ligar)
        {
            sfx.Stop();
        }
    }



}
