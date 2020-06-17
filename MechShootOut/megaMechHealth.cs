using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class megaMechHealth : MonoBehaviour
{

    public GameObject bullet;
    public GameObject electric;
    public GameObject fire;

    private int startHealth = 100;
    private int updatedHealth;
    private string health;
    private int damage = 2;


    // Use this for initialization
    void Start()
    {
        updatedHealth = startHealth;
        electric.SetActive(false);
        fire.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (updatedHealth <= 52)
        {
            electric.SetActive(true);
        }
        if(updatedHealth <= 20)
        {
            electric.SetActive(false);
            fire.SetActive(true);
        }
        if (updatedHealth <= 0)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "bullet(Clone)")
        {
            updatedHealth = updatedHealth - damage;
            Debug.Log(updatedHealth);

        }
    }
}
