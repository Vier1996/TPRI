﻿using System.Collections.Generic;

namespace Bestiary
{
    public class InfoAboutIlnesses
    {
        private Dictionary<string, string> _listViruses;
        private Dictionary<string, List<string>> _listSymptoms;
        private Dictionary<string, int> _valueOfInfection;

        public InfoAboutIlnesses()
        {
            setViruses();
            setSymptoms();
            setValueInfection();
        }
        
        private void setViruses()
        {
            _listViruses = new Dictionary<string, string>();
            _listViruses.Add("1", "Some usefull information 1");
            _listViruses.Add("2", "Some usefull information 2");
            _listViruses.Add("3", "Some usefull information 3");
            _listViruses.Add("4", "Some usefull information 4");
            _listViruses.Add("5", "Some usefull information 5");
            _listViruses.Add("6", "Some usefull information 6");
            _listViruses.Add("7", "Some usefull information 7");
            _listViruses.Add("8", "Some usefull information 8");
            _listViruses.Add("9", "Some usefull information 9");
            _listViruses.Add("10", "Some usefull information 10");
            _listViruses.Add("11", "Some usefull information 11");
            _listViruses.Add("12", "Some usefull information 12");
            _listViruses.Add("13", "Some usefull information 13");
            _listViruses.Add("14", "Some usefull information 14");
            _listViruses.Add("15", "Some usefull information 15");
        }

        private void setSymptoms()
        {
            _listSymptoms = new Dictionary<string, List<string>>();
            _listSymptoms.Add("1", new List<string>() {"1: First", "1: Second"});
            _listSymptoms.Add("2", new List<string>() {"2: First", "2: Second"});
            _listSymptoms.Add("3", new List<string>() {"3: First", "3: Second"});
            _listSymptoms.Add("4", new List<string>() {"4: First", "4: Second"});
            _listSymptoms.Add("5", new List<string>() {"5: First", "5: Second"});
            _listSymptoms.Add("6", new List<string>() {"6: First", "6: Second"});
            _listSymptoms.Add("7", new List<string>() {"7: First", "7: Second"});
            _listSymptoms.Add("8", new List<string>() {"8: First", "8: Second"});
            _listSymptoms.Add("9", new List<string>() {"9: First", "9: Second"});
            _listSymptoms.Add("10", new List<string>() {"10: First", "10: Second"});
            _listSymptoms.Add("11", new List<string>() {"11: First", "11: Second"});
            _listSymptoms.Add("12", new List<string>() {"12: First", "12: Second"});
            _listSymptoms.Add("13", new List<string>() {"13: First", "13: Second"});
            _listSymptoms.Add("14", new List<string>() {"14: First", "14: Second"});
            _listSymptoms.Add("15", new List<string>() {"15: First", "15: Second"});
        }

        private void setValueInfection()
        {
            _valueOfInfection = new Dictionary<string, int>();
            _valueOfInfection.Add("1", 32);
            _valueOfInfection.Add("2", 25);
            _valueOfInfection.Add("3", 40);
            _valueOfInfection.Add("4", 37);
            _valueOfInfection.Add("5", 51);
            _valueOfInfection.Add("6", 44);
            _valueOfInfection.Add("7", 60);
            _valueOfInfection.Add("8", 55);
            _valueOfInfection.Add("9", 20);
            _valueOfInfection.Add("10", 10);
            _valueOfInfection.Add("11", 80);
            _valueOfInfection.Add("12", 77);
            _valueOfInfection.Add("13", 69);
            _valueOfInfection.Add("14", 88);
            _valueOfInfection.Add("15", 90);
        }

        public Dictionary<string, string> getViruses()
        {
            return _listViruses;
        }

        public Dictionary<string, List<string>> getSymptoms()
        {
            return _listSymptoms;
        }

        public Dictionary<string, int> getValueInfection()
        {
            return _valueOfInfection;
        }
    }
}