using UnityEngine;
using System;

public enum EnemyTeams { Team1, Team2 }

public class Move : MonoBehaviour
{
    [SerializeField]
    private EnemyTeams _tagEnemyTeam;

    private GameObject[] _enemyTeam;
    private Transform _transform;

    private Vector2 _leastHeading;
    private GameObject _nearestEnemyUnit;
    private Transform _nearestTransformUnit;

    public float radius = 10f;
    public float speed = 1f;
    
    private bool _goToTarget = false;

    private Unit _unit;

    public Action<GameObject> fight;
    public static Action<string> gameOver;

    private void Start()
    {
        transform.position = new Vector2(UnityEngine.Random.Range(-5.5f,6f), UnityEngine.Random.Range(-4.3f, 4.3f));
        FindNearestEnemyUnit();
        _unit = GetComponent<Unit>();
    }

    void Update()
    {
        if (_unit._target == null)
        {
            FindNearestEnemyUnit();
        }

        if (_goToTarget)
        {
            _transform.position += (_nearestTransformUnit.position - _transform.position).normalized * speed * Time.deltaTime;

            if ((_nearestTransformUnit.position - _transform.position).sqrMagnitude < radius)
            {
                _goToTarget = false;
                fight(_nearestEnemyUnit);
            }
        }
    }

    public void FindNearestEnemyUnit() 
    {
        _transform = transform;

        _leastHeading = new Vector2(Mathf.Infinity, Mathf.Infinity);

        switch (_tagEnemyTeam)
        {
            case EnemyTeams.Team1:
                _enemyTeam = SearchForTheEnemy.team1;
                break;
            case EnemyTeams.Team2:
                _enemyTeam = SearchForTheEnemy.team2;
                break;
        }

        if (_enemyTeam.Length == 0) 
        {
            gameOver(tag);
        }

        foreach (GameObject enemyUnit in _enemyTeam)
        {
            var heading = enemyUnit.transform.position - _transform.position;

            if (heading.sqrMagnitude < _leastHeading.sqrMagnitude)
            {
                _leastHeading = heading;
                _nearestEnemyUnit = enemyUnit;
                _nearestTransformUnit = enemyUnit.transform;
            }
        }

        _goToTarget = true;
    }

}
