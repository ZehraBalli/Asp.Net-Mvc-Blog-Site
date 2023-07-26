using System;

namespace WebApplication15.Models.Model
{
    internal class TableAttribute : Attribute
    {
        private string v;

        public TableAttribute(string v)
        {
            this.v = v;
        }
    }
}