﻿using UnityEngine;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System;

namespace Ossia
{
	public enum ossia_type
	{
		IMPULSE,
		BOOL,
		INT,
		FLOAT,
		CHAR,
		STRING,
		TUPLE,
		GENERIC,
		DESTINATION,
		BEHAVIOR
	}

	public enum ossia_access_mode
	{
		GET,
		SET,
		BI
	}

	public enum ossia_bounding_mode
	{
		FREE,
		CLIP,
		WRAP,
		FOLD
	}

	public delegate void ValueCallbackDelegate(Ossia.Value t);


	[System.AttributeUsage(System.AttributeTargets.All)]
	public class Expose : System.Attribute
	{
		public string ExposedName;

		public Expose(string name)
		{
			this.ExposedName = name;
		}
	}

}