using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    private bool activeCountDown;
    Transform tr;
    private float m_speed; 

    // Use this for initialization
    void Start ()
    {
        activeCountDown = false;
        tr = GetComponent<Transform>() as Transform;
        StartCoroutine(StartCountdown(5f));
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (activeCountDown)
        {
            Vector3 angle = new Vector3 (0, 0, -1);
            tr.Rotate(angle * m_speed * Time.fixedDeltaTime);
        }
    }

    IEnumerator StartCountdown (float seconds)
    {
        tr.rotation = Quaternion.Euler(0, 0, 90);
        m_speed = 360 / seconds;
        activeCountDown = true;
        yield return new WaitForSeconds(seconds);
        activeCountDown = false;
        
        GameManager.Instance.EventsPhase();
        Destroy(gameObject);
    }

}
