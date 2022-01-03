using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private float _damage;
    public float Damage 
    {
        get => _damage;
    }

    [SerializeField]
    private float _hp;

    private Move _move;

    public Unit _target 
    {
        private set;
        get;
    }

    private void Start()
    {
        _move = GetComponent<Move>();
        _move.fight += OnFight;
    }

    void OnFight(GameObject enemy) 
    {
        _target = enemy.GetComponent<Unit>();
    }

    public void GetDamage(float amount, Unit attaker)
    {
        _hp -= amount;
        if (_hp <= 0) 
        {
            attaker.ClearTarget();
            Destroy(gameObject);
        }
    }
    
    private void OnDestroy()
    {
        SearchForTheEnemy.SearchEnemy();
        _move.fight -= OnFight;
    }

    private void Update()
    {
        if (_target != null) 
        {
            _target.GetDamage(Damage * Time.deltaTime, this);
        }
    }

    public void ClearTarget() 
    {
        _target = null;
    }
}
