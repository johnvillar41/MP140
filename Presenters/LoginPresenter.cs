using MP140.Interfaces;
using MP140.Models;
using System.Threading;

namespace MP140.Presenters
{
    public class LoginPresenter
    {
        private readonly ILoginView _view;
        private readonly ILoginRepository _repository;
        public LoginPresenter(ILoginView view, ILoginRepository repository)
        {
            _view = view;
            _repository = repository;
        }
        public void OnLogin(string username, string password)
        {
            Thread thread = new Thread(() =>
            {
                _view.DisplayProgressbar();
                var isLoginAccepted = _repository.CheckUserLoggedIn(username, password);
                if (isLoginAccepted)
                {
                    _view.RedirectToRoomView();
                    return;
                }
                _view.DisplayErrorMessage();
                _view.HideProgressBar();
            });
        }
        public void OnRegister(UserModel newUser)
        {
            Thread thread = new Thread(() =>
            {
                _view.DisplayProgressbar();
                _repository.RegisterUser(newUser);
                _view.HideProgressBar();
            });
            thread.Start();
        }
    }
}