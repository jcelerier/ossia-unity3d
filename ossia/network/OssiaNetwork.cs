﻿using UnityEngine;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System;

namespace Ossia
{
	internal class Network
	{
		public delegate void ossia_value_callback(IntPtr t);

		//// Protocol ////
		[DllImport ("ossia")]
		public static extern IntPtr ossia_protocol_local_create ();

		[DllImport ("ossia")]
		public static extern void ossia_protocol_local_expose_to (
			IntPtr local_protocol,
			IntPtr remote_protocol);

		[DllImport ("ossia")]
		public static extern IntPtr ossia_protocol_osc_create (
			string ip, 
			int in_port, 
			int out_port);

		[DllImport ("ossia")]
		public static extern IntPtr ossia_protocol_minuit_create (
			string name,
			string ip, 
			int in_port, 
			int out_port);

		[DllImport ("ossia")]
		public static extern IntPtr ossia_protocol_oscquery_server_create(
			int osc_port,
			int ws_port);

		[DllImport ("ossia")]
		public static extern IntPtr ossia_protocol_oscquery_mirror_create(
			string host);

		[DllImport ("ossia")]
		public static extern void ossia_protocol_free(
			   IntPtr proto);


		//// Device ////
		[DllImport ("ossia")]
		public static extern IntPtr ossia_device_create (
			IntPtr protocol,
			string name);

		[DllImport ("ossia")]
		public static extern void ossia_device_free (
			IntPtr device);
		
		[DllImport ("ossia")]
		public static extern int ossia_device_update_namespace (
			IntPtr device);


		[DllImport ("ossia")]
		public static extern IntPtr ossia_device_get_name (
			IntPtr device);

		[DllImport ("ossia")]
		public static extern IntPtr ossia_device_get_root_node (
			IntPtr device);


		//// Node ////
		[DllImport ("ossia")]
		public static extern IntPtr ossia_node_find(
			IntPtr root,
			string name);
		
		[DllImport ("ossia")]
		public static extern IntPtr ossia_node_create(
			IntPtr root,
			string name);
		
		[DllImport ("ossia")]
		public static extern IntPtr ossia_node_add_child (
			IntPtr node,
			string name);

		[DllImport ("ossia")]
		public static extern void ossia_node_remove_child (
			IntPtr node,
			IntPtr child);

		[DllImport ("ossia")]
		public static extern IntPtr ossia_node_get_name (
			IntPtr device);

		[DllImport ("ossia")]
		public static extern int ossia_node_child_size (
			IntPtr node);

		[DllImport ("ossia")]
		public static extern IntPtr ossia_node_get_child (
			IntPtr node,
			int child_n);


		[DllImport ("ossia")]
		public static extern IntPtr ossia_node_create_address (
			IntPtr node,
			ossia_type type);

		[DllImport ("ossia")]
		public static extern IntPtr ossia_node_get_address(
			IntPtr node);
		
		[DllImport ("ossia")]
		public static extern void ossia_node_remove_address (
			IntPtr node,
			IntPtr address);


		//// Address ////

		[DllImport ("ossia")]
		public static extern void ossia_address_set_access_mode (
			IntPtr address,
			ossia_access_mode am);

		[DllImport ("ossia")]
		public static extern ossia_access_mode ossia_address_get_access_mode (
			IntPtr address);


		[DllImport ("ossia")]
		public static extern void ossia_address_set_bounding_mode (
			IntPtr address,
			ossia_bounding_mode bm);

		[DllImport ("ossia")]
		public static extern ossia_bounding_mode ossia_address_get_bounding_mode (
			IntPtr address);


		[DllImport ("ossia")]
		public static extern void ossia_address_set_domain (
			IntPtr address,
			IntPtr domain);

		[DllImport ("ossia")]
		public static extern IntPtr ossia_address_get_domain (
			IntPtr address);


		[DllImport ("ossia")]
		public static extern void ossia_address_set_value (
			IntPtr address,
			IntPtr value);

		[DllImport ("ossia")]
		public static extern IntPtr ossia_address_clone_value (
			IntPtr address);



		[DllImport ("ossia")]
		public static extern void ossia_address_push_value (
			IntPtr address,
			IntPtr value);


		[DllImport ("ossia")]
		public static extern void ossia_address_push_impulse(
			IntPtr address);
		[DllImport ("ossia")]
		public static extern void ossia_address_push_i(
			IntPtr address,
			int value);
		[DllImport ("ossia")]
		public static extern void ossia_address_push_b(
			IntPtr address,
			int b);
		[DllImport ("ossia")]
		public static extern void ossia_address_push_f(
			IntPtr address,
			float value);
		[DllImport ("ossia")]
		public static extern void ossia_address_push_2f(
			IntPtr address,
			float v1, float v2); 
		[DllImport ("ossia")]
		public static extern void ossia_address_push_3f(
			IntPtr address,
			float v1, float v2, float v3);
		[DllImport ("ossia")]
		public static extern void ossia_address_push_4f(
			IntPtr address,
			float v1, float v2, float v3, float v4);
		[DllImport ("ossia")]
		public static extern void ossia_address_push_c(
			IntPtr address,
			char value);
		[DllImport ("ossia")]
		public static extern void ossia_address_push_s(
			IntPtr address,
			string value);
		[DllImport ("ossia")]
		public static extern void ossia_address_push_in(
			IntPtr address,
			IntPtr value,
			int sz);
		[DllImport ("ossia")]
		public static extern void ossia_address_push_fn(
			IntPtr address,
			IntPtr value,
			int sz);
		[DllImport ("ossia")]
		public static extern void ossia_address_push_cn( // pushed as a string
			IntPtr address,
			IntPtr value,
			int sz);
		

		[DllImport ("ossia")]
		public static extern IntPtr ossia_address_pull_value (
			IntPtr address);


		[DllImport ("ossia")]
		public static extern IntPtr ossia_address_add_callback (
			IntPtr address,
			IntPtr callback, 
			IntPtr ctx);
		
		[DllImport ("ossia")]
		public static extern void ossia_address_push_callback(
			IntPtr address,
			IntPtr callback,
			IntPtr ctx);
		
		[DllImport ("ossia")]
		public static extern void ossia_address_remove_callback (
			IntPtr address,
			IntPtr index);

		[DllImport ("ossia")]
		public static extern void ossia_address_free_callback_idx(
			IntPtr index);


		//// Domain ////

		[DllImport ("ossia")]
		public static extern IntPtr ossia_domain_get_min (
			IntPtr domain);

		[DllImport ("ossia")]
		public static extern void ossia_domain_set_min (
			IntPtr domain,
			IntPtr value);


		[DllImport ("ossia")]
		public static extern IntPtr ossia_domain_get_max (
			IntPtr domain);

		[DllImport ("ossia")]
		public static extern void ossia_domain_set_max (
			IntPtr domain,
			IntPtr value);


		[DllImport ("ossia")]
		public static extern void ossia_domain_free (
			IntPtr address);

		//// Value ////

		[DllImport ("ossia")]
		public static extern IntPtr ossia_value_create_impulse ();

		[DllImport ("ossia")]
		public static extern IntPtr ossia_value_create_int (int value);

		[DllImport ("ossia")]
		public static extern IntPtr ossia_value_create_float (float value);

		[DllImport ("ossia")]
		public static extern IntPtr ossia_value_create_bool (int value);

		[DllImport ("ossia")]
		public static extern IntPtr ossia_value_create_char (char value);

		[DllImport ("ossia")]
		public static extern IntPtr ossia_value_create_string (string value);

		[DllImport ("ossia")]
		public static extern IntPtr ossia_value_create_tuple (IntPtr[] values, int size);


		[DllImport ("ossia")]
		public static extern void ossia_value_free (IntPtr value);


		[DllImport ("ossia")]
		public static extern ossia_type ossia_value_get_type (IntPtr type);

		[DllImport ("ossia")]
		public static extern int ossia_value_to_int (IntPtr val);

		[DllImport ("ossia")]
		public static extern float ossia_value_to_float (IntPtr val);

		[DllImport ("ossia")]
		public static extern bool ossia_value_to_bool (IntPtr val);

		[DllImport ("ossia")]
		public static extern char ossia_value_to_char (IntPtr val);

		[DllImport ("ossia")]
		public static extern string ossia_value_to_string (IntPtr val);

		[DllImport ("ossia")]
		public static extern void ossia_value_free_string (string str);

		[DllImport ("ossia")]
		public static extern void ossia_value_to_tuple (
			IntPtr val_in, 
			IntPtr val_out, 
			IntPtr size);
		
		[DllImport ("ossia")]
		public static extern void ossia_value_free_tuple (IntPtr tpl);


		[DllImport ("ossia")]
		public static extern int ossia_value_convert_int (IntPtr val);

		[DllImport ("ossia")]
		public static extern float ossia_value_convert_float (IntPtr val);

		[DllImport ("ossia")]
		public static extern int ossia_value_convert_bool (IntPtr val);

		[DllImport ("ossia")]
		public static extern char ossia_value_convert_char (IntPtr val);

		[DllImport ("ossia")]
		public static extern string ossia_value_convert_string (IntPtr val);

		[DllImport ("ossia")]
		public static extern void ossia_value_convert_tuple (
			IntPtr val_in, 
			IntPtr val_out, 
			IntPtr size);



		[DllImport ("ossia")]
		public static extern void ossia_string_free( IntPtr str );

		[DllImport ("ossia")]
		public static extern void ossia_set_debug_logger( IntPtr fp );
	}
}

