using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private int cherries = 0;
    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectSoundEffect;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Cherry"))
        {
            collectSoundEffect.Play();
            Destroy(other.gameObject);
            cherries++;
            cherriesText.text = "Cherries: " + cherries;
        }
    }

}
