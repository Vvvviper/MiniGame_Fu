using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private Transform tempTrans;
    private float waitTime = 2f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        tempTrans = collision.transform.parent;
        collision.transform.parent = this.transform;
        this.GetComponent<Animator>().SetBool("Move", true);
        collision.gameObject.GetComponent<MoveController>().GamePause = true;
        StartCoroutine(Return(collision));
    }

    private IEnumerator Return(Collision2D collision)
    {
        yield return new WaitForSeconds(waitTime);
        collision.transform.parent = tempTrans;
        yield return new WaitForSeconds(waitTime);
        collision.gameObject.GetComponent<MoveController>().GamePause = false;
        this.GetComponent<Animator>().SetBool("Move", false);
    }

}
