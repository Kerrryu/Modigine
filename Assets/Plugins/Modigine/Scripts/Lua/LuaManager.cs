using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

namespace Modigine
{
	public class LuaManager : MonoBehaviour
	{
		// This keeps track of an instance (Singleton)
		public static LuaManager Instance;

		// A list of scripts to feed into the interpreter
		public List<LuaScript> Scripts = new List<LuaScript>();

		/// <summary>
		/// Initializes the LuaManager
		/// </summary>
		public void Initialize()
		{
			LuaCustomConverters.RegisterAll();
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
		
		/// <summary>
		/// Run Start and Awake function on each script that has them
		/// </summary>
		public void RunScripts()
		{
			foreach(var script in Scripts)
				script.Init();
		}

		/**
		 * 	UNITY FUNCTIONS
		 */

		private void FixedUpdate()
		{
			if(!ModManager.READY) return;

			Scripts.ForEach(x =>
			{
				if (x.Code.Contains("FixedUpdate"))
				{
					x.GetScript().Call(x.GetScript().Globals.Get("FixedUpdate"));
				}
			});
		}

		private void Update()
		{
			if(!ModManager.READY) return;

			Scripts.ForEach(x =>
			{
				if (x.Code.Contains("Update"))
				{
					x.GetScript().Call(x.GetScript().Globals.Get("Update"));
				}
			});
		}

		private void LateUpdate()
		{
			if(!ModManager.READY) return;

			Scripts.ForEach(x =>
			{
				if (x.Code.Contains("LateUpdate"))
				{
					x.GetScript().Call(x.GetScript().Globals.Get("LateUpdate"));
				}
			});
		}

		private void OnGUI()
		{
			if(!ModManager.READY) return;

			Scripts.ForEach(x =>
			{
				if (x.Code.Contains("OnGUI"))
				{
					x.GetScript().Call(x.GetScript().Globals.Get("OnGUI"));
				}
			});
		}
	}
}