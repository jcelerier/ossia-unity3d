using UnityEngine;
using System.Runtime;
using System.Runtime.InteropServices;
using System;
using System.Collections;

using UnityEditor;
using Ossia;


public class OssiaDevices : MonoBehaviour {
	static bool set = false;

	static Ossia.Local local_protocol = null;
	static Ossia.Device local_device = null;

	static Ossia.Minuit minuit_protocol = null;

	static Ossia.Node scene_node;
	Ossia.Network main;


	public delegate void debug_log_delegate(string str);
	static void DebugLogCallback(string str)
	{
		Debug.Log("OSSIA : " + str);
	}

	void Awake ()
    {
        if (!set) {
				set = true;
                Ossia.Network.ossia_device_reset_static();
                debug_log_delegate callback_delegate = new debug_log_delegate (DebugLogCallback);

				// Convert callback_delegate into a function pointer that can be
				// used in unmanaged code.
				IntPtr intptr_delegate = 
					Marshal.GetFunctionPointerForDelegate (callback_delegate);

				// Call the API passing along the function pointer.
				Ossia.Network.ossia_set_debug_logger (intptr_delegate);

				local_protocol = new Ossia.Local ();
				local_device = new Ossia.Device (local_protocol, "newDevice");
			    scene_node = local_device.GetRootNode().AddChild ("scene");


				minuit_protocol = new Ossia.Minuit (
				    "newDevice",
					"127.0.0.1", 
					13579, 
					9998);
		    	local_protocol.ExposeTo (minuit_protocol);
				Debug.Log ("Created ossia devices");
		}
	}

    void Update()
    {
        if(!set)
        {
            Awake();

        }
    }
	public Ossia.Node SceneNode()
	{
		return scene_node; 
	}


	void OnApplicationQuit()
    {
        local_device.Free ();
        Ossia.Network.ossia_device_reset_static();
	}

	public Ossia.Device GetDevice() {
		return local_device;
	}

	public Ossia.Protocol GetProtocol() {
		return local_protocol;
	}

    public void writePreset()
    {
        var p = new Namespace.Preset(local_device);
        p.WriteJson();
        var obj = GameObject.Find("Sphere");
        Debug.Log(p.GetAsString("/scene/Sphere/position/x"));
        Debug.Log(p.Get("/scene/Sphere/position/y").ToObject());
        Debug.Log(obj.transform.position);
        obj.transform.position += new Vector3(10, 10, 10);
        Debug.Log(obj.transform.position);
        p.ApplyToDevice(local_device, true);
        Debug.Log(obj.transform.position);
    }

}

[CustomEditor(typeof(OssiaDevices))]
public class OssiaDevicesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        OssiaDevices myScript = (OssiaDevices)target;
        if (GUILayout.Button("Write preset to disk"))
        {
            myScript.writePreset();
        }
    }
}