using UnityEngine;

public class SlowDownSFX : MonoBehaviour
{
    public AudioSource sfxaudioSource;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sfxaudioSource.pitch = 0.5f;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            sfxaudioSource.pitch = 2f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || (Input.GetKeyUp(KeyCode.LeftControl)))
        {
            sfxaudioSource.pitch = 1f;
        }
    }
}
