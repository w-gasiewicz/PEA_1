using System;
using System.Collections.Generic;

namespace PEA_1
{
    class BruteForce
    {
        private int[,] _citiesMatrix= Menu.citiesArray;// original matrix with distances between cities
        private List<bool> _visitedCities= new List<bool>(Menu.cityQua);//list for already visited cities
        private int _cost ,_actualCity=0;//help variables for cost and actual city
        private int _actualBestCost = Int32.MaxValue;//it will be a result cost of algorithm
        private List<int> _route = new List<int>(Menu.cityQua+1);//list for the result path betwen cities
        private int[] _tempRoute = new int[Menu.cityQua];//help list for path
        
        private void VisitCities(int startCity)
        {
            _tempRoute[_actualCity++] = startCity;//here we add destination to tempRoute array and increase actualCity
            
            if (_actualCity < Menu.cityQua)//if actual city exist in matrix
            {
                _visitedCities[startCity] = true;//we set destination city as visited
                for (int i = 0; i < Menu.cityQua; i++)
                {
                    if (!_visitedCities[i] && startCity!=i)//if city was not visited and startCity!=i city
                    {
                        _cost += _citiesMatrix[startCity, i];//increase cost by value of cost from startCity to i city
                        VisitCities(i);//we run function for city number i
                        _cost -= _citiesMatrix[startCity, i];//reduce cost by value of cost from startCity to i city
                    }
                }
                _visitedCities[startCity] = false;
            }
            else if(startCity!=0)
            {//we find hamilton cycle
                _cost += _citiesMatrix[startCity, 0];//increase cost by value of cost from destination to 0

                if(_cost<_actualBestCost)//if we menaged to find better cost we optimize it
                {
                    _actualBestCost = _cost; Console.WriteLine(_actualBestCost);
                    for (int i = 0; i < _actualCity; i++)//in this loop we copy tempRoute to the result route                
                        _route[i] = _tempRoute[i];
                }
                _cost -= _citiesMatrix[startCity, 0];//reduce cost by value of cost from startCity to 0
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
            return _actualBestCost;
        }
       
        public List<int> GetRoute()
        {
            return _route;
        }       
    }
}
