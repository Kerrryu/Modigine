using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using MoonSharp.Interpreter;
using UnityEngine;

namespace Modigine
{
	public class LuaScript
	{
		// Code variable with public getter
		private readonly string _code;

		public string Code
		{
			get { return _code; }
		}

		// Script for the interpreter
		private readonly Script _script;

		public Script GetScript()
		{
			return _script;
		}

		/// <summary>
		/// Create an instance of a Lua script with some Lua code
		/// </summary>
		/// <param name="code">Lua code in text format</param>
		public LuaScript(string code)
		{
			_code = code;
			_script = new Script();

			// Initialize the script and add the code
			InitializeScript(_script);
			_script.DoString(_code);

			// Run Awake and Start if they exist
			if (code.Contains("Awake"))
				_script.Call(_script.Globals.Get("Awake"));
			if (code.Contains("Start"))
				_script.Call(_script.Globals.Get("Start"));
		}

		/// <summary>
		/// This function tells the interpreter what each function in Unity does
		/// </summary>
		/// <param name="script"></param>
		public void InitializeScript(Script script)
		{
			UserData.RegisterType<GameObject>();
			UserData.RegisterType<Debug>();
			UserData.RegisterType<Input>();
			UserData.RegisterType<GUI>();
			UserData.RegisterType<Resources>();
			UserData.RegisterType<Transform>();
			UserData.RegisterType<Vector2>();
			UserData.RegisterType<Vector3>();
			UserData.RegisterType<Vector4>();
			UserData.RegisterType<Rect>();
			UserData.RegisterType<Time>();
			UserData.RegisterType<KeyCode>();
			UserData.RegisterType<GUILayout>();
			UserData.RegisterType<LuaAddons>();
			UserData.RegisterType<LuaScript>();

			script.Globals["Modigine"] = new LuaAddons();
			script.Globals["GameObject"] = UserData.CreateStatic(typeof(GameObject));
			script.Globals["Debug"] = UserData.CreateStatic(typeof(Debug));
			script.Globals["Input"] = UserData.CreateStatic(typeof(Input));
			script.Globals["KeyCode"] = UserData.CreateStatic<KeyCode>();
			script.Globals["Resources"] = UserData.CreateStatic(typeof(Resources));
			script.Globals["GUI"] = UserData.CreateStatic(typeof(GUI));
			script.Globals["GUILayout"] = UserData.CreateStatic(typeof(GUILayout));
			script.Globals["Vector2"] = UserData.CreateStatic(typeof(Vector2));
			script.Globals["Vector3"] = UserData.CreateStatic(typeof(Vector3));
			script.Globals["Vector4"] = UserData.CreateStatic(typeof(Vector4));
			script.Globals["Rect"] = UserData.CreateStatic(typeof(Rect));
			script.Globals["Time"] = UserData.CreateStatic(typeof(Time));
			//script.Globals.Set("transform", UserData.Create(transform));
		}
	}
}
