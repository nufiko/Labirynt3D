using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
public float force;
private void OnTriggerStay(Collider other)
{
if(other.tag == "Player")
{
    Vector3 recoil = transform.InverseTransformDirection(transform.right) * Random.Range(-0.1f,0.1f) + transform.InverseTransformDirection(transform.forward) * -1f;
    other.GetComponent<CharacterController>().Move(recoil * Time.deltaTime * force);
}
}
}