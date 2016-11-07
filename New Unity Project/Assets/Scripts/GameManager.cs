using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
	private int m_player_option;
	private bool listening_movement;

	[Header("Prefabs.")]
    public GameObject m_timer_prefab;
    public GameObject m_option_wheel_prefab;
    
    // Singleton.
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        //init
		ObjectPoolingManager.Instance.CreatePool (m_timer_prefab,1,1);
		ObjectPoolingManager.Instance.CreatePool (m_option_wheel_prefab,2,2);

        listening_movement = false;
        InputPhase();
    }
    void InputPhase()
	{	GameObject tim = ObjectPoolingManager.Instance.GetObject (m_timer_prefab.name);
		tim.transform.position = new Vector3(0,4,0);
		tim.transform.rotation = Quaternion.Euler (0,0,90);

		GameObject left_panel = ObjectPoolingManager.Instance.GetObject (m_option_wheel_prefab.name);
		left_panel.transform.position = new Vector3(-9,5,0);
		left_panel.transform.rotation = Quaternion.identity;

		GameObject right_panel = ObjectPoolingManager.Instance.GetObject (m_option_wheel_prefab.name);
		right_panel.transform.position = new Vector3(9,5,0);
		right_panel.transform.rotation = Quaternion.identity;

//        Instantiate(m_timer_prefab, new Vector3(0, 4, 0), Quaternion.Euler(0, 0, 90));
//        Instantiate(m_option_wheel_prefab, new Vector3(-9, 5, 0), Quaternion.identity);
//        Instantiate(m_option_wheel_prefab, new Vector3(9, 5, 0), Quaternion.identity);
        listening_movement = true;
    }

    public void EventsPhase()
    {
        listening_movement = false;
        Debug.Log("we are here.");
        //controlInputs
        //ExecuteEvents
        //InputPhase();
    }

    // Update is called once per frame
    void Update()
    {
        if (listening_movement)
        {
            if (Input.GetAxis("Fire1") > 0.1)
                m_player_option = 1;
            else if (Input.GetAxis("Fire2") > 0.1)
                m_player_option = 2;
            else if (Input.GetAxis("Fire3") > 0.1)
                m_player_option = 3;
        }
    }
}
