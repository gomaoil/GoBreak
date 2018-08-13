using UnityEngine;

[CreateAssetMenu(menuName="GoBreak/Create Parameter", fileName="Parameter")]
public class PlayerParameter : ScriptableObject {
	public float BodyRadius = 1.0f;
	public float NeutralInitSpeed = 0.01f;
	public float NeutralAccel = 0.05f;
	public float NeutralSpeedMax = 5.0f;
	public float NeutralHeadDegMax = 30.0f;
	public float FaceDistance = 1.4f;

	public float HeadbuttBackTime = 0.2f;
	public float HeadbuttGoTime = 0.8f;
	public float HeadbuttHeadDegMax = 30.0f;
}
