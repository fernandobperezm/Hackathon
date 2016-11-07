using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public GameObject m_timer_prefab;
    public GameObject m_option_wheel_prefab;
    private int m_player_option;
    private bool listening_movement;

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
        listening_movement = false;
        InputPhase();
    }
    void InputPhase()
    {
        Instantiate(m_timer_prefab, new Vector3(0, 4, 0), Quaternion.Euler(0, 0, 90));
        Instantiate(m_option_wheel_prefab, new Vector3(-9, 5, 0), Quaternion.identity);
        Instantiate(m_option_wheel_prefab, new Vector3(9, 5, 0), Quaternion.identity);
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
