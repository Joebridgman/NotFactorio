using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Mineable : Interactable {
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public GameObject healthBar;
    GameObject activeParticles;
    public GameObject particlesPrefab;
    public GameObject particlesTarget;
    public bool isParticlesOn = false;

    public void AdjustHealthBar() {
        if (Health < MaxHealth && Health > MaxHealth * 0.75) {
            healthBar.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (Health <= MaxHealth * 0.75 && Health > MaxHealth * 0.35) {
            healthBar.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else if (Health <= MaxHealth * 0.35) {
            healthBar.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else {
            healthBar.GetComponent<SpriteRenderer>().color = Color.clear;
        }
        healthBar.transform.localScale = new Vector3(4.25f * ((float)Health / MaxHealth), healthBar.transform.localScale.y, healthBar.transform.localScale.z);

        if (isParticlesOn) {
            activeParticles.GetComponent<Particles>().particlesTarget = particlesTarget.transform.position;
        }
    }

    public void DropExplosion(List<GameObject> drops) {
        foreach (GameObject d in drops) {
            int x = UnityEngine.Random.Range(-100, 101);
            int y = UnityEngine.Random.Range(-100, 101);
            d.GetComponent<Rigidbody2D>().AddForce(4 * transform.up * y);
            d.GetComponent<Rigidbody2D>().AddForce(4 * transform.right * x);
        }
    }

    void OnMouseOver() {
        var player = GameObject.FindGameObjectWithTag("Player");
        var distance = Mathf.Pow(player.transform.position.x - transform.position.x, 2)
                     + Mathf.Pow(player.transform.position.y - transform.position.y, 2);

        if (distance < 25) {
            player.GetComponent<PlayerInteraction>().target = gameObject;
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else {
            player.GetComponent<PlayerInteraction>().target = null;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

    }

    void OnMouseExit() {
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerInteraction>().target = null;
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void turnOnParticles() {
        isParticlesOn = true;
        activeParticles = Instantiate(particlesPrefab, transform.position, Quaternion.identity);

    }

    public void turnOffParticles() {
        isParticlesOn = false;
        Destroy(activeParticles);
    }

    public void Mine() {
        Health -= 5;
        AdjustHealthBar();

        Debug.Log("Mineable health: " + Health);
    }
}
