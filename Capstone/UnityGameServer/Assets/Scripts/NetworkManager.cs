using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager instance;

    public GameObject playerPrefab;
    public GameObject projectilePrefab;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Debug.Log("Instance of Network Manager already Exists!");

            Destroy(this);
        }
    }

    public void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        Server.Start(50, 80);
    

    }

    private void OnApplicationQuit()
    {
        Server.Stop();
    }

    public Player InstantiatePlayer()
    {
        return Instantiate(playerPrefab,new Vector3(0,0.5f, 0), Quaternion.identity).GetComponent<Player>();
    }

    public Projectile InstantiateProjectile(Transform _shootOrigin)
    {
        return Instantiate(projectilePrefab, _shootOrigin.position + _shootOrigin.forward * 0.7f, 
            Quaternion.identity).GetComponent<Projectile>();
    }
}
