﻿using UnityEngine;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System;

namespace Ossia
{
	public class Address
	{
		internal IntPtr ossia_address = IntPtr.Zero;
		internal IntPtr ossia_callback_it = IntPtr.Zero;
		List<ValueCallbackDelegate> callbacks; 

		public Address(IntPtr address)
		{
			callbacks = new List<ValueCallbackDelegate> ();
			ossia_address = address;
		}

		public void SetAccessMode(ossia_access_mode m)
		{
			Network.ossia_address_set_access_mode (ossia_address, m);
		}

		public ossia_access_mode GetAccessMode()
		{
			return Network.ossia_address_get_access_mode (ossia_address);
		}

		public void SetBoundingMode(ossia_bounding_mode m)
		{
			Network.ossia_address_set_bounding_mode (ossia_address, m);
		}

		public ossia_bounding_mode GetBoundingMode()
		{
			return Network.ossia_address_get_bounding_mode (ossia_address);
		}

		public void SetValue(Value val)
		{
			Network.ossia_address_set_value (ossia_address, val.ossia_value);
		}

		public Value GetValue()
		{
			return new Value (Network.ossia_address_clone_value (ossia_address));
		}

		public void PushValue(Value val)
		{
			Network.ossia_address_push_value (ossia_address, val.ossia_value);
		}

		public Value PullValue()
		{
			return new Value (Network.ossia_address_pull_value (ossia_address));
		}

		private void DoNothing(Value v) 
		{
			Debug.LogError ("Value received");
		}


		public void SetValueUpdating(bool b)
		{
			if (b) {
				AddCallback (DoNothing);
			} else {
				RemoveCallback (DoNothing);
			}				
		}


		public void AddCallback(ValueCallbackDelegate callback)
		{
			if (callbacks.Count == 0) {
				// We initialize the callback structure.
				var real_cb = new Network.ossia_value_callback ((IntPtr p) => CallbackWrapper(this, p));
				IntPtr intptr_delegate = Marshal.GetFunctionPointerForDelegate (real_cb);
				ossia_callback_it = Network.ossia_address_add_callback(ossia_address, intptr_delegate);
			}
			callbacks.Add (callback);
		}

		static public void CallbackWrapper(Address self, IntPtr value)
		{
			Debug.Log("OSSIA callback root");
			Ossia.Value val = new Ossia.Value (value);
			foreach(var cb in self.callbacks)
			{
				cb (val);				
			}

		}

		public void RemoveCallback(ValueCallbackDelegate c)
		{
			Debug.Log ("remove");
			callbacks.RemoveAll(x => x == c);
			if (callbacks.Count == 0) {
				Network.ossia_address_remove_callback (ossia_address, ossia_callback_it);
			}
		}

		/* TODO

		[DllImport ("ossia")]
		public static extern void ossia_address_set_domain (
			IntPtr address,
			IntPtr domain);

		[DllImport ("ossia")]
		public static extern IntPtr ossia_address_get_domain (
			IntPtr address);

        */
	}
}

