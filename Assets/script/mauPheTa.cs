using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mauPheTa : MonoBehaviour
{
     int hp = 50;
    public GameObject thuyen;
    // Update is called once per frame
    private void Start()
    {
       
    }
    void Update()
    {
        if (hp < 0)
        {
           thuyen.SetActive(false);
            hp = 50;
     
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bulletEnemy")
        {
            hp -= 20;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            hp -= 50;
        }
    }
}
