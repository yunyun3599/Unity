using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using DetectTrigger;
using System.Diagnostics;


namespace DetectTrigger
{
    class trigger
    {
        public static int on = 0;
    }
}

public class Target : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean grabPinch;
    
    public int status = 0;

    public Transform obj;
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

    public int[] angle = { 0, 15, 30, 45, 60, 75, 90, 105, 120, 135, 150, 165, 180, 195, 210, 225, 240, 255, 270, 285, 300, 315, 330, 345, 360 };
    int theta;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        theta = angle[Random.Range(0, 24)];
        distance = Random.Range(1, 3) * 1.5f;
        sw.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (status==0 && trigger.on==1 && GetTrigger())
        {
            transform.position = new Vector3((float)2.25+distance*Mathf.Sin(theta), (float)3.73+ distance*Mathf.Cos(theta), 0.11f);
            theta = angle[Random.Range(0, 24)];
            distance = Random.Range(1, 3) * 1.5f;
            trigger.on = 0;
            status = 1;
            sw.Start();
        }
        if(status==1 && trigger.on==1 && GetTrigger())
        {
            status = 0;
            sw.Stop();
            UnityEngine.Debug.Log("Time: "+sw.ElapsedMilliseconds / 1000.0F);
            UnityEngine.Debug.Log("Angle: "+theta);
            UnityEngine.Debug.Log("Distance :"+ distance);
            transform.position = new Vector3(2.25f, 3.73f, 0.11f);
            trigger.on = 0;
            status = 0;
            sw.Reset();
        }
    }

    public bool GetTrigger()
    {
        return grabPinch.GetState(handType);
    }
}
