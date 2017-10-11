using UnityEngine;

/// <summary>
/// Cube class
/// </summary>
public class CubeBehaviour : MonoBehaviour
{
	#region Public Fields
	/// <summary>
	/// Custom asset file
	/// </summary>
	public CubeCustomAsset AssetFile;
	#endregion

	#region MonoBehaviour.Start
	/// <summary>
	/// Start is called on the frame when a script is enabled just 
	/// before any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		// Set initial position of the cube gameObject from custom asset file
		this.transform.position = AssetFile.InitialPosition;

		// Set material of the cube gameObject from custom asset file
		this.gameObject.GetComponent<Renderer>().material = AssetFile.Material;
	}
	#endregion
}
