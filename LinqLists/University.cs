using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqLists
{
    public class University
    {

        private int id;
        private String name;


        public University(int id, String name)
        {
            this.id = id;
            this.name = name;
        }
        public int getId()
        {
            return this.id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public String getName()
        {
            return this.name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public void print()
        {
            Console.WriteLine("University " + this.name + " with the id " + this.id);
        }
    }
}
