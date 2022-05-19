using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AquariusMax.UPF
{
public class PlayerResources : MonoBehaviour {

	public static int Gold;
	public int startingGold = 15;

	public static int Wood;
	public int startingWood = 0;

	public static int Stone;
	public int startingStone = 0;


	void Start ()
	{
		Gold = startingGold;
		Wood = startingWood;
		Stone = startingStone;
	}

}
}
