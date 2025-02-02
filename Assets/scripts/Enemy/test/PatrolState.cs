using Unity.VisualScripting;
using UnityEngine;

public class PatrolState : BaseState
{
    public int waypointIndex;
    private Animator anim;
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Perfomr()
    {
        PatrolCycle();
    }
    
    public void PatrolCycle()
    {
        if (enemy.Agent.remainingDistance < 0.2f)
        {
            if (waypointIndex < enemy.path.waypoints.Count - 1)
            {
                waypointIndex++;
            }
            else
            {
                waypointIndex = 0;
            }
            enemy.Agent.SetDestination(enemy.path.waypoints[waypointIndex].position);

        }
    }
}
