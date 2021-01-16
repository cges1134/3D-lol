using UnityEngine;
using UnityEngine.AI;

public class Solder : HeroOne
{ 
     private NavMeshAgent agent;
    [Header("對方主堡")]
    private Transform targrt;

    protected override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = date.speed; 
    }
    protected override void Update()
    {
        base.Update();
        Move(targrt);
    }

    protected override void Move(Transform targrt)
    {
        agent.SetDestination(targrt.position);
    }



}

