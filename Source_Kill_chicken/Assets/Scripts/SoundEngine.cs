using UnityEngine;
using System.Collections;

public class SoundEngine : MonoBehaviour {
	public static bool isSound = true;
    public  AudioSource m_AudioSource;
    public  AudioClip m_SoundReady;
    public  AudioClip m_SoundClick;
    public  AudioClip m_SoundColliVehide;
    public  AudioClip m_SoundLose;
    public  AudioClip m_SoundTrapMove;
    public static SoundEngine instance;
    // Use this for initialization             
    void Start () {
        instance = this;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
	public static void playSound(AudioClip clip)
	{
		if (SoundEngine.isSound) {
		
			if (clip != null) {
                // Debug.Log("Play Sound");
                instance.m_AudioSource.clip = clip;
                instance.m_AudioSource.Play ();
			}
		}
	}
}
