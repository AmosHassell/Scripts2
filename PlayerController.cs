using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public float horizontalinput;
    public float verticalinput;
    public float speed = 10.0f;
    // a name to instead assign the boundary to a variable instead of a value, making the code easier to set up and change
    public float xRange = 10;
    public float zRange = 17;
    public GameObject projectilePrefab;
    // Update is called once per frame
    void Update()
    {
        //makes a boundary for the player
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -2);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        //lets you control the player
        horizontalinput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalinput * Time.deltaTime * speed);
        verticalinput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalinput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}

