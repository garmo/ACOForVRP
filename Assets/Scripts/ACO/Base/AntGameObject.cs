﻿/* 
 * ACOForVRP is an open-source useful graphical desktop application for the application
 * of Improved Ant Colony Optimization technique for Vehicle Routing Problem.
 * More details on <https://github.com/garmo/ACOForVRP/blob/master/README.md>
 * Copyright (C) 2016 Fran García Moreno
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntGameObject<T,N,E> : MonoBehaviour where N:Node where E:ACOEdge<N> {
	//--------------------------------------
	// Setting Attributes
	//--------------------------------------
	[SerializeField]
	private Ant<T,N,E> ant;

	[SerializeField]
	private float movSpeed = 0.5f;

	//--------------------------------------
	// Private Attributes
	//--------------------------------------
	private Transform depot;
	private Transform destination;
	private bool canMove = false;
	private bool isCommingBack = false;
	private bool destinationReached = false;

	//--------------------------------------
	// Getters & Setters
	//--------------------------------------
	public bool IsCommingBack {
		get {
			return this.isCommingBack;
		}
	}

	public bool DestinationReached {
		get {
			return this.destinationReached;
		}
	}

	//--------------------------------------
	// Unity Methods
	//--------------------------------------
	protected virtual void Awake(){

	}

	protected virtual void Start () {
		
	}

	protected virtual void FixedUpdate () {
		if (canMove) {
			transform.position = Vector3.MoveTowards (transform.position, destination.position, Time.deltaTime * movSpeed);
			transform.rotation = Quaternion.LookRotation(Vector3.forward, destination.position - transform.position);
			destinationReached = Vector3.Distance (transform.position, destination.position) <= 0.1f;

			if (DestinationReached)
				canMove = false;
			
			if (isCommingBack && destinationReached) { //arrived to depot
				Destroy (gameObject);
			}
		}
	}

	//--------------------------------------
	// Public Methods
	//--------------------------------------
	public virtual void loadAnt(Ant<T,N,E> a, Transform pDestination, float pSpeed, Transform pDepot){
		destinationReached = false;
		ant = a;
		destination = pDestination;
		canMove = true;
		isCommingBack = false;
		movSpeed = pSpeed;
		depot = pDepot;
	}

	public virtual void comeBackToDepot(){
		destinationReached = false;
		isCommingBack = true;
		destination = depot;
		canMove = true;
	}

	public virtual void goToNextNode(Transform newDestination){
		destinationReached = false;
		destination = newDestination;
		canMove = true;
	}

	public virtual IEnumerator checkDestinationReached(){
		while(!DestinationReached)
			yield return DestinationReached;
	}

}
