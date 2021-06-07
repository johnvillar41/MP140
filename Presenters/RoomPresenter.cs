using MP140.Interfaces;
using MP140.Models;
using System.Threading;

namespace MP140.Presenters
{
    public class RoomPresenter
    {
        private readonly IRoomView _view;
        private readonly IRoomRepository _repository;
        public RoomPresenter(IRoomView view, IRoomRepository repository)
        {
            _view = view;
            _repository = repository;
        }
        public void LoadRooms()
        {
            Thread thread = new Thread(() =>
            {
                _view.DisplayProgressbar();
                var rooms = _repository.FetchAllRooms();
                _view.DisplayRooms(rooms);
                _view.HideProgressBar();
            });
            thread.Start();
        }
        public void OnAddNewRoom(RoomModel newRoom)
        {
            Thread thread = new Thread(() =>
            {
                _view.DisplayProgressbar();
                _repository.AddNewRoom(newRoom);
                _view.HideProgressBar();
            });
            thread.Start();
        }
        public void OnRoomClicked(int roomID)
        {            
            _view.RedirectToTodoView(roomID);           
        }
    }
}