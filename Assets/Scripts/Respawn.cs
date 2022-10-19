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
        if(other.CompareTag("Environment"))
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
        player.transform.SetPositionAndRotation(spawnPoint.transform.position, new Quaternion(0, 0, 0, 0));
        Physics.SyncTransforms();
    }

    public void Update()
    {
        PlayerMode mode = player.GetComponent<PlayerMode>();
        if (Input.GetKey(KeyCode.R) && mode.tipoControllo != PlayerMode.ControlType.AI)
        {
            respawnCar();
        }
    }

}