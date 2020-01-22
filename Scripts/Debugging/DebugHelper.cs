// =======================================================================================
// Wovencore
// by Weaver (Fhiz)
// MIT licensed
// =======================================================================================

using Wovencode;
using Wovencode.Debug;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Wovencode.Debug
{
	
	// ===================================================================================
	// DebugHelper
	// ===================================================================================
	[System.Serializable]
	public partial class DebugHelper
	{
		
		public bool debugMode;
		
		protected List<DebugProfile> debugProfiles = new List<DebugProfile>();
		
		// ======================= PUBLIC METHODS - DEBUG ================================
		
		// -------------------------------------------------------------------------------
		// Log
		// @debugMode
		// -------------------------------------------------------------------------------
		public void Log(string message)
		{
			if (debugMode)
				UnityEngine.Debug.Log(message);
		}
		
		// -------------------------------------------------------------------------------
		// LogWarning
		// @debugMode
		// -------------------------------------------------------------------------------
		public void LogWarning(string message)
		{
			if (debugMode)
				UnityEngine.Debug.LogWarning(message);
		}
		
		// -------------------------------------------------------------------------------
		// LogError
		// @debugMode
		// -------------------------------------------------------------------------------
		public void LogError(string message)
		{
			if (debugMode)
				UnityEngine.Debug.LogError(message);
		}
		
		// -------------------------------------------------------------------------------
		
		// ===================== PUBLIC METHODS - PROFILING ==============================
		
		// -------------------------------------------------------------------------------
		// StartProfile
		// -------------------------------------------------------------------------------
		public void StartProfile(string name)
		{
			if (HasProfile(name))
				RestartProfile(name);
			else
				AddProfile(name);
		}
		
		// -------------------------------------------------------------------------------
		// StopProfile
		// -------------------------------------------------------------------------------
		public void StopProfile(string name)
		{
			int index = GetProfileIndex(name);
			if (index != -1)
				debugProfiles[index].Stop();
		}
		
		// -------------------------------------------------------------------------------
		// PrintProfile
		// -------------------------------------------------------------------------------
		public void PrintProfile(string name)
		{
			int index = GetProfileIndex(name);
			if (index != -1)
				Log(debugProfiles[index].Print);
		}
		
		// -------------------------------------------------------------------------------
		// Reset
		// -------------------------------------------------------------------------------
		public void Reset()
		{
			foreach (DebugProfile profile in debugProfiles)
				profile.Reset();
		}
		
		// -------------------------------------------------------------------------------
		// HasProfile
		// -------------------------------------------------------------------------------
		protected bool HasProfile(string _name)
		{
			return debugProfiles.Any(x => x.name == _name);
		}
		
		// -------------------------------------------------------------------------------
		// GetProfileIndex
		// -------------------------------------------------------------------------------
		protected int GetProfileIndex(string _name)
		{
			return debugProfiles.FindIndex(x => x.name == _name);
		}
		
		// -------------------------------------------------------------------------------
		// AddProfile
		// -------------------------------------------------------------------------------
		protected void AddProfile(string name)
		{
			debugProfiles.Add(new DebugProfile(name));
		}
		
		// -------------------------------------------------------------------------------
		// RestartProfile
		// -------------------------------------------------------------------------------
		protected void RestartProfile(string name)
		{
			int index = GetProfileIndex(name);
			if (index != -1)
				debugProfiles[index].Restart();
		}
		
		
		
		// -------------------------------------------------------------------------------
		
	}

}

// =======================================================================================