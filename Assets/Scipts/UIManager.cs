using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasManager))]
[Serializable]
public class UIManager : MonoBehaviour
{
    public static UIManager Manager;
    // Start is called before the first frame update
    public static GameObject MainCanvas;
    private static CanvasGroup AnswerPanel;
    
    private static CanvasManager dm;
    public GameObject player;
    void Awake()
    {
        dm = GetComponent<CanvasManager>();
        Manager = this;
        MainCanvas = GameObject.FindGameObjectsWithTag("Dialog")?.First();
        AnswerPanel = MainCanvas.GetComponentsInChildren<CanvasGroup>()?.Where(x => x.gameObject.CompareTag("Answers"))
            ?.First();
    }
    

    public static void Choosed()
    {
        dm.FadeOut();
    }
   
    public void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            dm.FadeIn();
        }
    }
    public void LateUpdate()
    {
        CanvasFly(MainCanvas);
    }
    
    [Header("Flying Canvas")]
    public GameObject objectToFollow;
    [Tooltip("Distance from point of object")]
    public Vector3 offset = new Vector3(0.5f, 0.5f, 0f);
    [Tooltip("Speed to catch foolowed object")]
    public float lerpSpeed = 1f;
    [Tooltip("Minimum distance to start follow")]
    public float MinDistanceToFollow=0f;
    
    public void CanvasFly(GameObject canvas)
    {
        if(Vector3.Distance(canvas.transform.position, objectToFollow.transform.position) >= MinDistanceToFollow)
            canvas.transform.position =  Vector3.Lerp(canvas.transform.position , objectToFollow.transform.position + offset, Time.deltaTime *lerpSpeed);
        canvas.transform.LookAt(player.transform);
    }
}