using UnityEngine;
using System;
public static class ExtensionMethods
{
	/*
	 * In C# you can write extension methods. To write an extension method just create a static
	 * method with 'this' before the first parameter. Now, Rotate(float degrees) can be called
	 * on any Vector 2 within the namespace.
	 * 
	 * Here is a link to a guide to extension methods in C#:
	 * https://msdn.microsoft.com/en-us/library/bb383977.aspx
	 */
	public static Vector2 Rotate(this Vector2 v, float degrees) {
		float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
		float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

		float tx = v.x;
		float ty = v.y;
		v.x = (cos * tx) - (sin * ty);
		v.y = (sin * tx) + (cos * ty);
		return v;
	}
}