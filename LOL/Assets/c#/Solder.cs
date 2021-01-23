using UnityEngine;
using UnityEngine.AI;

public class Solder : HeroOne
{ /// <summary>
  /// 代理器
  /// </summary>
    private NavMeshAgent agent;

    [Header("對方主堡名稱")]
    public string targetName;
    [Header("停止距離"), Range(0, 50)]
    public float stopDistance = 3;
    [Header("攻擊範圍"), Range(0, 50)]
    public float rangeAttack = 15;
    [Header("對方的圖層")]
    public int layerEnemy;

    private Transform target;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0, 1, 0.3f);
        Gizmos.DrawSphere(transform.position, rangeAttack);

    }

    protected override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = date.speed;
        agent.stoppingDistance = stopDistance;
        //target = GameObject.Find(targetName).transform;
    }
    protected override void Update()
    {
        base.Update();
        Move(target);
    }

    protected override void Move(Transform targrt)
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, rangeAttack, 1 << layerEnemy);
        if (hit.Length >0)
        {
            print(hit[0]);
        }
        canvasHP.eulerAngles = new Vector3(-60, 180, 0);
        agent.SetDestination(targrt.position);
        ani.SetBool("跑步開關", agent.remainingDistance > agent.stoppingDistance);
    }



}

