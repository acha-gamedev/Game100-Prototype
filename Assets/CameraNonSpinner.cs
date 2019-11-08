using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraNonSpinner : MonoBehaviour
{

    public GameObject player;
    public Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        transform.position = offset + player.transform.position;

        transform.RotateAround(player.transform.position, Vector3.up, Input.GetAxis("Mouse X"));


    }


}


