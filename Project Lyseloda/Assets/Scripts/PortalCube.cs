using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCube : MonoBehaviour {

    public GameObject target;
    public Vector3 offset;

    public float cooldown;
    public bool disableTarget = true;
    private bool usable = true;

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (usable)
            {
                if (disableTarget)
                {
                    target.GetComponent<PortalCube>().StartResetToUsable();
                }

                target.GetComponent<PortalCube>().Teleport(other.gameObject);

                StartResetToUsable();

            }
            
        }

    }

    public void Teleport(GameObject player)
    {
        target.GetComponent<PortalCube>().ResetToUsable();
        player.gameObject.transform.position = transform.position + offset;
    }

    public void StartResetToUsable()
    {
        usable = false;
        StartCoroutine(ResetToUsable());
    }

    IEnumerator ResetToUsable()
    {
        yield return new WaitForSeconds(cooldown);
        GetComponent<Cube>().ResetToInactive();
        usable = true;
    }
}
