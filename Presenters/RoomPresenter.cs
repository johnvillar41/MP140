using MP140.Interfaces;
using MP140.Repositories;
using MP140.Views;
using System.Threading;

namespace MP140.Presenters
{
    public class RoomPresenter
    {
        private readonly IRoomView _view;
        private readonly IRoomRepository _repository;
        public RoomPresenter(IRoomView view,IRoomRepository repository)
        {
            _view = view;
            _repository = repository;
        }
        public void LoadRooms()
        {
            Thread thread = new Thread(() =>
            {
                var rooms = _repository.FetchAllRooms();
                _view.DisplayRooms(rooms);
            });
            thread.Start();
        }       
    }
}