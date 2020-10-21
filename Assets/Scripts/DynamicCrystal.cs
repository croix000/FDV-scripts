using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCrystal : MonoBehaviour
{


    [SerializeField] Vector3 positionStart;
    [SerializeField] Vector3 positionEnd;
    [SerializeField] float speed;

    Vector3 target;



    [SerializeField] GameObject player;
    [SerializeField] int scoreValue;
    [SerializeField] float distanceToAddScore;
    [SerializeField] float minimizeRate;
    [SerializeField] float minSize;


    private void Start()
    {
        target = positionEnd;
    }

    private void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, target, speed *Time.deltaTime);



        if (Vector3.Distance(transform.position, positionEnd) <0.1)
        {
            target = positionStart;
        }
        if (Vector3.Distance(transform.position, positionStart)< 0.1)
        {
            target = positionEnd;
        }



        if (Vector3.Distance(player.transform.position, this.transform.position) < distanceToAddScore)
        {

            Vector3 temp = transform.localScale;

            //We change the values for this saved variable (not actual transform scale)
            temp.x = temp.x * minimizeRate;
            temp.y = temp.y * minimizeRate;
            temp.z = temp.z * minimizeRate;

            GameManager.Instance.AddScore(scoreValue);

            this.transform.localScale = temp;
            if (this.transform.localScale.y < 0.1f)
                GameObject.Destroy(this.gameObject);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(positionStart, 1);
        Gizmos.DrawSphere(positionEnd, 1);
    }
}
