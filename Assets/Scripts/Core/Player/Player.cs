using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    public float padding = 1;
    public GameObject laserPrefab;
    public float projectileSpeed = 2;
    public int HP = 50;
    
    

    public float RPM = 10;
    private float _rps;
    private float _resetRps;
    
    

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    
    // Start is called before the first frame update
    void Start()
    {
        MoveBoundries();
        _rps = RPM / 60;
        _resetRps = _rps;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
        

        
    }

    private void Fire()
    {
        _rps -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {


            if (_rps <= 0)
            {
                
                GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
                laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

                _rps = _resetRps;

            }


        }
    }


    public void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float positionX = Mathf.Clamp(transform.position.x + moveX * speed * Time.deltaTime, xMin,xMax);

        float moveY = Input.GetAxis("Vertical");
        float positionY = Mathf.Clamp(transform.position.y + moveY * speed * Time.deltaTime, yMin,yMax);

        transform.position = new Vector2(positionX, positionY);
        
    }
    public void MoveBoundries()
    {
        Camera cam = Camera.main;
        xMin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = cam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
        
        
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
      
            Destroy(gameObject);
            FindObjectOfType<LevelLoader>().LoadGameOver();
        }
        
    }
}
