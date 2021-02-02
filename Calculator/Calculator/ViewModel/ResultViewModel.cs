using Calculator.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace Calculator.ViewModel
{
    public class ResultViewModel : ViewModelBase
    {
        private string _result;
        public string Result
        {
            get
            {
                return _result;
            }
            private set
            {
                _result = value;
                RaisePropertyChanged("Result");
            }
        }

        public ResultViewModel()
        {
            Messenger.Default.Register<ViewModelMessage>(this, OnReceiveMessageAction);
        }

        private void OnReceiveMessageAction(ViewModelMessage obj)
        {
            Result = obj.Text;
        }
    }
}
