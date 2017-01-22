using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GGJ2017.Interface;
using GGJ2017.Items;
using GGJ2017.Players;
using GGJ2017.Resources;
using GGJ2017.Rooms;

namespace GGJ2017
{
    public class GameManager
    {
        private RoomManager _roomManager = new RoomManager();
        private ItemManager _itemManager = new ItemManager();
        private InventoryManager _inventoryManager = new InventoryManager();
        private PlayerManager _playerManager = new PlayerManager();

        private LogManager _messageLog;
        private LogManager _friendLog;
        private LogManager _jerkLog;
        private ButtonManager _buttonManager;
        private DialogueManager _dialogueManager;

        private GameState _state = GameState.NotStarted;

        public GameManager(MainForm mainForm)
        {
            _messageLog = new LogManager(mainForm.HistoryListBox) { Formatter = null };
            _friendLog = new LogManager(mainForm.HistoryListBox);
            _jerkLog = new LogManager(mainForm.HistoryListBox);
            _buttonManager = new ButtonManager(mainForm.ButtonTablePanel);
            _dialogueManager = new DialogueManager(mainForm.PortraitPictureBox, mainForm.DialogueLabel);
            
            UpdateInterface(true);
        }

        public void StartGame()
        {
            _messageLog.Clear();
            _state = GameState.JerkTurn;

            UpdateInterface(true);
        }

        private void UpdateInterface(bool refreshLog=false)
        {
            UpdateButtons();
            if (refreshLog)
            {
                RefreshLog();
            }
        }

        private void RefreshLog()
        {
            switch (_state)
            {
                case GameState.NotStarted:
                case GameState.FriendSwappingOut:
                case GameState.FriendSwappingIn:
                case GameState.JerkSwappingOut:
                case GameState.JerkSwappingIn:
                case GameState.Ended:
                    _friendLog.Clear(false);
                    _dialogueManager.Display(TextManager.GameStateText[_state]);
                    break;
                case GameState.FriendTurn:
                    _dialogueManager.Clear();
                    _friendLog.Refresh();
                    break;
                case GameState.JerkTurn:
                    _dialogueManager.Clear();
                    _jerkLog.Refresh();
                    break;
            }
        }

        private void UpdateButtons()
        {
            _buttonManager.ClearButtons();

            switch (_state)
            {
                case GameState.NotStarted:
                    _buttonManager.AddButton("Start game", () => StartGame());
                    break;
                case GameState.JerkSwappingIn:
                    _buttonManager.AddButton("Start turn", () => { _state = GameState.JerkTurn; UpdateInterface(true); });
                    break;
                case GameState.FriendSwappingIn:
                    _buttonManager.AddButton("Start turn", () => { _state = GameState.FriendTurn; UpdateInterface(true); });
                    break;
                case GameState.JerkSwappingOut:
                    _buttonManager.AddButton("I am the friend", () => { _state = GameState.FriendSwappingIn; UpdateInterface(true); });
                    break;
                case GameState.FriendSwappingOut:
                    _buttonManager.AddButton("I am the jerk", () => { _state = GameState.JerkSwappingIn; UpdateInterface(true); });
                    break;
                case GameState.JerkTurn:
                case GameState.FriendTurn:
                    AddRoomButtons();
                    break;
            }
        }

        private void SwapFrom(PlayerType type)
        {
            if (type == PlayerType.Friend)
            {
                _state = GameState.FriendTurn;
            }
        }

        private void SwapTo(PlayerType type)
        {
            if (type == PlayerType.Friend)
            {
                _state = GameState.FriendTurn;
                UpdateButtons();
            }
        }
        
        private void AddRoomButtons()
        {
            var room = _roomManager.CurrentRoom;
            foreach (var connectedRoom in room.UnlockedConnections)
            {
                _buttonManager.AddButton($"Move to {connectedRoom.Name}", () => MoveToRoom(connectedRoom));
            }

            _buttonManager.AddButton("Pass turn", () => UseAllMoves());
        }

        private void MoveToRoom(Room room)
        {
            _roomManager.MoveToRoom(room);
            LogRoomMove(room, _playerManager.CurrentPlayer);
            UseMove();
            UpdateButtons();
        }

        private void LogRoomMove(Room room, PlayerType playerType)
        {
            string logMessage = $"Moved to {room.Name}.";
            if (playerType == PlayerType.Friend)
            {
                _friendLog.Add(logMessage);
            }
            else if (playerType == PlayerType.Jerk)
            {
                _jerkLog.Add(logMessage);
            }
        }

        private void UseMove() { UseMoves(1); }

        private void UseAllMoves() { UseMoves(_playerManager.MovesRemaining); }

        private void UseMoves(int numMoves)
        {
            bool refreshLog = false;
            _playerManager.MovesRemaining -= numMoves;
            if (_playerManager.MovesRemaining < 1)
            {
                _playerManager.SwapPlayers();
                if (_state == GameState.FriendTurn)
                {
                    _state = GameState.FriendSwappingOut;
                    refreshLog = true;
                }
                else if (_state == GameState.JerkTurn)
                {
                    _state = GameState.JerkSwappingOut;
                    refreshLog = true;
                }
            }
            UpdateInterface(refreshLog);
        }
    }
}
