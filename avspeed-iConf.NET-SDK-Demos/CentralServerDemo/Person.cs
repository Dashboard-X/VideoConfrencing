using System;
using System.Collections.Generic;
using System.Text;

namespace CentralServerDemo
{
    public class Person
    {
        public Person()
        {
        }

        private string _Name;
        public string Name
        {
            //set the person name
            set { this._Name = value; }
            //get the person name 
            get { return this._Name; }
        }
    }
}
