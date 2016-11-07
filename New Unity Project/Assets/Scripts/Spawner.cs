using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject m_spawned_a;
    public GameObject m_spawned_b;

    // Use this for initialization
    void Start ()
    {
        //StartCoroutine(Spawn(false, false, m_spawned_b));
        //StartCoroutine(Spawn(false, true, m_spawned_a));
    }

    IEnumerator Spawn(bool player, bool direction, GameObject m_spawned_object)
    {
        int no_items = Random.Range(5, 13);
        int x = -3;
        if (player)
            x = 3;
        int y = -6;
        if (direction)
            y = 6;
        for (int i = 0; i < no_items; i++)
        {
            Vector3 p = new Vector3(x + Random.Range(-5f, 5f), y + Random.Range(-1f, 1f), 0);
            Instantiate(m_spawned_object, p, Quaternion.identity); // Change to pooling manager.
            yield return new WaitForSeconds(Random.Range(0f, 0.2f));

            yield return null; // This line avoids Crashes of the Coroutine and therefore, Unity crashes :D
        }
    }
}
