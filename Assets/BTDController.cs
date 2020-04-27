using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTDController : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent btd;

    // Start is called before the first frame update
    void Start()
    {
        btd = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        btd.SetDestination(player.transform.position);
    }



    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Game Over");
    }


    public void SlowEnemy()
    {
        btd.GetComponent<NavMeshAgent>().speed = 0.1f;
    }


}
