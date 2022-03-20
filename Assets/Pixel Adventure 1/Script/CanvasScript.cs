using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{

    public RectTransform panelGameFinish;
    public Text txtGameFinish;
    // Start is called before the first frame update
    void Start()
    {
        // PlayerMovement.GameOverEvent += OnGameOverEvent;
    }

    private void OnGameOverEvent(object sender, System.EventArgs e)
    {
        panelGameFinish.gameObject.SetActive(true);
        txtGameFinish.text = "IT'S OVER, GG !";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
