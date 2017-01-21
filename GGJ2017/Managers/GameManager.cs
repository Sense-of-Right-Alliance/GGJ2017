using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGJ2017.Managers
{
    public class GameManager
    {
        private LogManager _actionLog;
        private ButtonManager _buttonManager;

        public GameManager(MainForm mainForm)
        {
            _actionLog = new LogManager(mainForm.HistoryListBox);
            _buttonManager = new ButtonManager(mainForm.ButtonTablePanel);

            _buttonManager.AddButton("Start game", () => StartGame());
        }

        public void StartGame()
        {
            _actionLog.Clear();
            _buttonManager.ClearButtons();

            _buttonManager.AddButton("Browse reddit", () => _actionLog.Log("Browsed reddit."));
            _buttonManager.AddButton("Play patty-cake", () => _actionLog.Log("Played patty-cake."));
            _buttonManager.AddButton("Go home", () => _actionLog.Log("Went home."));
            _buttonManager.AddButton("Do nothing", () => _actionLog.Log("Did nothing."));
            _buttonManager.AddButton("Start over", () => _actionLog.Clear());
        }
    }
}
