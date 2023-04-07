using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Camera : MonoBehaviour
{
    public float smoothTime;
    public TMP_Text textScore;
    private PlayerController player;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if(player.transform.position.y > transform.position.y)
        {
            transform.position = new Vector3(0, Mathf.Lerp(transform.position.y, player.transform.position.y, smoothTime), -10);
        }

        textScore.text = "Score: " + player.score;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            player.Kill();
        }
        if(col.gameObject.GetComponent<Platform>() != null)
        {
            Destroy(col.gameObject);
        }
    }
}
