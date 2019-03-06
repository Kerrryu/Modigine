using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

public class LuaManager : MonoBehaviour
{
	// This keeps track of an instance (Singleton)
	public static LuaManager Instance;
	
	// A list of scripts to feed into the interpreter
	public List<LuaScript> Scripts = new List<LuaScript>();

	/// <summary>
	/// Called upon awake
	/// </summary>
	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	/// <summary>
	/// Add a new script to the list for the interpreter
	/// </summary>
	/// <param name="lua">The LuaScript object you'd like to add to runtime</param>
	public void AddScript(string code)
	{
		LuaScript script = new LuaScript(code);
		Scripts.Add(script);
	}
	
	
	/**
	 * 	UNITY FUNCTIONS
	 */

	private void FixedUpdate()
	{
		Scripts.ForEach(x =>
		{
			if (x.GetScript().Globals.Get("FixedUpdate") != null)
			{
				x.GetScript().Call(x.GetScript().Globals.Get("FixedUpdate"));
			}
		});
	}

	private void Update()
	{
		Scripts.ForEach(x =>
		{
			if (x.GetScript().Globals.Get("Update") != null)
			{
				x.GetScript().Call(x.GetScript().Globals.Get("Update"));
			}
		});
	}

	private void LateUpdate()
	{
		Scripts.ForEach(x =>
		{
			if (x.GetScript().Globals.Get("LateUpdate") != null)
			{
				x.GetScript().Call(x.GetScript().Globals.Get("LateUpdate"));
			}
		});
	}

	private void OnGUI()
	{
		Scripts.ForEach(x =>
		{
			if (x.GetScript().Globals.Get("OnGUI") != null)
			{
				x.GetScript().Call(x.GetScript().Globals.Get("OnGUI"));
			}
		});
	}
}
