using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Utils
{
	static public int CalculatePower(int maxHp,
									 int damage,
									 int armor) 
	{
		return maxHp * 10 + damage * 20 + armor * 5;
	}
}
