using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimaPlataforma : MonoBehaviour
{
    public Transform[] Pose;
    public float speed;
    public int ID;
    public int suma;
    private bool primeravez = true;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (!primeravez) {
            if (transform.position == Pose[ID].position)
            {
                ID += suma;
            }
            if (ID == Pose.Length - 1)
            {
                suma = -1;
            }
            if (ID == 0)
            {
                suma = 1;
            }

            transform.position = Vector3.MoveTowards(transform.position, Pose[ID].position, speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (primeravez)
            {
                this.transform.position = Pose[0].position;
                primeravez = false;
            }    
            collision.transform.SetParent(this.transform); 
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
