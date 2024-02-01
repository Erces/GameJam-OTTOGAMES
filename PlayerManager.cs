using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	private List<FollowPlayer> PlayerList = new List<FollowPlayer>();

	private Camera cam;

	private PlayerManager pm;

	public LayerMask walkable;

	public LayerMask enemy;

	private void Start()
	{
		cam = Camera.main;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out var hitInfo, 200f, walkable))
		{
			Vector3 point = hitInfo.point;
			point.y = 0f;
			point.y = base.transform.localScale.y / 2f;
			SetTarget(point);
		}
		if (Input.GetMouseButtonDown(1) && Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out var hitInfo2, 200f, enemy))
		{
			GameObject target = hitInfo2.transform.gameObject;
			shootTarget(target);
		}
	}

	public void SetTarget(Vector3 target)
	{
		foreach (FollowPlayer player in PlayerList)
		{
			_ = target + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
			player.WalkTarget(target);
		}
	}

	private void shootTarget(GameObject target)
	{
		foreach (FollowPlayer player in PlayerList)
		{
			player.ShootTarget(target);
		}
	}

	public void AddCharacter(FollowPlayer me)
	{
		PlayerList.Add(me);
	}
}
