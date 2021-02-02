using Calculator.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MathParser;
using System.Windows.Input;

namespace Calculator.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public string Expressions { get; set; }

        public ICommand Operation { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Operation = new RelayCommand<string>((argument) => Calculate(argument));
        }

        /// <summary>
        /// 입력한 수식을 계산하여 Locator를 이용해 Send 해준다.
        /// </summary>
        /// <param name="argument"></param>
        private void Calculate(string argument)
        {
            if (string.IsNullOrEmpty(Expressions))
                return;

            var temp = Evaluator.Evaluate(Expressions).ToDouble();
            
            var message = new ViewModelMessage()
            {
                Text = temp.ToString()
            };
   
            Messenger.Default.Send(message);
        }

    }
}