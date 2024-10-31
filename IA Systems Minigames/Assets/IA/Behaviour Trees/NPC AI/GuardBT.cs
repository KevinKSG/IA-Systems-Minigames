using System.Collections.Generic;
using BehaviorTree;
using IA;
using UnityEngine.AI;

public class GuardBT : Tree
{
    public UnityEngine.Transform[] waypoints;
    
    public static FieldOfView fov2;
    public static NavMeshAgent agent2;

    public static float speed = 0.5f;
    public static float fovRange = 65f;
    public static float attackRange = 3f;

    public static bool shot = false;
    public static Shot2 bullet2;
    

    protected override Node SetupTree(FieldOfView fov, NavMeshAgent agent, Shot2 bullet)
    {
        fov2 = fov;
        agent2 = agent;
        bullet2 = bullet;

        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckEnemyInAttackRange(transform),
                new TaskAttack(transform),
                new TaskAttack2(transform),
                new TaskAttack3(transform),
            }),
            new Sequence(new List<Node>
            {
                new CheckEnemyInFOVRange(transform),
                new TaskGoToTarget(transform),
            }),
            new TaskPatrol(transform, waypoints),
        });

        return root;
    }
}
