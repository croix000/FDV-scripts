using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static int score;
    [SerializeField] TextMeshProUGUI scoreUI;

    public static GameManager Instance;

    List<Vector3> positionsToTeleport= new List<Vector3>();

    [SerializeField] GameObject[] crystals;

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);


        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {

        foreach (GameObject crystal in crystals)
        {
            positionsToTeleport.Add(new Vector3(crystal.transform.position.x, crystal.transform.position.y, crystal.transform.position.z));

        }

        StartCoroutine(wait());
    }
    public void AddScore(int ammount)
    {

        score += ammount;
        scoreUI.text = "SCORE: " + score;
    }


    public void switchPos(){


        for (int i = 0; i < 10; i++)
        {
            int randomIndexA= Random.Range(0, positionsToTeleport.Count);
            int randomIndexB = Random.Range(0, positionsToTeleport.Count);
            Vector3 auxPos = positionsToTeleport[randomIndexA];
            positionsToTeleport[randomIndexA] = positionsToTeleport[randomIndexB];
            positionsToTeleport[randomIndexB] = auxPos;


        }


        for (int i = 0; i < crystals.Length; i++)
        {
            if(crystals[i] !=null)
                crystals[i].transform.position = positionsToTeleport[i];
        }
        
    }







    IEnumerator wait()
    {
        switchPos();
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
        StartCoroutine(wait());
    }
}
