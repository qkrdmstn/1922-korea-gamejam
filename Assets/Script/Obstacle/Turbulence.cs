using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbulence : MonoBehaviour
{
    public PlayerController player;
    public ParticleSystem ps;
    public float speed;

    private void OnTriggerEnter(Collider other)
    {
       // 
        if(other.CompareTag("Player"))
        {
            Debug.Log("asd");
            //other.gameObject.transform.Translate(new Vector3(0, 20, 0));
            other.gameObject.GetComponent<Rigidbody>().AddForce(0, 100, 0, ForceMode.Acceleration);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        ps = this.GetComponent<ParticleSystem>();
        ps.Play();
        this.gameObject.transform.Translate(new Vector3(-1 * speed * Time.deltaTime, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
