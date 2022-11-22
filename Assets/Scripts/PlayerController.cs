using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzle;
    public Image healtIma;
    float totalHealth = 100f;
    float currentlyHealth = 100f;
    GameController gc2;
    void Start()
    {
        gc2 = GameObject.Find("GameManager").GetComponent<GameController>();
    }


    void Update()
    {
        if (gc2.time > 0)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                GameObject newBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
                newBullet.GetComponent<Rigidbody>().velocity = muzzle.transform.forward * 45f;
                Destroy(newBullet, 1.5f);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Zombie"))
        {
            currentlyHealth -= 10f;
            healtIma.fillAmount = currentlyHealth / totalHealth;
            if (currentlyHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
