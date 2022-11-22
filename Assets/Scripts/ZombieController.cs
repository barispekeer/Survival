using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    GameObject player;
    float distance;
    Animator zombieAnim;
    int zombieHealt = 3;
    GameController gc;
    void Start()
    {
        player = GameObject.Find("Player");
        zombieAnim = GetComponent<Animator>();
        gc = GameObject.Find("GameManager").GetComponent<GameController>();
    }

    
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 30)
        {
            zombieAnim.SetBool("isRun", true);
        }
        if (distance < 15)
        {
            zombieAnim.SetBool("isAttack", true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            zombieHealt--;
            if (zombieHealt == 0)
            {
                gc.score++;
                gc.scoreTxt.text = gc.score + "";
                zombieAnim.SetBool("isDead",true);
                Destroy(this.gameObject, 3f);
            }
            
        }
    }
}
