using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject player;
    public GameObject enviorment;

    //when the top collider touches the enviornment, it sets the new position into the closest respawn point.
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.tag}");
        if(other.CompareTag("Enviorment"))
        {
            respawnCar();
        }
    }

    public GameObject getClosestSpawnPoint()
    {
        List<float>distances = new List<float>();
        
        foreach (var t in spawnPoints) distances.Add(Vector3.Distance(player.transform.position, t.transform.position));
        return spawnPoints[distances.IndexOf(distances.Min())];
    }

    public void respawnCar()
    {
        GameObject spawnPoint = getClosestSpawnPoint();
        Debug.Log($"{spawnPoint.name}");
        player.transform.SetPositionAndRotation(spawnPoint.transform.position, new Quaternion(0, 0, 0, 0));
        Physics.SyncTransforms();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            respawnCar();
        }
    }

}