using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using DetectTrigger;
using Valve.VR;


namespace DetectTrigger
{
    class trigger
    {
        public static int on = 0;
    }
}


public class RandomObject : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean grabPinch;

    public Transform Target;



    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
    


    // Start is called before the first frame update
    void Start()
    {
        sw.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.on == 1&& GetTrigger())
        {
            sw.Stop();
            UnityEngine.Debug.Log(sw.ElapsedMilliseconds / 1000.0F);
            UnityEngine.Debug.Log(transform.position);
            transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(0f, 15f), Random.Range(-7f, 13f));
            float randnum = Random.Range(0.5f, 2.0f);
            transform.localScale = new Vector3(randnum, randnum, randnum);
            trigger.on = 0;
            sw.Reset();
            sw.Start();
        }
    }

    public bool GetTrigger()
    {
        return grabPinch.GetState(handType);
    }
}
