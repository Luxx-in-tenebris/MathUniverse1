using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;
    private Shoot_controller shootControllerObject;
    public float waveWait;


    private bool collides_Wrong_asteroid = false;
    private bool collides_Right_asteroid = false;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
        shootControllerObject = this.GetComponent < Shoot_controller>();
    }

    //вызывается при столкновении коллизии нашего корабля с другим объектом, имеющим коллизию
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser_shot")
        {
            return;
        }

        if (other.tag == "RightAsteroid")
        {
            shootControllerObject.shoot();

            collides_Right_asteroid = true;
            gameController.AddScore(scoreValue);
            StartCoroutine(Delay());            
            return;
        }

        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "WrongAsteroid")
        {
            gameController.GameOver();
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);

        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }//end OnTriggerEnter (Collider other)



    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(waveWait);
        gameController.Access_to_SpawnAsteroids();
    }
}

   
