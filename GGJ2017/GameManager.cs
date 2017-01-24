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
        private PlayerManager _playerManager = new PlayerManager();
        
        private LogManager _logManager;
        private ButtonManager _buttonManager;
        private DialogueManager _dialogueManager;
        private RoomManager _roomManager;
        private InventoryManager _inventoryManager;

        private GameState _state = GameState.NotStarted;

        public GameManager(MainForm mainForm)
        {
            _logManager = new LogManager(mainForm.HistoryListBox);
            _buttonManager = new ButtonManager(mainForm.ButtonTablePanel);
            _dialogueManager = new DialogueManager(mainForm.PortraitPictureBox, mainForm.DialogueLabel);
            _roomManager = new RoomManager(mainForm.RoomLabel);
            _inventoryManager = new InventoryManager(mainForm.InventoryTablePanel);

            UpdateInterface(true);
        }

        public void StartGame()
        {
            _logManager.Reset();
            _state = GameState.JerkTurn;
            _roomManager.CurrentRoom = _roomManager.Cabins;

            UpdateInterface(true);
        }

        private void UpdateInterface(bool refreshLog=false)
        {
            UpdateButtons();
            if (refreshLog)
            {
                RefreshLogAndDialogue();
            }
        }

        private void RefreshLogAndDialogue()
        {
            switch (_state)
            {
                case GameState.NotStarted:
                case GameState.FriendSwappingOut:
                case GameState.JerkSwappingOut:
                case GameState.Ended:
                    _dialogueManager.Display(TextManager.GameStateText[_state]);
                    break;
                case GameState.FriendSwappingIn:
                case GameState.JerkSwappingIn:
                    _logManager.Clear();
                    _dialogueManager.Display(TextManager.GameStateText[_state]);
                    break;
                case GameState.FriendTurn:
                    _dialogueManager.Clear();
                    _logManager.Refresh(PlayerType.Friend);
                    break;
                case GameState.JerkTurn:
                    _dialogueManager.Clear();
                    _logManager.Refresh(PlayerType.Jerk);
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
                case GameState.JerkSwappingOut:
                    _buttonManager.AddButton("Clear confidential information", () => SwapOut());
                    break;
                case GameState.FriendSwappingOut:
                    _buttonManager.AddButton("Clear confidential information", () => SwapOut());
                    break;
                case GameState.JerkSwappingIn:
                    _buttonManager.AddButton("I am a jerk", () => SwapIn());
                    break;
                case GameState.FriendSwappingIn:
                    _buttonManager.AddButton("I am a friend", () => SwapIn());
                    break;
                case GameState.JerkTurn:
                case GameState.FriendTurn:
                    AddTurnButtons();
                    break;
            }
        }

        private void AddTurnButtons()
        {
            var room = _roomManager.CurrentRoom;
            foreach (var connectedRoom in room.UnlockedConnections)
            {
                _buttonManager.AddButton($"Move to {connectedRoom.Name}", () => MoveToRoom(connectedRoom));
            }
            foreach (var item in room.Items)
            {
                _buttonManager.AddButton($"Pick up {item.Name.ToLower()}", () => PickUpItem(room, item));
            }
            _buttonManager.AddButton("Check inventory", () => CheckInventory());

            _buttonManager.AddButton("Pass turn", () => UseAllMoves());
        }

        private void SwapOut()
        {
            var playerType = _playerManager.CurrentPlayer;
            if (playerType == PlayerType.Friend)
            {
                _state = GameState.JerkSwappingIn;
            }
            else if (playerType == PlayerType.Jerk)
            {
                _state = GameState.FriendSwappingIn;
            }

            _playerManager.SwapPlayers();

            _inventoryManager.ShowInventory(false);

            UpdateInterface(true);
        }

        private void SwapIn()
        {
            var playerType = _playerManager.CurrentPlayer;
            if (playerType == PlayerType.Friend)
            {
                _state = GameState.FriendTurn;
            }
            else if (playerType == PlayerType.Jerk)
            {
                _state = GameState.JerkTurn;
            }

            UpdateInterface(true);
        }

        private void CheckInventory()
        {
            _inventoryManager.ShowInventory(true);

            string inventoryContents = "empty";
            if (_inventoryManager.Items.Any())
            {
                inventoryContents = string.Join(", ", _inventoryManager.Items.Select(i => i.Name));
            }

            _logManager.Add($"Checked inventory: { inventoryContents }", _playerManager.CurrentPlayer);
            _playerManager.CanSeeInventory = true;
            UseMove();
        }

        private void PickUpItem(Room room, Item item)
        {
            if (room.Items.Contains(item))
            {
                room.Items.Remove(item);
                _inventoryManager.AddItem(item, _playerManager.CanSeeInventory);
                LogPlayerAction($"Picked up {item.Name.ToLower()}.");
                UseMove();
            }
            else
            {
                UpdateInterface();
            }
        }

        private void MoveToRoom(Room room)
        {
            _roomManager.MoveToRoom(room);
            LogPlayerAction($"Moved to {room.Name}.");
            UseMove();
        }

        private void LogPlayerAction(string logMessage)
        {
            _logManager.Add(logMessage, _playerManager.CurrentPlayer);
        }

        private void UseMove() { UseMoves(1); }

        private void UseAllMoves() { UseMoves(_playerManager.MovesRemaining); }

        private void UseMoves(int numMoves)
        {
            _playerManager.MovesRemaining -= numMoves;

            bool refreshLog = false;
            if (_playerManager.MovesRemaining < 1)
            {
                refreshLog = true;
                EndTurn();
            }
            UpdateInterface(refreshLog);
        }

        private void EndTurn()
        {
            if (_state == GameState.FriendTurn)
            {
                _state = GameState.FriendSwappingOut;
            }
            else if (_state == GameState.JerkTurn)
            {
                _state = GameState.JerkSwappingOut;
            }

            _logManager.Add("-- end of turn -- ", _playerManager.CurrentPlayer, false);
        }
    }
}
