using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;
    public static AudioManager instance;
    public AudioMixerGroup soundEffectMixer;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance d'Audio manager dans la scène !");
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        PlayMusic();
    }

    public void StopMusic()
    {
        audioSource.Stop();

    }

    public void PlayMusic()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            //PlayNextSong();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            audioSource.pitch = 0.5f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || (Input.GetKeyUp(KeyCode.LeftControl)))
        {
            audioSource.pitch = 1f;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            audioSource.pitch = 2f;
        }

      
    }

    private void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;
        AudioSource sfxaudioSource = tempGO.AddComponent<AudioSource>();
        
        sfxaudioSource.clip = clip;
        sfxaudioSource.outputAudioMixerGroup = soundEffectMixer;
        sfxaudioSource.Play();


        SlowDownSFX sdsfx = tempGO.AddComponent<SlowDownSFX>();
        sdsfx.sfxaudioSource = sfxaudioSource;
          
      
        Destroy(tempGO,clip.length);
       
        return sfxaudioSource;
    }
}
