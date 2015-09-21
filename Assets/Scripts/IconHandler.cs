﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IconHandler : MonoBehaviour {

	// TODO make work for both teams
	public int player;

	// Move icon
	public GameObject moveObject;
	public Texture moveIcon;
	public Texture moveActiveIcon;
	private RawImage moveRawImage;

	// Rotate icon
	public GameObject rotObject;
	public Texture rotIcon;
	public Texture rotActiveIcon;
	private RawImage rotRawImage;

	// Down icon
	public GameObject downObject;
	public Texture downIcon;
	public Texture downActiveIcon;
	public Texture downLeftIcon;
	public Texture downRightIcon;
	private RawImage downRawImage;

	private ControllerInterface ci = new ControllerInterface();

	void Start(){
		moveRawImage = (RawImage) moveObject.GetComponent<RawImage>();
		rotRawImage = (RawImage) rotObject.GetComponent<RawImage>();
		downRawImage = (RawImage) downObject.GetComponent<RawImage>();
	}

	void Update() {
		if ( ci.MoveLeft (team)) {
			moveRawImage.texture = moveActiveIcon;
		} 
//		else if ( ci.MoveRight (team)) {
//			moveRawImage.texture = moveActiveIcon;
//		} 
		else {
			moveRawImage.texture = moveIcon;
		}

		if ( ci.RotLeft (team)) {
			rotRawImage.texture = rotActiveIcon;
		} else if ( ci.RotRight (team)) {
			rotRawImage.texture = rotActiveIcon;
		} else {
			rotRawImage.texture = rotIcon;
		}

		if ( ci.ActionButtonCombined (team)) {
			downRawImage.texture = downActiveIcon;
		} else if ( ci.ActionButton (team, 1)) {
			downRawImage.texture = downLeftIcon;
		} else if ( ci.ActionButton (team, 2)) {
			downRawImage.texture = downRightIcon;
		} else {
			downRawImage.texture = downIcon;
		}

		moveRawImage.transform.eulerAngles = new Vector3(0, 0, -40 *  ci.MoveTilt(team));
		rotRawImage.transform.eulerAngles = new Vector3(0, 0, -45 *  ci.RotTilt(team));
	}
}
