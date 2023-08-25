using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace BusinessLogic
{
    [XmlInclude(typeof(NetworkEntityNode)), XmlInclude(typeof(NetworkTransformationNode))]
    public class NetworkNode : NotificationObject,INetworkItem
    {
        public Guid Id { get; set; }
        public Size Size { get; set; }
        public Point Position { get; set; }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public NetworkFlowNodeType NodeType { get; set; }
        public byte[] Image { get; set; }



        private bool _highlighted;
        public bool Highlighted
        {
            get => _highlighted;
            set => SetField(ref _highlighted, value, nameof(Highlighted));
        }

        private ENodeWidth _width = ENodeWidth.Medium;
        public ENodeWidth Width
        {
            get => _width;
            set => SetField(ref _width, value, nameof(Width));
        }

        public NetworkNode()
        {
            Id = Guid.NewGuid();
        }



        private string _label;
        public string Label
        {
            get => _label;
            set { _label = value; OnPropertyChanged("Label"); }
        }

        [XmlIgnore]
        public IList<FormattedTextLine> DetailLines { get; set; } = new List<FormattedTextLine>();

        private ObservableCollection<FormattedTextLine> _visibleDetailLines;
        public ObservableCollection<FormattedTextLine> VisibleDetailLines
        {
            get => _visibleDetailLines;
            set
            {
                _visibleDetailLines = value;
                OnPropertyChanged("VisibleDetailLines");
            }
        }

        [XmlIgnore]
        public IList<DetailImage> DetailImages { get; set; } = new ObservableCollection<DetailImage>();

        private ObservableCollection<DetailImage> _visibleDetailImages;

        public ObservableCollection<DetailImage> VisibleDetailImages
        {
            get => _visibleDetailImages;
            set
            {
                _visibleDetailImages = value;
                OnPropertyChanged("VisibleDetailImages");
                OnPropertyChanged("VisibleCommentImage");
            }
        }

        public DetailImage VisibleCommentImage
        {
            get { return VisibleDetailImages.FirstOrDefault(x => x.DetailType == EDetailType.Comment); }
        }

        public FormattedTextLine VisibleCommentText
        {
            get { return VisibleDetailLines.FirstOrDefault(x => x.DetailType == EDetailType.Comment); }
        }

        public void UpdateVisibleDetails()
        {
            VisibleDetailLines = new ObservableCollection<FormattedTextLine>(DetailLines.Where(x => x.Visible));
            VisibleDetailImages = new ObservableCollection<DetailImage>(DetailImages.Where(x => x.Visible));
        }

        public override string ToString()
        {
            return $"{Id} - {Description}";
        }
    }

    public class NetworkEntityNode : NetworkNode
    {
        private string _title;
        public string Title
        {
            get => _title;
            set { _title = value; OnPropertyChanged(nameof(Title)); }
        }

        private byte[] _commentImage;
        public byte[] CommentImage
        {
            get => _commentImage;
            set
            {
                _commentImage = value;
                OnPropertyChanged("CommentImage");
            }
        }

        private byte[] _subtypeImage;
        public byte[] SubtypeImage
        {
            get => _subtypeImage;
            set
            {
                _subtypeImage = value;
                OnPropertyChanged("SubtypeImage");
            }
        }

        private LayerInfo _layerInfo;
        public LayerInfo LayerInfo
        {
            get => _layerInfo;
            set => SetField(ref _layerInfo, value, "LayerInfo");
        }

    }

    public class NetworkTransformationNode : NetworkNode
    {
        public Guid ParentId { get; set; }
        public Guid ChildId { get; set; }

        public string TechnicalName { get; set; }

        public string Routines { get; set; }

        public byte[] AbapImage { get; set; }

        private bool _isExpanded;
        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                _isExpanded = value;
                OnPropertyChanged("IsExpanded");
            }
        }

        public override string ToString()
        {
            return $"{Id} - {TechnicalName} -- Parent: {ParentId} - Child: {ChildId} ";
        }
    }

    public class DetailImage : NotificationObject
    {
        public byte[] Image { get; set; }

        public EDetailType DetailType { get; set; }

        private bool _visible = true;

        public bool Visible
        {
            get => _visible;
            set
            {
                _visible = value;
                OnPropertyChanged("Visible");
            }
        }

        public DetailImage()
        {

        }
        public DetailImage(byte[] image)
        {
            Image = image;
        }
    }

    public class FormattedTextLine : NotificationObject, IDisposable
    {
        private bool _visible;
        public bool Visible
        {
            get => _visible;
            set
            {
                _visible = value;
                OnPropertyChanged("Visible");
            }
        }


        public string Text { get; set; }
        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public int Indent { get; set; }
        public int PaddingTop { get; set; }
        public bool IsExportable { get; set; }

        public FormattedTextLine()
        {
            Visible = true;
            IsExportable = true;
        }

        #region properties added for Data Flow 2.0

        public EDetailType DetailType { get; set; }
        public byte[] ImageBytes { get; set; }
        public byte[] HeadImageBytes { get; set; }
        public bool Multiline { get; set; } = true;
        #endregion properties added for Data Flow 2.0

        #region IDisposable Members

        private bool _disposed;
        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
                DisposeManagedResources();
            DisposeUnManagedResources();
            _disposed = true;
        }

        private void DisposeManagedResources()
        {

        }

        private void DisposeUnManagedResources()
        {
        }

        ~FormattedTextLine()
        {
            Dispose(false);
        }

        #endregion
    }

    public class LayerInfo : NotificationObject
    {
        private Guid _id;
        private string _name;
        private int _colorArgb;
        private int _orderNo;

        public Guid Id
        {
            get => _id;
            set => SetField(ref _id, value, "Id");
        }

        public string Name
        {
            get => _name;
            set => SetField(ref _name, value, "Name");
        }

        public int ColorArgb
        {
            get => _colorArgb;
            set => SetField(ref _colorArgb, value, "ColorArgb");
        }

        public int OrderNo
        {
            get => _orderNo;
            set => SetField(ref _orderNo, value, "OrderNo");
        }
    }

    public interface INetworkItem
    {
        Guid Id { get; set; }
        Size Size { get; set; }
        Point Position { get; set; }
        bool Highlighted { get; set; }
    }

    public enum ENodeWidth
    {
        Large = 185,
        Medium = 120,
        Small = 100,
        ExtraSmall = 85,
        Pictogram = 20
    }

    public enum EDetailType
    {
        None,
        AbapScan,
        DtpScan,
        Comment
    }

    public enum NetworkFlowNodeType
    {
        Entity,
        Transformation
    }

}
