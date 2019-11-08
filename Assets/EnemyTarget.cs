using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    public int MaxHp; // maximum and starting HP
    [HideInInspector] public int CurHp;
    private Rigidbody rb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        CurHp = MaxHp;
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (CurHp <= 0)
        {
            rb.position = new Vector3(0.0f, 10.0f, 0.0f);
            Debug.Log("Target: Reposition for spawn");
            CurHp = MaxHp;
            rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Attack")
    //    {
    //        CurHp -= 5;
    //        Debug.Log("Target: Hit by Attack");
    //        if (CurHp <= 0)
    //        {
    //            rb.position = new Vector3(0.0f, 10.0f, 0.0f);
    //            Debug.Log("Target: Reposition for spawn");
    //        }
    //    }
    //}
}
