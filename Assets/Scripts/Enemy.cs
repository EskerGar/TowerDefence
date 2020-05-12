using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ScriptableObject enemySettings;
    public ScriptableObject ReturnSettings => enemySettings;
    public GameObject Target { get; private set; }

    private void Awake()
    {
        Target = GameObject.FindWithTag("Base");
;    }
}
