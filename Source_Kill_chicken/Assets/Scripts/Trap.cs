using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour {
    public bool isPass = false;
    public Animator ani;

    public int state = 0;//0=ide; 1 = open
    public bool isIDERight = true;
    void Start() {
        isPass = false;
        if(isIDERight)
            ani.Play("Trap_RunRight");
        else
            ani.Play("Trap_RunLeft");

    }

    // Update is called once per frame
    void Update()
    {
        if (GamePlay.currentState == GamePlay.STATE_PLAY)
        {
            if ((false))
            {
                if (Input.GetMouseButtonDown(0) || ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Began)))
                {


                    if (state == 0)
                    {
                        ani.Play("Trap_Open");
                        state = 1;
                    }
                    SoundEngine.playSound(SoundEngine.instance.m_SoundTrapMove);
                    //GameObject sound = GameObject.Find("SoundFly");
                    //if (sound != null)
                    //{
                    // Debug.Log("Play Sound");
                    //	sound.audio.Play();
                    //}
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0) || ((Input.touchCount == 1) && (Input.GetTouch(0).phase == TouchPhase.Began)))
                {


                    if (state == 0)
                    {
                        if (isIDERight)
                            ani.Play("Trap_RunLeft");
                        else
                            ani.Play("Trap_RunRight");
                        state = 1;
                        isIDERight = !isIDERight;
                    }
                    SoundEngine.playSound(SoundEngine.instance.m_SoundTrapMove);
                    //GameObject sound = GameObject.Find("SoundFly");
                    //if (sound != null)
                    //{
                    // Debug.Log("Play Sound");
                    //	sound.audio.Play();
                    //}
                }
            }
            
        }
    } 

    public bool checkPass(float xtrap,float xbird)
	{

		if (xtrap < xbird + 0.3f)
			return true;
		return false;
	}
	public void setIDE()
	{
		state = 0;
	}
}
