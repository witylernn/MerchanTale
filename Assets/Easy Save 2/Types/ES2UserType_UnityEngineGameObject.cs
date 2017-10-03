using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ES2UserType_UnityEngineGameObject : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		UnityEngine.GameObject data = (UnityEngine.GameObject)obj;
		// Add your writer.Write calls here.
writer.Write(data.layer);
writer.Write(data.isStatic);
writer.Write(data.hideFlags);

	}
	
	public override object Read(ES2Reader reader)
	{
		UnityEngine.GameObject data = new UnityEngine.GameObject();
		Read(reader, data);
		return data;
	}

	public override void Read(ES2Reader reader, object c)
	{
		UnityEngine.GameObject data = (UnityEngine.GameObject)c;
		// Add your reader.Read calls here to read the data into the object.
data.layer = reader.Read<System.Int32>();
data.isStatic = reader.Read<System.Boolean>();
data.hideFlags = reader.Read<UnityEngine.HideFlags>();

	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_UnityEngineGameObject():base(typeof(UnityEngine.GameObject)){}
}