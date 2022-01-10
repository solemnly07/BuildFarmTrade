using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    static AudioController instance;
    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {   
        Instantiate();
        GetAudioSource();
    }

    void Instantiate()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public static AudioController GetInstance()
    {
        return instance;
    }

    void GetAudioSource()
    {
        source = this.gameObject.GetComponent<AudioSource>();
    }

    public void PlayAudio()
    {
        if(source != null)
        {
            source.Play();
        }
    }

    public void PauseAudio()
    {
        if(source != null)
        {
            source.Pause();
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
