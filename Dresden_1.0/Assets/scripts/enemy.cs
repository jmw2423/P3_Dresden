using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private fieldOfview fov;
    private Vector3[] arrOfWayPoints = new Vector3[3];
    public Vector3 startingWayPoint;
    private Vector3 currentWayPoint;
    public Vector3 targetWayPoint;
    private Vector3 nextWayPoint;
    private int counter;
    private bool movingLeft;
    private float speed = 0.3f;

    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        
        counter = 0;
        movingLeft = true;
        currentWayPoint = this.transform.position;
        arrOfWayPoints[0] = startingWayPoint;
        arrOfWayPoints[1] = targetWayPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.tag == "Enemy_1")
        {
            GetNextWayPoint();
            
            if(this.transform.position != currentWayPoint)
            {
                this.transform.position = Vector3.MoveTowards(transform.position, currentWayPoint, speed * Time.deltaTime);
            }
            else 
            {
                if(counter < 2)
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                }
                
                GetNextWayPoint();
            }
        }

        if(counter == 1)
        {
            dir = (startingWayPoint - transform.position).normalized;

        }
        else if(counter == 0)
        {
            dir = (targetWayPoint - transform.position).normalized;
        }
        

        fov.SetOrigin(transform.position);
        fov.SetAimDirection(GetAimDir());
        
    }
    private void GetNextWayPoint()
    {
        if(counter == 0)
        {
            currentWayPoint = targetWayPoint;
        }
        else
        {
            currentWayPoint = startingWayPoint;
        }

    }

    private Vector3 GetAimDir()
    {
        
        return dir;
    }
}
