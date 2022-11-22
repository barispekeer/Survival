using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject zombie;
    public TMP_Text timeTxt, scoreTxt;
    public float time = 10f;
    public int score = 0;
    void Start()
    {
        InvokeRepeating("AddZombie", 0f, 5f);
    }
    void Update()
    {
        time -= Time.deltaTime;
        timeTxt.text = (int)time + "";
        if (time <= 0)
        {
            CancelInvoke(nameof(AddZombie));
            time = 0;
        }
        
    }
    void AddZombie()
    {
        Instantiate(zombie, new Vector3(Random.Range(250f,750f),transform.position.y,Random.Range(250f,750f)),Quaternion.identity);
    }
}
