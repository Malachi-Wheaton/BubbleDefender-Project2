using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject Target;
    public float Range = 5.0f;
    public GameObject BulletPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag("Enemy");

        if (possibleTargets.Length == 0) return;

        Target = possibleTargets[0];

        foreach (GameObject o in possibleTargets)
        {
            if (Vector3.Distance(transform.position, o.transform.position) <
                Vector3.Distance(transform.position, Target.transform.position))
            {
                Target = o;
            }
        }

        if (Vector3.Distance(transform.position, Target.transform.position) <= Range)
        {
            Debug.Log("Bang!");
            //fire!
            //.instantiate a bullet at the tower.transform.position
            // Figure out the angle for it:
            //bullet.transform.LookAt(Target.transform.position);
        }
    }
}