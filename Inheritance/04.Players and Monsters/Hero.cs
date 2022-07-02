using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {
        public string UserName { get; set; }
        public int Level { get; set; }

        public Hero(string userName, int level)
        {
            UserName = userName;
            Level = level;
        }
        public override string ToString()
        {
             return $"Type: {this.GetType().Name} Username: {this.UserName} Level: {this.Level}";
        }
    }
}
