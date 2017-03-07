using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GGJ2017.Characters;
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

        private Container _hidingInContainer = null;

        public GameManager(MainForm mainForm)
        {
            _logManager = new LogManager(mainForm.HistoryListBox, mainForm.HistoryLabel);
            _buttonManager = new ButtonManager(mainForm.ButtonTablePanel);
            _dialogueManager = new DialogueManager(mainForm.PortraitPictureBox, mainForm.DialogueLabel);
            _roomManager = new RoomManager(mainForm.RoomLabel);
            _inventoryManager = new InventoryManager(mainForm.InventoryTablePanel);

            UpdateInterface(true);
        }

        public void StartGame()
        {
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
                case GameState.JerkTurn:
                    string text = _playerManager.CurrentPlayer == PlayerType.Jerk ? TextManager.JerkInstructions : TextManager.FriendInstructions;

                    text = text
                        .Replace("{character}", _playerManager.CurrentTargetCharacter.Name.ToLower())
                        .Replace("{item}", _playerManager.CurrentTargetItem.Name.ToLower());

                    _dialogueManager.Display(text);
                    _logManager.Refresh(_playerManager.CurrentPlayer);
                    break;
            }
        }

        private void UpdateButtons()
        {
            _buttonManager.ClearButtons();

            if (_hidingInContainer != null)
            {
                AddHideItemButtons();
                return;
            }

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
                case GameState.Ended:
                    _buttonManager.AddButton("Reset game", () => ResetGame());
                    break;
            }
        }

        private void AddHideItemButtons()
        {
            var container = _hidingInContainer;

            foreach (var item in ItemManager.Items.Values.OrderBy(i => i.Name))
            {
                _buttonManager.AddButton($"Hide {item.Name.ToLower()} {container.Action} {container.Name.ToLower()}", () => HideItem(item.ItemType, container));
            }
            _buttonManager.AddButton($"Don't hide an item", () => CancelHideItem());
        }

        private void AddTurnButtons()
        {
            var room = _roomManager.CurrentRoom;
            foreach (var character in room.Characters)
            {
                var itemType = character.BefriendedItem;
                if (_playerManager.CurrentPlayer == PlayerType.Jerk)
                {
                    itemType = character.OffendedItem;
                }
                
                if (_playerManager.CurrentTargetCharacter.Id == character.Id && _inventoryManager.HasItem(itemType)) // maybe also check if _playerManager.CanSeeInventory?
                {
                    _buttonManager.AddButton($"Give {ItemManager.Items[itemType].Name.ToLower()} to the {character.Name.ToLower()}", () => GiveItem(character, itemType));
                }
                else
                {
                    _buttonManager.AddButton($"You can see a {character.Name.ToLower()} in this room", null);
                }
            }
            foreach (var connectedRoom in room.UnlockedConnections)
            {
                _buttonManager.AddButton($"Move to {connectedRoom.Name.ToLower()}", () => MoveToRoom(connectedRoom));
            }
            foreach (var item in room.Items)
            {
                _buttonManager.AddButton($"Pick up {item.Name.ToLower()}", () => PickUpItem(room, item));
            }
            foreach (var container in room.Containers)
            {
                _buttonManager.AddButton($"Search for items {container.Action} {container.Name.ToLower()}", () => SearchForItems(container));
                _buttonManager.AddButton($"Hide an item {container.Action} {container.Name.ToLower()}", () => HideItem(container));
            }
            _buttonManager.AddButton("Check inventory", () => CheckInventory());

            _buttonManager.AddButton("Pass turn", () => UseAllMoves());
        }

        private void SearchForItems(Container container)
        {
            if (container.Items.Any())
            {
                var items = container.RemoveItems();

                foreach (var item in items)
                {
                    _inventoryManager.AddItem(item, _playerManager.CanSeeInventory);
                }
                
                var itemList = string.Join(", ", items.Select(i => i.Name.ToLower()));
                _logManager.Add($"Searched for items {container.Action} {container.Name.ToLower()}: found {itemList}", _playerManager.CurrentPlayer);
            }
            else
            {
                _logManager.Add($"Searched for items {container.Action} {container.Name.ToLower()}: found none", _playerManager.CurrentPlayer);
            }
            UseMove();
        }

        private void HideItem(Container container)
        {
            _hidingInContainer = container;
            UpdateButtons();
        }

        private void CancelHideItem()
        {
            _hidingInContainer = null;
            UpdateButtons();
        }

        private void HideItem(ItemType itemType, Container container)
        {
            if (_inventoryManager.HasItem(itemType))
            {
                var item = _inventoryManager.Items.FirstOrDefault(i => i.ItemType == itemType);

                _inventoryManager.RemoveItem(item, _playerManager.CanSeeInventory);
                container.AddItem(item);
                _logManager.Add($"Hid {item.Name.ToLower()} {container.Action} {container.Name.ToLower()}", _playerManager.CurrentPlayer);
            }
            else
            {
                _logManager.Add($"You do not have {ItemManager.Items[itemType].Name.ToLower()} to hide", _playerManager.CurrentPlayer);
            }
            _hidingInContainer = null;
            UseMove();
        }

        private void GiveItem(Character character, ItemType itemType)
        {
            if (character.BefriendedItem == itemType)
            {
                _dialogueManager.Display(character, DialogueType.Befriended);
                _logManager.Add($"Befriended the {character.Name.ToLower()}! You won!", _playerManager.CurrentPlayer);
                EndGame();
            }
            else if (character.OffendedItem == itemType)
            {
                _dialogueManager.Display(character, DialogueType.Offended);
                _logManager.Add($"Offended the {character.Name.ToLower()}! You won!", _playerManager.CurrentPlayer);
                EndGame();
            }
            else
            {
                return;
            }
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
            _roomManager.MoveTo(room);
            LogPlayerAction($"Moved to {room.Name.ToLower()}.");
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

        private void EndGame()
        {
            _state = GameState.Ended;
            UpdateButtons();
        }

        private void ResetGame()
        {
            _roomManager.Reset();
            _inventoryManager.Reset();
            _playerManager.Reset();
            _logManager.Reset();
            _state = GameState.NotStarted;
            UpdateInterface(true);
        }
    }
}
