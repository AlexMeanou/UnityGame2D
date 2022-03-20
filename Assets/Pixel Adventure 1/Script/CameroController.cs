using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameroController : MonoBehaviour
{

    [SerializeField] private Transform player;

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
