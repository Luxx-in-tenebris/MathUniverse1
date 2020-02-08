using UnityEngine;
using System.Collections;

public class Shoot_controller : MonoBehaviour {
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;
    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        //if (Time.time > nextFire)
        //{
        //    nextFire = Time.time + fireRate;
        //    Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        //    GetComponent<AudioSource>().Play();
        //}
    }
    public void shoot()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        GetComponent<AudioSource>().Play();
    }
}
