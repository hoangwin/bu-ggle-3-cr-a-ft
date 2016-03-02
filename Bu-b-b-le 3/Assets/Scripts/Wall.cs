using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D orther)
    {
     
       if (orther.gameObject.tag.Contains("Bubble") && GamePlay.currentState == GamePlay.STATE_PLAY)
       {
            if (orther.gameObject.GetComponent<Bubble>().state == Bubble.STATE_BUBBLE_IDE)
            {
                Debug.Log("Tao day ne");
                GamePlay.TimePlayedSubState = 1f;
                GamePlay.isWin = false;
                GamePlay.changeState(GamePlay.STATE_WAITING_WIN_LOSE);
                SoundEngine.playSound("game_over");
            }
		
		}
    }
}
