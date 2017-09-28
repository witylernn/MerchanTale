using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ES2UserType_Plant : ES2Type
{
	public override void Write(object obj, ES2Writer writer)
	{
		Plant data = (Plant)obj;
		// Add your writer.Write calls here.
writer.Write(data.life);writer.Write(data.plantType);writer.Write(data.useGUILayout);
writer.Write(data.enabled);
writer.Write(data.hideFlags);

	}
	
	public override object Read(ES2Reader reader)
	{
		Plant data = GetOrCreate<Plant>();
		Read(reader, data);
		return data;
	}

	public override void Read(ES2Reader reader, object c)
	{
		Plant data = (Plant)c;
		// Add your reader.Read calls here to read the data into the object.
data.life = reader.Read<System.Int32>();
data.plantType = reader.Read<System.Int32>();
data.useGUILayout = reader.Read<System.Boolean>();
data.enabled = reader.Read<System.Boolean>();
data.hideFlags = reader.Read<UnityEngine.HideFlags>();

	}
	
	/* ! Don't modify anything below this line ! */
	public ES2UserType_Plant():base(typeof(Plant)){}
}