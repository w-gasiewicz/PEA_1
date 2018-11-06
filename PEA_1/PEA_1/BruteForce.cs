using System;
using System.Collections.Generic;

namespace PEA_1
{
    class BruteForce
    {
        private int[,] _citiesMatrix= Menu.citiesArray;// original matrix with distances between cities
        private List<bool> _visitedCities= new List<bool>(Menu.cityQua);//list for already visited cities
        private int _cost ,_actualCity=0;//help variables for cost and actual city
        private int _actualBestCost = Int32.MaxValue;
        private List<int> _route = new List<int>(Menu.cityQua+1);//list for the result path betwen cities
        private int[] _tempRoute = new int[Menu.cityQua];//help list for path
        private int bestRouteCost = 0;//variable for the result cost
        
        private void VisitCities(int startCity)
        {
            _tempRoute[_actualCity++] = startCity;//here we add destination to tempRoute array and increase actualCity
            
            if (_actualCity < Menu.cityQua)//if actual city exist in matrix
            {
                _visitedCities[startCity] = true;//we set destination city as visited
                for (int i = 0; i < Menu.cityQua; i++)
                {
                    if (!_visitedCities[i] && startCity!=i)//if city was not visited and destination!=i city
                    {
                        _cost += _citiesMatrix[startCity, i];//increase cost by value of cost from destination to i city
                        Console.Write(startCity + "->"+i+"->");
                        VisitCities(i);//we run function for city number i
                        Console.WriteLine();
                        _cost -= _citiesMatrix[startCity, i];//reduce cost by value of cost from destination to i city
                    }
                }
                _visitedCities[startCity] = false;
            }
            else if(startCity!=0)
            {
                _cost += _citiesMatrix[startCity, 0];//increase cost by value of cost from destination to 0

                if(_cost<_actualBestCost)//if we menaged to find better cost we optimize it
                {
                    _actualBestCost = _cost;
                    for (int i = 0; i < _actualCity; i++)//in this loop we copy tempRoute to the result route
                    {
                        _route[i] = _tempRoute[i];
                    }
                    bestRouteCost = _cost;//we set bestRouteCost 
                }
                _cost -= _citiesMatrix[startCity, 0];//reduce cost by value of cost from destination to 0
            }
            _actualCity--;//decrese of actualCity
        }
        public int BruteForceAlgorithm()
        {         
          for(int i=0;i<Menu.cityQua;i++)//here we fill visitedCities and route lists
            {
                _visitedCities.Add(false);
                _route.Add(0);
            }
            _route.Add(0);//add start city to route list
            VisitCities(0);//call function finding best path for start city
            return bestRouteCost;
        }
        public List<int> GetRoute()
        {
            return _route;
        }
    }
}
