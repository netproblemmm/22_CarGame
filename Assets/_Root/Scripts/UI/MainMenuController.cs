using Profile;
using Tools;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UI
{
    internal class MainMenuController: BaseController
    {
        private readonly ResourcePath _resourcePath = new ResourcePath("Prefabs/MainMenu");
        private readonly ProfilePlayer _profilePlayer;
        private readonly MainMenuView _view;

        public MainMenuController(Transform placeForUI, ProfilePlayer profilePlayer)
        {
            _profilePlayer = profilePlayer;
            _view = LoadView(placeForUI);
            _view.Init(StartGame, Settings);
        }

        private MainMenuView LoadView(Transform placeForUI)
        {
            GameObject prefab = ResourcesLoader.LoadPrefab(_resourcePath);
            GameObject objectView = Object.Instantiate(prefab, placeForUI, false);
            AddGameObject(objectView);

            return objectView.GetComponent<MainMenuView>();
        }

        private void StartGame() =>
            _profilePlayer.State.Value = GameState.Game;

        private void Settings() =>
            _profilePlayer.State.Value = GameState.Settings;
    }
}