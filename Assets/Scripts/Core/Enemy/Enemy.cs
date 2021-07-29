using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 10;
    private int _scoreValue = 100;
    private float _shotCounter;
    public float minTimeBetweenShots = 0.3f;
    public float maxTimeBetweenShots = 3f;
    public GameObject projectile;
    public float projectileSpeed = 5f;
    private float _resetCounter;
    public GameObject deathVFX;
    public float TimeAfterDeath = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        _shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        _resetCounter = _shotCounter;
        
    }

    // Update is called once per frame
    void Update()
    {
        _shotCounter -= Time.deltaTime;
        if (_shotCounter <= 0)
        {
            Fire();
            _shotCounter = _resetCounter;
            
        }
        
    }
    public void Fire()
    {
        GameObject enemyLaser = Instantiate(projectile, transform.position, Quaternion.identity);
        enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }

        HP -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (HP <= 0)
        {
            FindObjectOfType<GameSession>().AddToScore(_scoreValue);
            Destroy(gameObject);
            GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
            Destroy(explosion, TimeAfterDeath);
            
        }
    }
    
}
