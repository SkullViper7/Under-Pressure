using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationforce;
    [SerializeField] private float rotationspeed;

    public static Player_Movement player_Movement;
    GameObject shield;
    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject wave;
    [SerializeField] private GameObject pistol;

    private float hitLast = 0;
    [SerializeField] private float hitDelay = 5;
    [SerializeField] private AudioSource hitSound;
    [SerializeField] private AudioSource deathSound;

    private bool death;

    private void Start()
    {
        shield = transform.Find("Shield").gameObject;
        bomb = transform.Find("Canon").gameObject;
        wave = transform.Find("WaveCharger").gameObject;
        pistol = transform.Find("Pistol").gameObject;
    }

    void Update()
    {   //Déplacements
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * inputMagnitude * Time.deltaTime, Space.World);

        //Rotation
        if (horizontalInput != 0)
        {
            transform.Rotate(Vector3.forward * (rotationforce * Mathf.Sign(-horizontalInput)) * Time.deltaTime);
            float angle = transform.eulerAngles.z;
            if (angle > 180)
                angle = angle - 360f;
            transform.eulerAngles = new Vector3(0, 0, Mathf.Clamp(angle, -30f,30f));
        }
        else
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, rotationspeed * Time.deltaTime);
        }

        //Screenbounds
        var dist = (this.transform.position - Camera.main.transform.position).z;

        var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(-0.05f, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1.05f, 0, dist)).x;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, -0.05f, dist)).y;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1.05f, dist)).y;

        Vector3 playerSize = this.gameObject.GetComponent<Renderer>().bounds.size;

        this.transform.position = new Vector3(
        Mathf.Clamp(this.transform.position.x, leftBorder + playerSize.x / 2, rightBorder - playerSize.x / 2),
        Mathf.Clamp(this.transform.position.y, topBorder + playerSize.y / 2, bottomBorder - playerSize.y / 2),
        this.transform.position.z
        );

        //Mort Joueur
        Scene scene = SceneManager.GetActiveScene();
        if (GameManager.gameManager._playerHealth.Health <= 0 && !death)
        {
            death = true;
            //if (deathSound != null)
            //{
                //deathSound.Play();
            //}
            if (scene.name == "Level1")
            {
                SceneManager.LoadScene("GameOver");
            }
            if (scene.name == "Level2")
            {
                SceneManager.LoadScene("GameOver 1");
            }

        }

    }

    void ActivateShield()
    {
        shield.SetActive(true);
    }

    public void DeactivateShield()
    {
        shield.SetActive(false);
    }

    public bool HasShield()
    {
        return shield.activeSelf;
    }

    public void ActivateBomb()
    {
        bomb.SetActive(true);
    }

    public void DeactivateBomb()
    {
        bomb.SetActive(false);
    }
    public void ActivateWave()
    {
        wave.SetActive(true);
    }

    public void DeactivateWave()
    {
        wave.SetActive(false);
    }

    public void ActivePistol()
    {
        pistol.SetActive(true);
    }

    public void DeactivatePistol()
    {
        pistol.SetActive(false);
    }

    //Collisions avec le joueur
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bonus bonus = collision.GetComponent<Bonus>();
        if (bonus)
        {
            if (bonus.activateShield)
            {
                ActivateShield();
            }

            if (bonus.addPowerUpBomb)
            {
                ActivateBomb();
                DeactivateWave();
                DeactivatePistol();
            }

            if (bonus.addPowerUpWave)
            {
                ActivateWave();
                DeactivateBomb();
                DeactivatePistol();
            }

            Destroy(bonus.gameObject);
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();
        EnemyLeftMove enemy = collision.GetComponent<EnemyLeftMove>();
        EnemyBullet enemyBullet = collision.GetComponent<EnemyBullet>();
        if (enemy != null || enemyBullet != null || obstacle != null)
        {
            if (Time.time - hitLast < hitDelay)
                return;

            if (HasShield())
            {
                DeactivateShield();
                Destroy(enemyBullet.gameObject);
                hitLast = Time.time;
            }
            else
            {
                PlayerTakeDmg(1);
                Debug.Log(GameManager.gameManager._playerHealth.Health);
                if (hitSound != null)
                {
                    hitSound?.Play();
                }
                
                hitLast = Time.time;
            }


        }

    }
    private void PlayerTakeDmg(int dmg)
    {
        GameManager.gameManager._playerHealth.DmgUnit(dmg);
    }


}
