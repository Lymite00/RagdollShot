using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cannon : MonoBehaviour {
    [SerializeField] private Ball _ballPrefab;

    [SerializeField] private Transform _ballSpawn;

    [SerializeField] private float _velocity = 10;
    [SerializeField] private GameObject particleObject;
    [SerializeField] private Transform effectTransform;

    [SerializeField] private AudioSource _aSource;
    [SerializeField] private AudioClip shotClip;

    private void Awake()
    {
        _aSource = GetComponentInChildren<AudioSource>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootCannon();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex);
        }
    }

    public void ShootCannon()
    {
        _aSource.PlayOneShot(shotClip);
        Instantiate(particleObject, effectTransform.position, Quaternion.Euler(0f,90f,0f));
        var ball = Instantiate(_ballPrefab, _ballSpawn.position, _ballSpawn.rotation);
        ball.Init(_velocity);
    }
}
