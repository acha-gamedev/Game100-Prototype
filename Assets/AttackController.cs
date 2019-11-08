using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [HideInInspector] public float knockback; // read/set by PlayerController
    [HideInInspector] public float duration; // read/set by PlayerController
    public int damage; // amount of damage to inflict

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;
        if (duration <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.attachedRigidbody.AddForce(transform.forward * knockback);
            Debug.Log("Attack: Target Hit");
            other.GetComponent<EnemyTarget>().CurHp -= damage;
        }
    }
}
