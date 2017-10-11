using UnityEngine;

/// <summary>
/// Sphere behaviour class
/// </summary>
public class SphereBehaviour : MonoBehaviour
{
	#region Public Fields
	/// <summary>
	/// Custom asset file
	/// </summary>
	public SphereCustomAsset AssetFile;
	#endregion

	#region MonoBehaviour.Start
	/// <summary>
	/// Start is called on the frame when a script is enabled just 
	/// before any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		// Instantiate gameObject from custom asset file
		var go = Instantiate(AssetFile.GO, AssetFile.SpawnPosition, Quaternion.identity) as GameObject;

		// Set material color of the instantiated gameObject from custom asset file
		go.GetComponent<Renderer>().material.color = AssetFile.Color;
	}
	#endregion
}
