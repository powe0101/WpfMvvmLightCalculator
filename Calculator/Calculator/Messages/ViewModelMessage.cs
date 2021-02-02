using GalaSoft.MvvmLight.Messaging;

namespace Calculator.Messages
{
    class ViewModelMessage : MessageBase
    {
        public string Text { get; set; }
    }
}
