using Unity.VisualScripting;
using UnityEngine;

public class PatrolState : BaseState
{
    public int waypointIndex;
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Perfomr()
    {
        PatrolCycle();
        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
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
            enemy.anim.SetBool("GO?",true);
            enemy.Agent.SetDestination(enemy.path.waypoints[waypointIndex].position);
            enemy.anim.SetBool("GO?", false);
        }
    }

}
