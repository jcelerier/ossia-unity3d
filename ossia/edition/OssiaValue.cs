﻿using UnityEngine;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System;

namespace Ossia
{
	public class ValueFactory
	{
		static public Value createString(string v)
		{
			return new Value(Network.ossia_value_create_string(v));
		}
		static public Value createInt(int v)
		{
			return new Value(Network.ossia_value_create_int(v));
		}
		static public Value createFloat(float v)
		{
			return new Value(Network.ossia_value_create_float(v));
		}
		static public Value createBool(bool v)
		{
			return new Value(Network.ossia_value_create_bool(v));
		}
		static public Value createChar(char v)
		{
			return new Value(Network.ossia_value_create_char(v));
		}

		static public Value createFromObject(object obj)
		{
			if (obj is int) 
			{
				return createInt ((int)obj);
			} 
			else if (obj is bool) 
			{
				return createBool ((bool)obj);
			}
			else if (obj is float)
			{
				return createFloat ((float)obj);
			}
			else if (obj is char)
			{
				return createChar ((char)obj);
			}
			else if (obj is string)
			{
				return createString ((string)obj);
			}

			throw new Exception("unimplemented type");
		}
	}
	public class Value : IDisposable
	{
		internal IntPtr ossia_value = IntPtr.Zero;
		bool disposed = false;

		internal protected Value(IntPtr v)
		{
			ossia_value = v;
		}

		public void Dispose()
		{ 
			Dispose(true);
			GC.SuppressFinalize(this);           
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposed)
				return; 

			if (disposing) {
				//Free(); TODO memleak
			}

			disposed = true;
		}

		public void Free()
		{
			Network.ossia_value_free (ossia_value);
		}

		public ossia_type GetOssiaType()
		{
			return Network.ossia_value_get_type(ossia_value);
		}

		public int GetInt()
		{
			return Network.ossia_value_to_int(ossia_value);
		}
		public bool GetBool()
		{
			return Network.ossia_value_to_bool(ossia_value);
		}
		public float GetFloat()
		{
			return Network.ossia_value_to_float(ossia_value);
		}
		public char GetChar()
		{
			return Network.ossia_value_to_char(ossia_value);
		}
		public string GetString()
		{
			return Network.ossia_value_to_string(ossia_value);
		}

		public IntPtr GetValue() {
			return ossia_value;
		}

		static public ossia_type ObjectToOssiaType(object obj)
		{
			if (obj is int) 
			{
				return ossia_type.INT;
			} 
			else if (obj is bool) 
			{
				return ossia_type.BOOL;
			}
			else if (obj is float)
			{
				return ossia_type.FLOAT;
			}
			else if (obj is char)
			{
				return ossia_type.CHAR;
			}
			else if (obj is string)
			{
				return ossia_type.STRING;
			}

			throw new Exception("unimplemented type");
		}

		static public ossia_type TypeToOssia<T>(T obj)
		{
			if (obj is int) 
			{
				return ossia_type.INT;
			} 
			else if (obj is bool) 
			{
				return ossia_type.BOOL;
			}
			else if (obj is float)
			{
				return ossia_type.FLOAT;
			}
			else if (obj is char)
			{
				return ossia_type.CHAR;
			}
			else if (obj is string)
			{
				return ossia_type.STRING;
			}

			throw new Exception("unimplemented type" + obj.GetType());
		}


		static public ossia_type TypeToOssia2(Type obj)
		{
			if (obj == typeof(System.Int32)) 
			{
				return ossia_type.INT;
			} 
			else if (obj == typeof(System.Boolean)) 
			{
				return ossia_type.BOOL;
			}
			else if (obj == typeof(System.Single))
			{
				return ossia_type.FLOAT;
			}
			else if (obj == typeof(System.Char))
			{
				return ossia_type.CHAR;
			}
			else if (obj == typeof(System.String))
			{
				return ossia_type.STRING;
			}

			throw new Exception("unimplemented type" + obj.GetType());
		}

		public object ToObject()
		{
			switch (GetOssiaType ()) {
			case ossia_type.INT:
				return GetInt ();
			case ossia_type.FLOAT:
				return GetFloat ();
			case ossia_type.BOOL:
				return GetBool ();
			case ossia_type.CHAR:
				return GetChar ();
			case ossia_type.STRING:
				return GetString ();
			default:
				throw new Exception("unimplemented type");
			}
		}

	}
}
