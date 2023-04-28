using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthScript : MonoBehaviour
{

    public static int health = 10;
    public GameObject text;
    public GameObject lose;
    public static bool win = false;

    TextMeshProUGUI tmp;

    void Start()
    {
        tmp = text.GetComponent<TextMeshProUGUI>();
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.name.Contains("Projectile"))
        {
            health--;
            tmp.text = "Health: " + health;

            if (health <= 0 && !win)
            {
                lose.SetActive(true);
            }
        }
    }
}
