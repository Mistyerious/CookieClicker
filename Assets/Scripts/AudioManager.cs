using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    private AudioSource Source;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        if(instance == this) return;
        Destroy(gameObject);
    }

    private void Start()
    {
        Source = GetComponent<AudioSource>();
        Source.Play();
    }
}
