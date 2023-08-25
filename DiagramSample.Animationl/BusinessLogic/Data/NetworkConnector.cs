using System;
using System.Windows;

namespace BusinessLogic.Data
{
    public class NetworkConnector : NotificationObject, INetworkItem
    {
        public Guid Id { get; set; }
        public Guid StartItemId { get; set; }
        public Guid EndItemId { get; set; }
        public Size Size { get; set; }
        public Point Position { get; set; }

        private bool _highlighted;

        public bool Highlighted
        {
            get => _highlighted;
            set => SetField(ref _highlighted, value, nameof(Highlighted));
        }

        public NetworkConnector()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"{Id} - Start: {StartItemId} - End: {EndItemId} ";
        }
    }
}
