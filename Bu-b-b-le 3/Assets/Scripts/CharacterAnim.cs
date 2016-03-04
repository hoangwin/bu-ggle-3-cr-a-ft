using UnityEngine;
using System.Collections;

public class CharacterAnim : MonoBehaviour {
    public Animator anim;    
    Transform m_transform;
    Vector3 m_PosBegin;
    public float m_LimitX;
    // Use this for initialization
    void Start () {

        m_transform = this.gameObject.transform;
        m_PosBegin = this.gameObject.transform.localPosition;
        initMove();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    public void initMove()
    {
        
       if(this.gameObject.transform.position.x>0)       
        {
            this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, m_PosBegin.y, this.gameObject.transform.localPosition.z);
            Quaternion turnRotation = Quaternion.Euler(0f, -90, 0);         
            anim.gameObject.transform.rotation = turnRotation;
            anim.Play("MyWalkLeft");//
            iTween.MoveTo(this.gameObject, iTween.Hash("x", -m_LimitX, "time", Random.Range(8, 10), "easeType", "linear", "islocal", true, "oncomplete", "initMove"));
        }
        else//right
        {
            this.gameObject.transform.localPosition = new Vector3(this.gameObject.transform.localPosition.x, m_PosBegin.y, this.gameObject.transform.localPosition.z);
            Quaternion turnRotation = Quaternion.Euler(0f, 90, 0);            
            anim.gameObject.transform.rotation = turnRotation;
            anim.Play("MyWalKRight");            
            iTween.MoveTo(this.gameObject, iTween.Hash("x", m_LimitX, "time", Random.Range(8, 10), "easeType", "linear", "islocal", true, "oncomplete", "initMove"));
        }
    }
}
