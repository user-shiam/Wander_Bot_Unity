using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent playerNavMeshAgent;
    [SerializeField]
    private Camera playerCamera;
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    public bool isRunning;


    private int  PlayerSpeed;

    private void Update()

    {
        if (IsPointerOverUIObject()) return;
        if (Input.GetMouseButton(0))
        {
           
            Ray myRay = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit myRaycastHit;

            if (Physics.Raycast(myRay, out myRaycastHit))
            {
               playerNavMeshAgent.SetDestination(myRaycastHit.point);
            }
        }

        if (playerNavMeshAgent.remainingDistance <= playerNavMeshAgent.stoppingDistance)
        {   
            isRunning = false;
        }
        else
        {
            isRunning = true;
        }
        playerAnimator.SetBool("IsRun", isRunning);

    }


    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    public void IncreaseSpeed()
    {
      if( PlayerSpeed < 5 )

        {
            PlayerSpeed++;
            playerNavMeshAgent.speed = PlayerSpeed;
        }

     }

    public void DecreaseSpeed()
    {

        if (PlayerSpeed > 1)

        {
            PlayerSpeed--;
            playerNavMeshAgent.speed = PlayerSpeed;
        }

    }
}