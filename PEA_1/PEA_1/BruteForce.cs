using System;
using System.Collections.Generic;

namespace PEA_1
{
    class BruteForce
    {
        int c = 0;

        private int[,] _citiesMatrix= Menu.citiesArray;
        private List<bool> _visitedCities= new List<bool>(Menu.cityQua);
        private int _cost ,_actualCity=0;
        private int _actualCost = Int32.MaxValue;
        private List<int> _route = new List<int>(Menu.cityQua+1);
        private int[] _tempRoute = new int[Menu.cityQua];
        private int bestRouteCost = 0;
        
        private void VisitCities(int destination)
        {
            _tempRoute[_actualCity++] = destination;
            if (_actualCity < Menu.cityQua)
            {
                _visitedCities[destination] = true;
                for (int i = 0; i < Menu.cityQua; i++)
                {
                    c++;
                    if (!_visitedCities[i] && _citiesMatrix[destination, i] != 0)
                    {
                        _cost += _citiesMatrix[destination, i];
                        VisitCities(i);
                        _cost -= _citiesMatrix[destination, i];
                    }
                }
                _visitedCities[destination] = false;
            }
            else if(_citiesMatrix[0,destination]!=0)
            {
                _cost += _citiesMatrix[destination, 0];

                if(_cost<_actualCost)
                {
                    _actualCost = _cost;
                    for (int i = 0; i < _actualCity; i++)
                    {
                        c++;
                        _route[i] = _tempRoute[i];
                    }
                    bestRouteCost = _cost;
                }
                _cost -= _citiesMatrix[destination, 0];
            }
            _actualCity--;
        }
        public int BruteForceAlgorithm()
        {         
          for(int i=0;i<Menu.cityQua;i++)
            {
                _visitedCities.Add(false);
                _route.Add(0);
            }
            _route.Add(0);
            VisitCities(0);
            Console.WriteLine("test=" + c);
            return bestRouteCost;
        }
        public List<int> GetRoute()
        {
            return _route;
        }
    }
}
