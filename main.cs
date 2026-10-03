using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum TdType
{
	HG,		//Handgun, pisztoly, maroklőfegyver
	SMG,	//Submachinegun, géppisztoly, kisgépfegyver
	AR,		//Assaultrifle, gépkarabély, rohampuska
	RF,		//Rifle, puska
	MG,		//Machinegun, géppuska
	SG		//Shotgun, sörétespuska
}

class Index
{
	public int Id { get; set; }
	public string Name { get; set; }
	public TdType Type { get; set; }
	public int Rarity { get; set; }
	//statok
	public int MaxHP { get; set; }
	public int ARM { get; set; }
	public int DMG { get; set; }
	public int ACC { get; set; }
	public int EVA { get; set; }
	public int ROF { get; set; }
	public int Crit_R { get; set; }
	public int Crit_D { get; set; }
	public int Mag {  get; set; }
	public int Max_ROF { get; set; }
	//egyéb
	public string Szemelyiseg {  get; set; }
	///public Skill skill { get; set; }


}

class Doll
{
	public int Id { get; set; }
	public Index Ki { get; set; }
	public int Rarity {  set; get; }
	public int LV { set; get; }
	public int Dummy { get; set; }
	public int Aff {  get; set; }
	public int 
	
}


class main
{



}
