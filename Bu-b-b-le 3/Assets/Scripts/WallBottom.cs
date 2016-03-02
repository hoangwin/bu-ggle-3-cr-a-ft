using UnityEngine;
using System.Collections;

public class WallBottom : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D orther)
    {
       // Debug.Log("here");
        if (orther.gameObject.tag.Contains("Bubble"))//&& GamePlay.currentState == GamePlay.STATE_PLAY
        {
            if (orther.gameObject.GetComponent<Bubble>().state == Bubble.STATE_BUBBLE_DROP)
            {
                orther.gameObject.GetComponent<Bubble>().destroyAnim();
                Debug.Log("here");
            }
        }
    }
}
