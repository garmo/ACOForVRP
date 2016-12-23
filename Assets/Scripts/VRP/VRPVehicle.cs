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

[System.Serializable]
public class VRPVehicle {
	public const int MIN_QUANTITY = 1;
	[SerializeField]
	private int quantity=1;

	public int Quantity {
		get {
			return this.quantity;
		}
		set{
			this.quantity = Mathf.Clamp (value, MIN_QUANTITY, int.MaxValue);
		}
	}

	public VRPVehicle():this(MIN_QUANTITY){}
	public VRPVehicle(VRPVehicle v):this(v.Quantity){}
	public VRPVehicle(int pQuantity){
		Quantity = pQuantity;
	}

	public override string ToString ()
	{
		return string.Format ("[VRPVehicle: quantity={0}]", quantity);
	}
	
}
