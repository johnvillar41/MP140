using MP140.Interfaces;
using MP140.Models;
using System.Threading;

namespace MP140.Presenters
{
    public class TodoPresenter
    {
        private readonly ITodoView _view;
        private readonly ITodoRepository _repository;
        public TodoPresenter(ITodoView view, ITodoRepository repository)
        {
            _view = view;
            _repository = repository;
        }
        public void OnAddTodoItem(TodoModel newTodoItem)
        {
            Thread thread = new Thread(() =>
            {
                _view.DisplayProgressBar();
                _repository.AddTodoItem(newTodoItem);
                _view.HideProgressBar();
            });
            thread.Start();
        }
        public void OnViewUsers(int roomID)
        {
            Thread thread = new Thread(() =>
            {
                _view.DisplayProgressBar();
                var users = _repository.FetchAllUsersInARoom(roomID);
                _view.DisplayUsersInAGivenRoom(users);
                _view.HideProgressBar();
            });
            thread.Start();
        }
    }
}