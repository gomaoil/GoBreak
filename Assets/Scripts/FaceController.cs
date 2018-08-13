using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceController {

    GameObject mFace;

    enum State {
        Neutral,
        HeadButt,
    }
    State mState;
    float mTimer;

	// for Accessibility
	private PlayerParameter kParam { get { return Parameter.Instance.Player; } }


    public FaceController(GameObject aFace)
    {
        mFace = aFace;
        mTimer = 0.0f;
    }

    public void Update(Vector2 aPos, float aSpeed)
    {
        switch (mState)
        {
            case State.Neutral:
                UpdateNeutral(aPos, aSpeed);
                break;
            case State.HeadButt:
                UpdateHeadButt(aPos, aSpeed);
                break;
        }
    }

    private void StartNeutral()
    {
        mState = State.Neutral;
        mFace.GetComponent<Renderer>().material.color = Color.white;
    }

    private void UpdateNeutral(Vector2 aPos, float aSpeed)
    {
        // 顔の位置計算
        float speedRate = Mathf.Clamp(aSpeed / kParam.NeutralSpeedMax, -1.0f, 1.0f);
        float faceAngle = -kParam.NeutralHeadDegMax * speedRate;

        mFace.transform.position = (Vector3)aPos + Quaternion.Euler(0, 0, faceAngle) * Vector3.up * kParam.FaceDistance;

        if (Input.GetMouseButton(0))
        {
            StartHeadButt();
        }
    }

    private void StartHeadButt()
    {
            mTimer = 0.0f;
            mState = State.HeadButt;
            mFace.GetComponent<Renderer>().material.color = Color.red;
    }

    private void UpdateHeadButt(Vector2 aPos, float aSpeed)
    {
        float speedRate;
        // 顔の位置計算
        if (mTimer < kParam.HeadbuttBackTime)
        {
            speedRate = Mathf.Lerp(0.0f, -1.0f, mTimer / kParam.HeadbuttBackTime);
        }
        else
        {
            speedRate = Mathf.Lerp(-1.0f, 1.0f, (mTimer - kParam.HeadbuttBackTime) / kParam.HeadbuttGoTime);

            if (kParam.HeadbuttBackTime + kParam.HeadbuttGoTime <= mTimer)
            {
                StartNeutral();
            }
        }
        mTimer += Time.deltaTime;
        float faceAngle = -kParam.HeadbuttHeadDegMax * speedRate;

        mFace.transform.position = (Vector3)aPos + Quaternion.Euler(0, 0, faceAngle) * Vector3.up * kParam.FaceDistance;
    }
}