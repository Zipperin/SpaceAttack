﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    private int speed = 3;

    [SerializeField]
    private GameObject enemyExplosionPrefab;

    [SerializeField]
    private AudioClip explosionSound;


    void Start()
    {
     
    }

 
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -6.7f)
        {
            transform.position = new Vector3(Random.Range(-7.5f, 7.5f), 6.7f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            Destroy(collision.gameObject);
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 1.0f);
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {
            PlayerControls playerControls = collision.GetComponent<PlayerControls>();

            if (playerControls != null)
            {
                playerControls.LifeSubstraction();
            }
            Instantiate(enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 1.0f);
            Destroy(this.gameObject);
        }
    }
}
