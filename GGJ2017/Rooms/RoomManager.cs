using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGJ2017.Rooms
{
    public class RoomManager
    {
        private Dictionary<RoomType, Room> _rooms = new Dictionary<RoomType, Room>();
        public IEnumerable<Room> Rooms { get { return _rooms.Values; } }

        public Room Cabins { get { return GetRoom(RoomType.Cabins); } }
        public Room Hallway { get { return GetRoom(RoomType.Hallway); } }
        public Room Deck { get { return GetRoom(RoomType.Deck); } }
        public Room DiningRoom { get { return GetRoom(RoomType.DiningRoom); } }
        public Room Ballroom { get { return GetRoom(RoomType.Ballroom); } }
        public Room Casino { get { return GetRoom(RoomType.Casino); } }
        public Room ArtGallery { get { return GetRoom(RoomType.ArtGallery); } }
        public Room RecRoom { get { return GetRoom(RoomType.RecRoom); } }
        public Room Closet { get { return GetRoom(RoomType.Closet); } }

        public Room CurrentRoom { get; private set; }

        public RoomManager()
        {
            CreateRooms();
            ConnectRooms();

            CurrentRoom = Cabins;
        }

        public Room GetRoom(RoomType type)
        {
            if (_rooms.ContainsKey(type))
            {
                return _rooms[type];
            }

            return null;
        }

        private void CreateRooms()
        {
            _rooms.Add(RoomType.Cabins, new Room("Cabins"));
            _rooms.Add(RoomType.Hallway, new Room("Hallway"));
            _rooms.Add(RoomType.Deck, new Room("Deck"));
            _rooms.Add(RoomType.DiningRoom, new Room("Dining Room"));
            _rooms.Add(RoomType.Ballroom, new Room("Ballroom"));
            _rooms.Add(RoomType.Casino, new Room("Casino"));
            _rooms.Add(RoomType.ArtGallery, new Room("Art Gallery"));
            _rooms.Add(RoomType.RecRoom, new Room("Recreation Room"));
            _rooms.Add(RoomType.Closet, new Room("Closet"));
        }

        private void ConnectRooms()
        {
            Cabins.ConnectTo(Hallway);
            Hallway.ConnectTo(RecRoom);
            Hallway.ConnectTo(Casino);
            Hallway.ConnectTo(ArtGallery);
            Hallway.ConnectTo(Deck);
            Casino.ConnectTo(DiningRoom);
            ArtGallery.ConnectTo(Closet);
            ArtGallery.ConnectTo(Ballroom);
            DiningRoom.ConnectTo(Deck);
            Ballroom.ConnectTo(Deck);
        }

        public void MoveToRoom(Room room)
        {
            CurrentRoom = room;
        }
    }
}
