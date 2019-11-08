using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed; // player's movement speed
    public GameObject attack; // the attack object to use; can be a prefab
    public GameObject cameraObject; // the camera object
    public float attackDuration; // how long the attack stays out, in seconds
    public float knockbackMax; // the maximum amount of knockback
    public float chargeMax; // the maximum charge time
    private Rigidbody rb;
    private float chargeTime;
    private GameObject swing;
    private AttackController swingControl;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // the player object's Rigidbody
        chargeTime = 0.0f; // the amount of time the player has been charging; leave alone
        swing = null; // the active instance of the attack; leave alone
        //swingTime = attackDuration; // timer for the attack; leave alone
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 
            rb.velocity.y, 
            Input.GetAxis("Vertical") * speed);

        rb.rotation = cameraObject.transform.rotation;

        if (Input.GetAxis("Fire1") > 0.0f)
        {
            chargeTime += Time.deltaTime;
            if (chargeTime >= chargeMax)
            {
                chargeTime = chargeMax;
            }
        }

        if ((Input.GetAxis("Fire1") <= 0.0f) && (swing == null) && (chargeTime > 0.0f))
        {
            swing = Instantiate(attack, rb.position, rb.rotation); // create an attack hitbox, save as swing
            swingControl = swing.GetComponent<AttackController>(); // get the cotroller script of the attack
            if (swingControl != null)
            {
                swingControl.knockback = (chargeTime / chargeMax) * knockbackMax;
                swingControl.duration = attackDuration;
            }
            chargeTime = 0.0f; // reset charge time
        }

        if (swing != null)
        {
            swing.transform.position = rb.position;
        }
    }
}
