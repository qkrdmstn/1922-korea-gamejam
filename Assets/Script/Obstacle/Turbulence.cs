using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbulence : MonoBehaviour
{
    public PlayerController player;
    public ParticleSystem ps;
    public float speed;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("Player"))
    //    {
    //        Debug.Log("asd");
    //        //other.gameObject.transform.Translate(new Vector3(0, 20, 0));
    //        //other.gameObject.GetComponent<Rigidbody>().AddForce(0, 100, 0, ForceMode.Acceleration);
    //        other.gameObject.transform.Rotate(Vector3.right * -1 * Time.deltaTime);
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        ps = this.GetComponent<ParticleSystem>();
        ps.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0, 0, -1 * speed * Time.deltaTime));
        if (this.gameObject.transform.position.z < player.transform.position.z - 50)
            Destroy(this.gameObject);
    }
}
