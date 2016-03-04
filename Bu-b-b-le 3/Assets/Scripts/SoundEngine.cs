using UnityEngine;
using System.Collections;

public class SoundEngine : MonoBehaviour
{
    
    public static bool isSoundSFX = true;  
    // Use this for initialization
   
    //music
    
    public AudioSource m_audioSource1;
    public AudioSource m_audioSource2;
    //sfx

    public AudioClip m_click;
    
    public AudioClip m_win;
    public AudioClip m_match;
    public AudioClip m_stick;
    public AudioClip m_lose;
    public AudioClip m_shoot;
    public AudioClip m_destroyBubble;
    public AudioClip m_move;

    
    public static SoundEngine instance;
    float m_timePlaysound1;
    void Start()
    {

        instance = this;
        SoundEngine.instance.m_audioSource1.enabled = isSoundSFX;
        SoundEngine.instance.m_audioSource2.enabled = isSoundSFX;
    }
    
    
    public static void playBubbleEffect(AudioClip clip)
    {
        if (clip == instance.m_destroyBubble)
        {
            if (Time.time - instance.m_timePlaysound1 > 0.1f)
            {
                instance.m_audioSource1.PlayOneShot(clip);
                instance.m_timePlaysound1 = Time.time;
            }
        }
        else
        {
            instance.m_audioSource1.PlayOneShot(clip);
        }

    }
    public static void playCommondEffect(AudioClip clip)
    {
        instance.m_audioSource2.PlayOneShot(clip);
    }
    public static void stop()
    {
        instance.m_audioSource1.Stop();
        instance.m_audioSource2.Stop();
    }
   
    // Update is called once per frame
    void Update()
    {

    }
}
