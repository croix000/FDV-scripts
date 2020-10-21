using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCrystal : MonoBehaviour
{

    [SerializeField] int scoreValue;
    [SerializeField] float distanceToAddScore;

    [SerializeField] float timer;
    float timeCount;
    [SerializeField] float minimizeRate;
    [SerializeField] float minSize;
    [SerializeField] GameObject player;
    List<Vector3> positionsToTeleport;



    void Update()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) < distanceToAddScore) {

            Vector3 temp = transform.localScale;

            //We change the values for this saved variable (not actual transform scale)
            temp.x = temp.x * minimizeRate ;
            temp.y = temp.y * minimizeRate ;
            temp.z = temp.z * minimizeRate ;

            GameManager.Instance.AddScore(scoreValue);

            this.transform.localScale = temp;
            if (this.transform.localScale.y < 0.1f)
                GameObject.Destroy(this.gameObject);
        }


      
    }
}
