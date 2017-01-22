﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GGJ2017.Characters;

namespace GGJ2017.Rooms
{
    public class Room
    {
        public string Name { get; }

        private List<Room> _connections { get; } = new List<Room>();
        public IEnumerable<Room> Connections { get { return _connections; } }
        public IEnumerable<Room> UnlockedConnections { get { return _connections.Where(r => !r.Locked); } }

        private List<Character> _characters = new List<Character>();
        public List<Character> Characters { get; }

        public bool Locked { get; set; }

        public Room(string name)
        {
            Name = name;
        }

        public void ConnectTo(Room room)
        {
            _connections.Add(room);
            if (!room.Connections.Contains(this))
            {
                room.ConnectTo(this);
            }
        }
    }
}