using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour {

	[SerializeField]
	GameObject mBody;
	[SerializeField]
	GameObject mFace;

	FaceController mFaceController;
	Vector2 mPos;
	float mSpeed;
	// for Accessibility
	private PlayerParameter kParam { get { return Parameter.Instance.Player; } }

	// Use this for initialization
	void Start () {
		mPos = transform.position;
		mSpeed = kParam.NeutralInitSpeed;
		mFaceController = new FaceController(mFace);
	}
	
	// Update is called once per frame
	void Update ()
    {
        mSpeed = Mathf.Min(mSpeed + kParam.NeutralAccel, kParam.NeutralHeadDegMax);
        // 当たり判定
        RaycastHit2D hitResult = Physics2D.CircleCast(mPos, kParam.BodyRadius, Vector2.right, mSpeed * Time.deltaTime);
        if (hitResult.collider != null)
        {
            mPos = hitResult.centroid;
        }
        else
        {
            mPos.x += mSpeed * Time.deltaTime;
        }
        // 移動
        transform.SetPositionAndRotation(mPos, Quaternion.identity);

     	mFaceController.Update(mPos, mSpeed);
    }
}
