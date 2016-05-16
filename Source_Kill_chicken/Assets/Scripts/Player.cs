using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float maxSpeedx = 0.01f;
	public float maxSpeedy = 0.1f;
	private Vector2 movement;
	bool isCallJump = false;
	float currentAngle;
	//GameObject birdObject;
	float mygravityScale = 1f;
    // Use this for initialization
    public Animator anim;
    public bool isLive = true;
    public int myLayer = 11;//de loai bo collition giua cac con chim
	void Start () {

		maxSpeedx = 3*Random.Range(60f,80f)/10;
		maxSpeedy =  6f;
		movement = new Vector2 (maxSpeedx, 0);
		isCallJump = true;	
		DEF.Init ();
		//this.transform.rigidbody2D.AddForce (new Vector2 (0, 200));
		//maxSpeed = 3f;
		//Debug.Log ("maxSpeed :" + maxSpeedy);
		//this.transform.GetComponent<Rigidbody2D>().fixedAngle = true;
		
	}
	
	// Update is called once per frame
	void Update () {

		switch (GamePlay.currentState) {
		case GamePlay.STATE_WATTING:
                GamePlay.currentState = GamePlay.STATE_PLAY;
                //Debug.Log("aaaaaaaaaa");

            break;
		case GamePlay.STATE_PLAY:
            
                if (this.transform.localPosition.y < 0f) {
				movement = new Vector2 (maxSpeedx, maxSpeedy);
				//Debug.Log("MAXSpeed : " + maxSpeedx +"," + maxSpeedy);
				isCallJump = true;
			}
			if ( this.transform.localPosition.x > 33.0)
			{
                    SoundEngine.playSound(SoundEngine.instance.m_SoundLose);
                    //GameObject sound = GameObject.Find("Sound_Lose");
                    //if (sound != null)
                    //{
                    //	Debug.Log("Play sound:hhh");
                    //	sound.audio.Play ();
                    //}

                    GamePlay.currentState = GamePlay.STATE_OVER;
				GamePlay.instance.initGameOver ();
				GamePlay.instance.showGameOver();
				GamePlay.TimePlayedSubState = 0f;
			}
			break;
	
		}
	
	}
	void FixedUpdate()
    {
        if (GamePlay.currentState == GamePlay.STATE_PLAY)
        {
            if (isCallJump)
            {
                GetComponent<Rigidbody>().velocity = movement;
                isCallJump = false;
              
            }
        }
	}
	void OnCollisionEnter(Collision collision)
	{
        if (collision.gameObject.tag.Equals("Ground"))
        {
          //  Debug.Log("aaaaaaaaa");
            return;
        }
	
		//GamePlay.instance.showGameOver ();
	//	Debug.Log ("Tieu tui rui");

		if (transform.localPosition.x < 0.6) {
			movement = new Vector2 (-maxSpeedx, maxSpeedy);
			isCallJump = true;
		}
		else{
            anim.Play ("DIE");
			transform.GetComponent<Rigidbody>().GetComponent<Rigidbody>().velocity = new Vector2 (0, 0);
			transform.GetComponent<Rigidbody>().GetComponent<Rigidbody>().useGravity = false;
            transform.GetComponent<Rigidbody>().GetComponent<Rigidbody>().isKinematic = true;
            transform.localRotation = Quaternion.Euler (new Vector3 (0, 0, 0));
            transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
            Destroy(gameObject, 0.5f);

			BoxCollider [] arraycollider = GetComponents<BoxCollider> ();
			for (int j =0; j<arraycollider.Length; j++)
					arraycollider [j].enabled = false;
			ScoreControl.Score +=1;
            GamePlay.instance.m_TextScoreIngame.text = ScoreControl.Score.ToString();
            //GameObject.Find("LabelScoreInGame").GetComponent<UILabel>().text =""+ ScoreControl.getRealScore();
        }
        SoundEngine.playSound(SoundEngine.instance.m_SoundColliVehide);
        //GameObject sound = GameObject.Find("SoundFail");
        //if (sound != null)
        //{
        // Debug.Log("Play Sound");
        //	sound.audio.Play();
        //}
    }
}
