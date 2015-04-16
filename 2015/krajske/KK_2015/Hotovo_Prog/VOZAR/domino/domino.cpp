/*
 * domino.cpp
 * 
 * Copyright 2015 root <root@jirvoz-X550VB>
 * 
 * This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
 * MA 02110-1301, USA.
 * 
 * 
 */


#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <vector>
#include <string>

using namespace std;

struct dilek
{
	int a; int b;
};

vector<dilek> dilky;
int vyskyty[6];

int nejvyskyt()
{
	int nej=0, max = 0;
	for (int i = 0; i < 6; i++)
		if (vyskyty[i] > max)
		{
			nej = i;
			max = vyskyty[i];
		}
	
	return nej + 1;
}

int main(int argc, char **argv)
{
	//načtení vstupu
	int a, b;
	while (scanf("[%d:%d]", &a, &b))
	{
		dilek dil;
		dil.a = a;
		dil.b = b;
		dilky.push_back(dil);
		vyskyty[a - 1]++;
		vyskyty[b - 1]++;
	}
	
	//zjistit číslo s nejvyšším výskytem
	int nejcislo = nejvyskyt();

	int posledni;
	//první kostka
	for (unsigned int i = 0; i < dilky.size(); i++)
	{
		if (dilky[i].a == nejcislo)
		{
			cout << "[" << dilky[i].b << ":" << dilky[i].a << "]";
			posledni = dilky[i].a;
			vyskyty[a - 1]--;
			vyskyty[b - 1]--;
			dilky.erase(dilky.begin() + i);
			break;
		}
		if (dilky[i].b == nejcislo)
		{
			cout << "[" << dilky[i].a << ":" << dilky[i].b << "]";
			posledni = dilky[i].b;
			vyskyty[a - 1]--;
			vyskyty[b - 1]--;
			dilky.erase(dilky.begin() + i);
			break;
		}
	}
	
	bool nalezeno;
	do
	{
		nalezeno = false;
		nejcislo = nejvyskyt();
		
		//hledat nejlepší pasující
		for (unsigned int i = 0; i < dilky.size(); i++)
		{
			if (dilky[i].b == posledni && dilky[i].a == nejcislo)
			{
				cout << "[" << dilky[i].b << ":" << dilky[i].a << "]";
				posledni = dilky[i].a;
				vyskyty[a - 1]--;
				vyskyty[b - 1]--;
				dilky.erase(dilky.begin() + i);
				nalezeno = true;
				break;
			}
			if (dilky[i].a == posledni && dilky[i].b == nejcislo)
			{
				cout << "[" << dilky[i].a << ":" << dilky[i].b << "]";
				posledni = dilky[i].b;
				vyskyty[a - 1]--;
				vyskyty[b - 1]--;
				dilky.erase(dilky.begin() + i);
				nalezeno = true;
				break;
			}
		}
		
		if (!nalezeno)
		//hledat pasující
		for (unsigned int i = 0; i < dilky.size(); i++)
		{
			if (dilky[i].b == posledni)
			{
				cout << "[" << dilky[i].b << ":" << dilky[i].a << "]";
				posledni = dilky[i].a;
				vyskyty[a - 1]--;
				vyskyty[b - 1]--;
				dilky.erase(dilky.begin() + i);
				nalezeno = true;
				break;
			}
			if (dilky[i].a == posledni)
			{
				cout << "[" << dilky[i].a << ":" << dilky[i].b << "]";
				posledni = dilky[i].b;
				vyskyty[a - 1]--;
				vyskyty[b - 1]--;
				dilky.erase(dilky.begin() + i);
				nalezeno = true;
				break;
			}
		}
	} while (nalezeno);
	
	cout << endl;
	
	return 0;
}

