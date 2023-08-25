using DevExpress.Diagram.Core.Localization;

namespace CPS.WPFDiagram
{
    public class DiagramControlLocalizerEx : DiagramControlLocalizer
    {
        private void AddStrings()
        {
            AddString(DiagramControlStringId.ContextMenu_View, "视图");
            AddString(DiagramControlStringId.ContextMenu_Order, "排序");
            AddString(DiagramControlStringId.ContextMenu_Move_Up, "上移");
            AddString(DiagramControlStringId.ContextMenu_Move_Down, "下移");
            AddString(DiagramControlStringId.ContextMenu_Close, "关闭"); //Close
            AddString(DiagramControlStringId.ContextMenu_Icons_And_Names, "图标和名称"); //Icons And Names
            AddString(DiagramControlStringId.ContextMenu_Names_Under_Icons, "名称在图标下方"); //Names Under Icons
            AddString(DiagramControlStringId.ContextMenu_Icons_Only, "仅图标"); //Icons Only
            AddString(DiagramControlStringId.ContextMenu_Names_Only, "仅名称"); //Names Only
            AddString(DiagramControlStringId.Menu_AllowLiveResizing_Button, "实时调整大小"); //Live resizing
            AddString(DiagramControlStringId.Menu_SnapToGrid_Button, "吸附到网格"); //Snap to grid
            AddString(DiagramControlStringId.Menu_SnapToItems_Button, "吸附到元素"); //Snap to items
            AddString(DiagramControlStringId.Menu_AllowEmptySelection_Button, "允许空选择"); //Empty selection
            AddString(DiagramControlStringId.Menu_SnapDistance_Editor, "吸附距离"); //Snap distance
            AddString(DiagramControlStringId.ToolDisplayFormat, "{0} 工具"); //{0} tool
            AddString(DiagramControlStringId.Tool_Pointer, "指针"); //Pointer
            AddString(DiagramControlStringId.Tool_Connector, "连接器"); //Connector
            AddString(DiagramControlStringId.Tool_Pan, "平移"); //Pan
            AddString(DiagramControlStringId.Tool_Text, "文本"); //Text
            AddString(DiagramControlStringId.MeasureUnit_Pixels, "像素"); //Pixels
            AddString(DiagramControlStringId.MeasureUnit_Inches, "英寸"); //Inches
            AddString(DiagramControlStringId.MeasureUnit_Millimeters, "毫米"); //Millimeters
            AddString(DiagramControlStringId.MeasureUnit_Pixels_Shorthand, "px");
            AddString(DiagramControlStringId.MeasureUnit_Millimeters_Shorthand, "mm");
            AddString(DiagramControlStringId.MeasureUnit_Inches_Shorthand, "in.");
            AddString(DiagramControlStringId.MeasureUnit_Degrees_Shorthand, "度"); //deg
            AddString(DiagramControlStringId.Themes_Office_Name, "Office");
            AddString(DiagramControlStringId.Themes_Linear_Name, "Linear");
            AddString(DiagramControlStringId.Themes_NoTheme_Name, "无主题"); //No Theme
            AddString(DiagramControlStringId.Themes_Integral_Name, "Integral");
            AddString(DiagramControlStringId.Themes_Daybreak_Name, "Daybreak");
            AddString(DiagramControlStringId.Themes_Parallel_Name, "Parallel");
            AddString(DiagramControlStringId.Themes_Sequence_Name, "Sequence");
            AddString(DiagramControlStringId.Themes_Lines_Name, "Lines");
            AddString(DiagramControlStringId.Themes_VariantStyleId_Name, "变体 {0}"); //Variant {0}
            AddString(DiagramControlStringId.Themes_ThemeStyleId_Name, "{0} 效果，强调色 {1}"); //{0} Effect, Accent {1}
            AddString(DiagramControlStringId.Themes_SubtleEffect_Name, "低调"); //Subtle
            AddString(DiagramControlStringId.Themes_RefinedEffect_Name, "精细"); //Refined
            AddString(DiagramControlStringId.Themes_BalancedEffect_Name, "平衡"); //Balanced
            AddString(DiagramControlStringId.Themes_ModerateEffect_Name, "适度"); //Moderate
            AddString(DiagramControlStringId.Themes_FocusedEffect_Name, "重点"); //Focused
            AddString(DiagramControlStringId.Themes_IntenseEffect_Name, "强烈"); //Intense
            AddString(DiagramControlStringId.Search_Shapes_Null_Text, "搜索形状..."); //Search shapes...
            AddString(DiagramControlStringId.QuickShapes_Name, "快速形状"); //Quick Shapes
            AddString(DiagramControlStringId.Stencils_Name, "画板"); //STENCILS
            AddString(DiagramControlStringId.No_Stencils_Open_Name, "没有打开的画板。"); //There are no stencils open.
            AddString(DiagramControlStringId.No_Shapes_Found_Name, "没有匹配项"); //No matches
            AddString(DiagramControlStringId.More_Shapes_Name, "更多形状"); //More Shapes
            AddString(DiagramControlStringId.Panel_Shapes_Name, "形状"); //Shapes
            AddString(DiagramControlStringId.Panel_Properties_Name, "属性");
            AddString(DiagramControlStringId.BasicShapes_Name, "基本形状"); //Basic Shapes
            AddString(DiagramControlStringId.BasicShapes_Rectangle_Name, "矩形"); //Rectangle
            AddString(DiagramControlStringId.BasicShapes_Ellipse_Name, "椭圆形"); //Ellipse
            AddString(DiagramControlStringId.BasicShapes_Triangle_Name, "三角形"); //Triangle
            AddString(DiagramControlStringId.BasicShapes_RightTriangle_Name, "直角三角形"); //Right Triangle
            AddString(DiagramControlStringId.BasicShapes_Pentagon_Name, "五边形"); //Pentagon
            AddString(DiagramControlStringId.BasicShapes_Hexagon_Name, "六边形"); //Hexagon
            AddString(DiagramControlStringId.BasicShapes_Heptagon_Name, "七边形"); //Heptagon
            AddString(DiagramControlStringId.BasicShapes_Octagon_Name, "八边形"); //Octagon
            AddString(DiagramControlStringId.BasicShapes_Decagon_Name, "十边形"); //Decagon
            AddString(DiagramControlStringId.BasicShapes_Can_Name, "圆柱"); //Can
            AddString(DiagramControlStringId.BasicShapes_Parallelogram_Name, "平行四边形"); //Parallelogram
            AddString(DiagramControlStringId.BasicShapes_Trapezoid_Name, "梯形"); //Trapezoid
            AddString(DiagramControlStringId.BasicShapes_Diamond_Name, "菱形"); //Diamond
            AddString(DiagramControlStringId.BasicShapes_Cross_Name, "十字架"); //Cross
            AddString(DiagramControlStringId.BasicShapes_Chevron_Name, "人字形"); //Chevron
            AddString(DiagramControlStringId.BasicShapes_Cube_Name, "立方体"); //Cube
            AddString(DiagramControlStringId.BasicShapes_Star4_Name, "四角星"); //4-Point Star
            AddString(DiagramControlStringId.BasicShapes_Star5_Name, "五角星"); //5-Point Star
            AddString(DiagramControlStringId.BasicShapes_Star6_Name, "六角星"); //6-Point Star
            AddString(DiagramControlStringId.BasicShapes_Star7_Name, "七角星"); //7-Point Star
            AddString(DiagramControlStringId.BasicShapes_Star16_Name, "十六角星"); //16-Point Star
            AddString(DiagramControlStringId.BasicShapes_Star24_Name, "二十四角星"); //24-Point Star
            AddString(DiagramControlStringId.BasicShapes_Star32_Name, "三十二角星"); //32-Point Star
            AddString(DiagramControlStringId.BasicShapes_RoundedRectangle_Name, "圆角矩形"); //Rounded Rectangle
            AddString(DiagramControlStringId.BasicShapes_SingleSnipCornerRectangle_Name, "单剪切角矩形"); //Single Snip Corner Rectangle
            AddString(DiagramControlStringId.BasicShapes_SnipSameSideCornerRectangle_Name, "同侧剪切角矩形"); //Snip Same Side Corner Rectangle
            AddString(DiagramControlStringId.BasicShapes_SnipDiagonalCornerRectangle_Name, "对角剪切角矩形"); //Snip Diagonal Corner Rectangle
            AddString(DiagramControlStringId.BasicShapes_SingleRoundCornerRectangle_Name, "单圆角矩形"); //Single Round Corner Rectangle
            AddString(DiagramControlStringId.BasicShapes_RoundSameSideCornerRectangle_Name, "同侧圆角矩形"); //Round Same Side Corner Rectangle
            AddString(DiagramControlStringId.BasicShapes_RoundDiagonalCornerRectangle_Name, "对角圆角矩形"); //Round Diagonal Corner Rectangle
            AddString(DiagramControlStringId.BasicShapes_SnipAndRoundSingleCornerRectangle_Name, "剪切和圆角单角矩形"); //Snip And Round Single Corner Rectangle
            AddString(DiagramControlStringId.BasicShapes_SnipCornerRectangle_Name, "剪切角矩形"); //Snip Corner Rectangle
            AddString(DiagramControlStringId.BasicShapes_RoundCornerRectangle_Name, "圆角矩形"); //Round Corner Rectangle
            AddString(DiagramControlStringId.BasicShapes_SnipAndRoundCornerRectangle_Name, "剪切和圆角矩形"); //Snip And Round Corner Rectangle
            AddString(DiagramControlStringId.BasicShapes_Plaque_Name, "牌匾"); //Plaque
            AddString(DiagramControlStringId.BasicShapes_Frame_Name, "框架"); //Frame
            AddString(DiagramControlStringId.BasicShapes_FrameCorner_Name, "框架角"); //Frame Corner
            AddString(DiagramControlStringId.BasicShapes_LShape_Name, "L形"); //L Shape
            AddString(DiagramControlStringId.BasicShapes_DiagonalStripe_Name, "斜条纹"); //Diagonal Stripe
            AddString(DiagramControlStringId.BasicShapes_Donut_Name, "甜甜圈"); //Donut
            AddString(DiagramControlStringId.BasicShapes_NoSymbol_Name, "无符号"); //NoSymbol
            AddString(DiagramControlStringId.BasicShapes_LeftParenthesis_Name, "左圆括号"); //Left Parenthesis
            AddString(DiagramControlStringId.BasicShapes_RightParenthesis_Name, "右圆括号"); //Right Parenthesis
            AddString(DiagramControlStringId.BasicShapes_LeftBrace_Name, "左花括号"); //Left Brace
            AddString(DiagramControlStringId.BasicShapes_RightBrace_Name, "右花括号"); //Right Brace
            AddString(DiagramControlStringId.BasicFlowchartShapes_Name, "基本流程图形"); //Basic Flowchart Shapes
            AddString(DiagramControlStringId.BasicFlowchartShapes_Process_Name, "处理"); //Process
            AddString(DiagramControlStringId.BasicFlowchartShapes_Decision_Name, "决策"); //Decision
            AddString(DiagramControlStringId.BasicFlowchartShapes_Subprocess_Name, "子处理"); //Subprocess
            AddString(DiagramControlStringId.BasicFlowchartShapes_StartEnd_Name, "开始/结束"); //Start/End
            AddString(DiagramControlStringId.BasicFlowchartShapes_Document_Name, "文档"); //Document
            AddString(DiagramControlStringId.BasicFlowchartShapes_Data_Name, "数据"); //Data
            AddString(DiagramControlStringId.BasicFlowchartShapes_Database_Name, "数据库"); //Database
            AddString(DiagramControlStringId.BasicFlowchartShapes_ExternalData_Name, "外部数据"); //External Data
            AddString(DiagramControlStringId.BasicFlowchartShapes_Custom1_Name, "自定义1"); //Custom1
            AddString(DiagramControlStringId.BasicFlowchartShapes_Custom2_Name, "自定义2"); //Custom2
            AddString(DiagramControlStringId.BasicFlowchartShapes_Custom3_Name, "自定义3"); //Custom3
            AddString(DiagramControlStringId.BasicFlowchartShapes_Custom4_Name, "自定义4"); //Custom4
            AddString(DiagramControlStringId.BasicFlowchartShapes_OnPageReference_Name, "页面内引用"); //On-page reference
            AddString(DiagramControlStringId.BasicFlowchartShapes_OffPageReference_Name, "跨页引用"); //Off-page reference
            AddString(DiagramControlStringId.SDLDiagramShapes_Name, "SDL 图形"); //SDL Diagram Shapes
            AddString(DiagramControlStringId.SDLDiagramShapes_Start_Name, "开始"); //Start
            AddString(DiagramControlStringId.SDLDiagramShapes_VariableStart_Name, "变量开始"); //Variable Start
            AddString(DiagramControlStringId.SDLDiagramShapes_Procedure_Name, "过程"); //Procedure
            AddString(DiagramControlStringId.SDLDiagramShapes_VariableProcedure_Name, "变量过程"); //Variable Procedure
            AddString(DiagramControlStringId.SDLDiagramShapes_CreateRequest_Name, "创建请求"); //CreateRequest
            AddString(DiagramControlStringId.SDLDiagramShapes_Alternative_Name, "替代"); //Alternative
            AddString(DiagramControlStringId.SDLDiagramShapes_Return_Name, "返回"); //Return
            AddString(DiagramControlStringId.SDLDiagramShapes_Decision1_Name, "决策1"); //Decision1
            AddString(DiagramControlStringId.SDLDiagramShapes_MessageFromUser_Name, "用户信息"); //Message from user
            AddString(DiagramControlStringId.SDLDiagramShapes_PrimitiveFromCallControl_Name, "来自呼叫控制的原语"); //Primitive from call control
            AddString(DiagramControlStringId.SDLDiagramShapes_Decision2_Name, "决策2"); //Decision2
            AddString(DiagramControlStringId.SDLDiagramShapes_MessageToUser_Name, "发送给用户的消息"); //Message to user
            AddString(DiagramControlStringId.SDLDiagramShapes_PrimitiveToCallControl_Name, "送往呼叫控制的原语"); //Primitive to call control
            AddString(DiagramControlStringId.SDLDiagramShapes_Save_Name, "保存"); //Save
            AddString(DiagramControlStringId.SDLDiagramShapes_OnPageReference_Name, "页面内引用"); //On page reference
            AddString(DiagramControlStringId.SDLDiagramShapes_OffPageReference_Name, "跨页引用"); //Off page reference
            AddString(DiagramControlStringId.SDLDiagramShapes_Document_Name, "文档"); //Document
            AddString(DiagramControlStringId.SDLDiagramShapes_DiskStorage_Name, "磁盘存储"); //Disk storage
            AddString(DiagramControlStringId.SDLDiagramShapes_DividedProcess_Name, "分裂的过程"); //Divided process
            AddString(DiagramControlStringId.SDLDiagramShapes_DividedEvent_Name, "分裂事件"); //Divided event
            AddString(DiagramControlStringId.SDLDiagramShapes_Terminator_Name, "终止器"); //Terminator
            AddString(DiagramControlStringId.SoftwareIcons_Name, "软件图标"); //Software Icons
            AddString(DiagramControlStringId.SoftwareIcons_Back_Name, "返回"); //Back
            AddString(DiagramControlStringId.SoftwareIcons_Forward_Name, "前进"); //Forward
            AddString(DiagramControlStringId.SoftwareIcons_Expand_Name, "展开"); //Expand
            AddString(DiagramControlStringId.SoftwareIcons_Collapse_Name, "折叠"); //Collapse
            AddString(DiagramControlStringId.SoftwareIcons_Add_Name, "添加"); //Add
            AddString(DiagramControlStringId.SoftwareIcons_Remove_Name, "移除"); //Remove
            AddString(DiagramControlStringId.SoftwareIcons_ZoomIn_Name, "放大"); //ZoomIn
            AddString(DiagramControlStringId.SoftwareIcons_ZoomOut_Name, "缩小"); //ZoomOut
            AddString(DiagramControlStringId.SoftwareIcons_Lock_Name, "锁定"); //Lock
            AddString(DiagramControlStringId.SoftwareIcons_Permission_Name, "权限"); //Permission
            AddString(DiagramControlStringId.SoftwareIcons_Sort_Name, "排序"); //Sort
            AddString(DiagramControlStringId.SoftwareIcons_Filter_Name, "过滤"); //Filter
            AddString(DiagramControlStringId.SoftwareIcons_Tools_Name, "工具"); //Tools
            AddString(DiagramControlStringId.SoftwareIcons_Properties_Name, "属性"); //Properties
            AddString(DiagramControlStringId.SoftwareIcons_Calendar_Name, "日历"); //Calendar
            AddString(DiagramControlStringId.SoftwareIcons_Document_Name, "文档"); //Document
            AddString(DiagramControlStringId.SoftwareIcons_Database_Name, "数据库"); //Database
            AddString(DiagramControlStringId.SoftwareIcons_HardDrive_Name, "硬盘"); //HardDrive
            AddString(DiagramControlStringId.SoftwareIcons_Network_Name, "网络"); //Network
            AddString(DiagramControlStringId.DecorativeShapes_Name, "装饰形状"); //Decorative Shapes
            AddString(DiagramControlStringId.DecorativeShapes_LightningBolt_Name, "闪电"); //Lightning Bolt
            AddString(DiagramControlStringId.DecorativeShapes_Moon_Name, "月亮"); //Moon
            AddString(DiagramControlStringId.DecorativeShapes_Wave_Name, "波浪线"); //Wave
            AddString(DiagramControlStringId.DecorativeShapes_DoubleWave_Name, "双波线"); //Double Wave
            AddString(DiagramControlStringId.DecorativeShapes_VerticalScroll_Name, "垂直滚动条"); //Vertical Scroll
            AddString(DiagramControlStringId.DecorativeShapes_HorizontalScroll_Name, "水平滚动条"); //Horizontal Scroll
            AddString(DiagramControlStringId.DecorativeShapes_Heart_Name, "心形"); //Heart
            AddString(DiagramControlStringId.DecorativeShapes_DownRibbon_Name, "下降带"); //Down Ribbon
            AddString(DiagramControlStringId.DecorativeShapes_UpRibbon_Name, "上升带"); //Up Ribbon
            AddString(DiagramControlStringId.DecorativeShapes_Cloud_Name, "云"); //Cloud
            AddString(DiagramControlStringId.ArrowShapes_Name, "箭头形状"); //Arrow Shapes
            AddString(DiagramControlStringId.ArrowShapes_SimpleArrow_Name, "简单箭头"); //Simple Arrow
            AddString(DiagramControlStringId.ArrowShapes_SimpleDoubleArrow_Name, "简单双箭头"); //Simple Double Arrow
            AddString(DiagramControlStringId.ArrowShapes_ModernArrow_Name, "现代箭头"); //Modern Arrow
            AddString(DiagramControlStringId.ArrowShapes_FlexibleArrow_Name, "弯曲箭头"); //Flexible Arrow
            AddString(DiagramControlStringId.ArrowShapes_BentArrow_Name, "弯箭头"); //Bent Arrow
            AddString(DiagramControlStringId.ArrowShapes_UTurnArrow_Name, "U 形箭头"); //U Turn Arrow
            AddString(DiagramControlStringId.ArrowShapes_SharpBentArrow_Name, "尖弯箭头"); //Sharp Bent Arrow
            AddString(DiagramControlStringId.ArrowShapes_CurvedRightArrow_Name, "向右弯曲箭头"); //Curved Right Arrow
            AddString(DiagramControlStringId.ArrowShapes_CurvedLeftArrow_Name, "向左弯曲箭头"); //Curved Left Arrow
            AddString(DiagramControlStringId.ArrowShapes_NotchedArrow_Name, "有缺口箭头"); //Notched Arrow
            AddString(DiagramControlStringId.ArrowShapes_StripedArrow_Name, "带条纹箭头"); //Striped Arrow
            AddString(DiagramControlStringId.ArrowShapes_BlockArrow_Name, "方块箭头"); //Block Arrow
            AddString(DiagramControlStringId.ArrowShapes_CircularArrow_Name, "环形箭头"); //Circular Arrow
            AddString(DiagramControlStringId.ArrowShapes_QuadArrow_Name, "四向箭头"); //Quad Arrow
            AddString(DiagramControlStringId.ArrowShapes_LeftRightUpArrow_Name, "左右上箭头"); //Left Right Up Arrow
            AddString(DiagramControlStringId.ArrowShapes_LeftRightArrowBlock_Name, "左右箭头块"); //Left Right Arrow Block
            AddString(DiagramControlStringId.ArrowShapes_QuadArrowBlock_Name, "四向箭头块"); //Quad Arrow Block
            AddString(DiagramControlStringId.Arrow_Open90, "90度打开箭头"); //Open 90 arrow
            AddString(DiagramControlStringId.Arrow_Filled90, "90度填充箭头"); //Filled 90 arrow
            AddString(DiagramControlStringId.Arrow_ClosedDot, "实心圆点"); //Closed dot
            AddString(DiagramControlStringId.Arrow_FilledDot, "实心圆"); //Filled dot
            AddString(DiagramControlStringId.Arrow_OpenFletch, "打开羽状物"); //Open fletch
            AddString(DiagramControlStringId.Arrow_FilledFletch, "填充羽状物"); //Filled fletch
            AddString(DiagramControlStringId.Arrow_Diamond, "菱形"); //Diamond
            AddString(DiagramControlStringId.Arrow_FilledDiamond, "填充菱形"); //Filled diamond
            AddString(DiagramControlStringId.Arrow_ClosedDiamond, "实心菱形"); //Closed diamond
            AddString(DiagramControlStringId.Arrow_IndentedFilledArrow, "缩进填充箭头"); //Indented filled arrow
            AddString(DiagramControlStringId.Arrow_OutdentedFilledArrow, "突出填充箭头"); //Outdented filled arrow
            AddString(DiagramControlStringId.Arrow_FilledSquare, "填充正方形"); //Filled square
            AddString(DiagramControlStringId.Arrow_ClosedASMEArrow, "实心 ASME 箭头"); //Closed ASME arrow
            AddString(DiagramControlStringId.Arrow_FilledDoubleArrow, "填充双向箭头"); //Filled double arrow
            AddString(DiagramControlStringId.Arrow_ClosedDoubleArrow, "实心双向箭头"); //Closed double arrow
            AddString(DiagramControlStringId.Container_Heading, "标题"); //Heading
            AddString(DiagramControlStringId.StandardContainers_Name, "标准容器"); //Standard Containers
            AddString(DiagramControlStringId.StandardContainers_Plain, "普通"); //Plain
            AddString(DiagramControlStringId.StandardContainers_Classic, "经典"); //Classic
            AddString(DiagramControlStringId.StandardContainers_Corners, "角落"); //Corners
            AddString(DiagramControlStringId.StandardContainers_Alternating, "交替"); //Alternating
            AddString(DiagramControlStringId.StandardContainers_Banner, "横幅"); //Banner
            AddString(DiagramControlStringId.RibbonPage_Home, "主页"); //Home
            AddString(DiagramControlStringId.RibbonPage_PrintPreview, "打印预览"); //Print Preview
            AddString(DiagramControlStringId.RibbonPageGroup_Action, "操作"); //Action
            AddString(DiagramControlStringId.RibbonPageGroup_Toolbox, "工具箱"); //Toolbox
            AddString(DiagramControlStringId.RibbonPageGroup_Document, "文档"); //Document
            AddString(DiagramControlStringId.RibbonPageGroup_File, "文件"); //File
            AddString(DiagramControlStringId.RibbonPageGroup_Clipboard, "剪贴板"); //Clipboard
            AddString(DiagramControlStringId.RibbonPageGroup_Options, "选项"); //Options
            AddString(DiagramControlStringId.RibbonPageGroup_Font, "字体"); //Font
            AddString(DiagramControlStringId.RibbonPageGroup_Paragraph, "段落"); //Paragraph
            AddString(DiagramControlStringId.RibbonPageGroup_Tools, "工具"); //Tools
            AddString(DiagramControlStringId.RibbonPage_View, "视图"); //View
            AddString(DiagramControlStringId.RibbonPageGroup_Show, "显示"); //Show
            AddString(DiagramControlStringId.RibbonPageGroup_Zoom, "缩放"); //Zoom
            AddString(DiagramControlStringId.RibbonPageGroup_Navigation, "导航"); //Navigation
            AddString(DiagramControlStringId.RibbonPageGroup_Appearance, "外观"); //Appearance
            AddString(DiagramControlStringId.RibbonPageGroup_Arrange, "排列"); //Arrange
            AddString(DiagramControlStringId.RibbonPageGroup_PageSetup, "页面设置"); //Page Setup
            AddString(DiagramControlStringId.RibbonPageGroup_Themes, "主题"); //Themes
            AddString(DiagramControlStringId.RibbonPageGroup_ShapeStyles, "形状样式"); //Shape styles
            AddString(DiagramControlStringId.RibbonPageGroup_ContainerStyles, "容器样式"); //Container styles
            AddString(DiagramControlStringId.RibbonPageGroup_TreeLayout, "树形布局"); //Layout
            AddString(DiagramControlStringId.RibbonPageGroup_UserInterfaceThemes, "用户界面主题"); //UI Themes
            AddString(DiagramControlStringId.RibbonPageGroup_ContainerSize, "容器大小"); //Size
            AddString(DiagramControlStringId.RibbonPageGroup_ImageTools_Arrange, "排列"); //Arrange
            AddString(DiagramControlStringId.RibbonPageGroup_ImageTools_ImageStyles, "图片样式"); //图片样式Image Styles
            AddString(DiagramControlStringId.RibbonPageGroup_ImageTools_Picture, "图片"); //Picture
            AddString(DiagramControlStringId.RibbonPage_Design, "设计"); //Design
            AddString(DiagramControlStringId.RibbonGallery_VariantStyles, "变体样式"); //Variant Styles
            AddString(DiagramControlStringId.RibbonGallery_ThemeStyles, "主题样式"); //Theme Styles
            AddString(DiagramControlStringId.PageSize, "大小"); //Size
            AddString(DiagramControlStringId.PageSize_Description, "选择页面大小。"); //Choose a page size.
            AddString(DiagramControlStringId.PageSizeHeader, "页面大小库"); //Page Size Gallery
            AddString(DiagramControlStringId.PageOrientation, "方向"); //Orientation
            AddString(DiagramControlStringId.PageOrientationHeader, "页面方向库"); //Page Orientation Gallery
            AddString(DiagramControlStringId.PageOrientation_Description, "在纵向和横向布局之间切换页面。"); //Switch the page between portrait and landscape layouts.
            AddString(DiagramControlStringId.PageOrientation_Vertical, "纵向"); //Portrait
            AddString(DiagramControlStringId.PageOrientation_Horizontal, "横向"); //Landscape
            AddString(DiagramControlStringId.ContainerPadding, "填充"); //Padding
            AddString(DiagramControlStringId.ContainerPadding_Description, "设置容器形状边界与其内容之间的间隙。"); //Set the gap between the container shape boundary and its contents.
            AddString(DiagramControlStringId.ContainerHeaderPadding, "标题填充"); //Header Padding
            AddString(DiagramControlStringId.ContainerHeaderPadding_Description, "设置容器标题边界和其内容之间的间隙。"); //Set the gap between the container header boundary and its content.
            AddString(DiagramControlStringId.ShowContainerHeader, "显示标题"); //Show Header
            AddString(DiagramControlStringId.ShowContainerHeader_Description, "显示/隐藏容器标题"); //Show/Hide header for the container
            AddString(DiagramControlStringId.InsertContainer, "容器"); //Container
            AddString(DiagramControlStringId.InsertContainer_Description, "在图表中选定形状并放置一个容器。"); //Place a container around the selected shapes in the diagram.
            AddString(DiagramControlStringId.CollapseSelectedContainers, "折叠容器"); //Collapse containers
            AddString(DiagramControlStringId.CollapseSelectedContainers_Description, "在图表中折叠/展开所选容器。"); //Collapse/Expand the selected containers in the diagram
            AddString(DiagramControlStringId.InsertPictureTitle, "插入图片"); //Insert Picture
            AddString(DiagramControlStringId.InsertList, "列表"); //List
            AddString(DiagramControlStringId.InsertList_Description, "在图表中放置水平或垂直列表。"); //Place a horizontal or vertical list in the diagram.
            AddString(DiagramControlStringId.ListOrientation, "方向"); //Orientation
            AddString(DiagramControlStringId.ListOrientation_Description, "在垂直和水平布局之间切换列表。"); //Switch the list between vertical and horizontal layouts.
            AddString(DiagramControlStringId.ListOrientation_Vertical, "垂直"); //Vertical
            AddString(DiagramControlStringId.ListOrientation_Horizontal, "水平"); //Horizontal
            AddString(DiagramControlStringId.SeparatorName, "条形分隔符"); //Bar Item Separator
            AddString(DiagramControlStringId.StatusBarShapeInfo, "形状信息"); //Shape Info
            AddString(DiagramControlStringId.StatusBarShapeWidth, "宽度"); //Shape Width
            AddString(DiagramControlStringId.StatusBarShapeHeight, "高度"); //Shape Height
            AddString(DiagramControlStringId.StatusBarShapeAngle, "角度"); //Shape Angle
            AddString(DiagramControlStringId.PageSizeSelectorName, "页面大小选择器"); //Page Size Selector
            AddString(DiagramControlStringId.PageOrientationSelectorName, "页面方向选择器"); //Page Orientation Selector
            AddString(DiagramControlStringId.VerticalTextAlignmentButtonGroup, "垂直文本对齐按钮组"); //Vertical Text Alignment Button Group
            AddString(DiagramControlStringId.HorizontalTextAlignmentButtonGroup, "水平文本对齐按钮组"); //Horizontal Text Alignment Button Group
            AddString(DiagramControlStringId.FontSizeAndFamilyButtonGroup, "字体大小和族群按钮组"); //Font Size And Family Button Group
            AddString(DiagramControlStringId.FontTypeAndColorButtonGroup, "字体类型和颜色按钮组"); //Font Type And Color Button Group
            AddString(DiagramControlStringId.Ribbon_MeasureUnit, "计量单位"); //Measure unit
            AddString(DiagramControlStringId.Ribbon_GridSize, "网格大小"); //Grid size
            AddString(DiagramControlStringId.AutoSize, "自动大小"); //Auto Size
            AddString(DiagramControlStringId.AutoSize_Description, "调整页面大小，以便在其边界外移动元素。"); //Adjust the page size on moving elements outside of its borders.
            AddString(DiagramControlStringId.AutoSize_Description2, "自动调整页面大小。"); //Automatically resize the page.
            AddString(DiagramControlStringId.AutoSizeSelector, "自动大小选择器"); //Auto Size Selector
            AddString(DiagramControlStringId.AutoSize_AutoSize, "自动大小"); //Auto Size
            AddString(DiagramControlStringId.AutoSize_AutoSize_Description, "自动调整页面大小。"); //Automatically resize the page.
            AddString(DiagramControlStringId.AutoSize_None, "无"); //None
            AddString(DiagramControlStringId.AutoSize_None_Description, "在移动元素时不更改页面大小。"); //The page size is not changed on moving elements outside of its borders.
            AddString(DiagramControlStringId.AutoSize_Fill, "填充"); //Fill
            AddString(DiagramControlStringId.AutoSize_Fill_Description, "填充整个可见区域"); //Fills the entire visible area
            AddString(DiagramControlStringId.SnapToGrid, "捕捉到网格"); //Snap to grid
            AddString(DiagramControlStringId.SnapToGrid_Description, "将图表项定位到最接近的网格交叉点。"); //Position diagram items to the closest intersection of the grid.
            AddString(DiagramControlStringId.SnapToItems, "捕捉到项目"); //Snap to items
            AddString(DiagramControlStringId.SnapToItems_Description, "使图表项相互对齐。"); //Align diagram items with each other.
            AddString(DiagramControlStringId.DiagramCommand_Undo, "撤销"); //Undo
            AddString(DiagramControlStringId.DiagramCommand_Undo_Description, "撤消上一次操作。"); //Undo the last operation.
            AddString(DiagramControlStringId.DiagramCommand_Redo, "重做"); //Redo
            AddString(DiagramControlStringId.DiagramCommand_Redo_Description, "重做上一次操作。"); //Redo the last operation.
            AddString(DiagramControlStringId.DiagramCommand_Delete, "删除"); //Delete
            AddString(DiagramControlStringId.DiagramCommand_BringToFront, "置于顶层"); //Bring to Front
            AddString(DiagramControlStringId.DiagramCommand_BringToFront_Description, "将所选对象置于所有其他对象的前面。"); //Bring the selected object in front of all other objects.
            AddString(DiagramControlStringId.DiagramCommand_BringForward, "上移一层"); //Bring Forward
            AddString(DiagramControlStringId.DiagramCommand_BringForward_Description, "将所选对象向前移动一层，以便其被较少的对象遮盖"); //Bring the selected object forward one level so that it's hidden behind fewer objects
            AddString(DiagramControlStringId.DiagramCommand_SendToBack, "置于底层"); //Send to Back
            AddString(DiagramControlStringId.DiagramCommand_SendToBack_Description, "将所选对象放在所有其他对象的后面。"); //Send the selected object behind all other objects.
            AddString(DiagramControlStringId.DiagramCommand_SendBackward, "下移一层"); //Send Backward
            AddString(DiagramControlStringId.DiagramCommand_SendBackward_Description, "将所选对象向后移动一层，以便其被更多的对象遮盖。"); //Send the selected object back one level so that it's hidden behind more objects.
            AddString(DiagramControlStringId.DiagramCommand_Edit, "编辑文本"); //Edit text
            AddString(DiagramControlStringId.DiagramCommand_Paste, "粘贴"); //Paste
            AddString(DiagramControlStringId.DiagramCommand_Paste_Description, "粘贴剪贴板的内容。"); //Paste the contents of the Clipboard.
            AddString(DiagramControlStringId.DiagramCommand_Cut, "剪切"); //Cut
            AddString(DiagramControlStringId.DiagramCommand_Cut_Description, "删除所选内容并将其放入剪贴板，以便您可以在其他地方粘贴它。"); //Remove the selection and put it on the Clipboard so you can paste it somewhere else.
            AddString(DiagramControlStringId.DiagramCommand_Copy, "复制"); //Copy
            AddString(DiagramControlStringId.DiagramCommand_Copy_Description, "在剪贴板上放置所选内容的副本，以便您可以在其他地方粘贴它。"); //Put a copy of the selection on the Clipboard so you can paste it somewhere else.
            AddString(DiagramControlStringId.DiagramCommand_OpenFile, "打开..."); //Open...
            AddString(DiagramControlStringId.DiagramCommand_OpenFile_Description, "打开一个图表文件"); //Open a diagram file
            AddString(DiagramControlStringId.DiagramCommand_SaveFile, "保存"); //Save
            AddString(DiagramControlStringId.DiagramCommand_SaveFile_Description, "保存此图表"); //Save this diagram
            AddString(DiagramControlStringId.DiagramCommand_SaveFileAs, "另存为..."); //Save As...
            AddString(DiagramControlStringId.DiagramCommand_SaveFileAs_Description, "使用不同的名称保存此图表"); //Save this diagram with a different name
            AddString(DiagramControlStringId.DiagramCommand_NewFile, "新建"); //New
            AddString(DiagramControlStringId.DiagramCommand_NewFile_Description, "创建一个新的图表"); //Create a new diagram
            AddString(DiagramControlStringId.DiagramCommand_Close_Description, "您即将关闭的文档有未保存的更改。您要保存 {0} 吗？"); //The document you are about to close has unsaved changes. Do you want to save {0}?
            AddString(DiagramControlStringId.DiagramCommand_FitToPage, "适应窗口大小"); //Fit to Window
            AddString(DiagramControlStringId.DiagramCommand_FitToPage_Description, "缩放文档，使整个页面适合并填充窗口。"); //Zoom the document so that the entire page fits in and fills the window.
            AddString(DiagramControlStringId.DiagramCommand_FitToWidth, "页宽"); //Page Width
            AddString(DiagramControlStringId.DiagramCommand_FitToWidth_Description, "缩放文档，使页面与窗口一样宽。"); //Zoom the document so that the page is as wide as the window.
            AddString(DiagramControlStringId.DiagramCommand_FitToDrawing, "适应图形大小"); //Fit to Drawing
            AddString(DiagramControlStringId.DiagramCommand_FitToDrawing_Description, "截断页面宽度和高度，以使页面大小与图表大小相匹配。"); //Truncate the page width and height so that the page size matches the diagram size.
            AddString(DiagramControlStringId.DiagramCommand_IncreaseFontSize, "增大字号"); //Increase Font Size
            AddString(DiagramControlStringId.DiagramCommand_IncreaseFontSize_Description, "使您的文本稍微变大。"); //Make your text a bit bigger.
            AddString(DiagramControlStringId.DiagramCommand_DecreaseFontSize, "减小字号"); //Decrease Font Size
            AddString(DiagramControlStringId.DiagramCommand_DecreaseFontSize_Description, "使您的文本稍微变小。"); //Make your text a bit smaller.
            AddString(DiagramControlStringId.DiagramCommand_ToggleFontBold, "加粗"); //Bold
            AddString(DiagramControlStringId.DiagramCommand_ToggleFontBold_Description, "使您的文本加粗。"); //Make your text bold.
            AddString(DiagramControlStringId.DiagramCommand_ToggleFontItalic, "斜体"); //Italic
            AddString(DiagramControlStringId.DiagramCommand_ToggleFontItalic_Description, "将您的文本设置为斜体。"); //Italicize your text.
            AddString(DiagramControlStringId.DiagramCommand_ToggleFontUnderline, "下划线"); //Underline
            AddString(DiagramControlStringId.DiagramCommand_ToggleFontUnderline_Description, "为您的文本添加下划线。"); //Underline your text.
            AddString(DiagramControlStringId.DiagramCommand_ToggleFontStrikethrough, "删除线"); //Strikethrough
            AddString(DiagramControlStringId.DiagramCommand_ToggleFontStrikethrough_Description, "通过在其上绘制一条线来划掉某些内容。"); //Cross something out by drawing a line through it.
            AddString(DiagramControlStringId.DiagramCommand_Empty, "无"); //none
            AddString(DiagramControlStringId.DiagramCommand_SetPageParameters_PageSize, "更多页面尺寸..."); //More Page Sizes...
            AddString(DiagramControlStringId.DiagramCommand_SetPageParameters_PageSize_Header, "页面设置"); //Page setup
            AddString(DiagramControlStringId.DiagramCommand_SetPageParameters_PageSize_Description, "从列表中选择页面大小或设置自定义大小。"); //Choose a page size from the list or set a custom size.
            AddString(DiagramControlStringId.DiagramCommand_SelectTool, "选择工具"); //Select Tool
            AddString(DiagramControlStringId.DiagramCommand_SelectNextItem, "选择下一个项目"); //Select Next Item
            AddString(DiagramControlStringId.DiagramCommand_SelectPrevItem, "选择上一个项目"); //Select Previous Item
            AddString(DiagramControlStringId.DiagramCommand_SelectAll, "选择所有项目"); //Select All Items
            AddString(DiagramControlStringId.DiagramCommand_ShowPropertiesPanel, "显示项目属性"); //Show Item Properties
            AddString(DiagramControlStringId.DiagramCommand_FocusNextControl, "聚焦下一个控件"); //Focus Next Control
            AddString(DiagramControlStringId.DiagramCommand_FocusPrevControl, "聚焦上一个控件"); //Focus Previous Control
            AddString(DiagramControlStringId.DiagramCommand_ShowPopupMenu, "显示弹出菜单"); //Show Popup Menu
            AddString(DiagramControlStringId.DiagramCommand_ZoomIn, "放大"); //Zoom In
            AddString(DiagramControlStringId.DiagramCommand_ZoomIn_Description, "缩小以获取文档的近距离视图。"); //Zoom in to get a close-up view of the document.
            AddString(DiagramControlStringId.DiagramCommand_ZoomOut, "缩小"); //Zoom Out
            AddString(DiagramControlStringId.DiagramCommand_ZoomOut_Description, "缩小以以减小尺寸查看页面上更多内容。"); //Zoom out to see more of the page at a reduced size.
            AddString(DiagramControlStringId.DiagramCommand_StartDragTool, "开始拖动工具"); //Start Drag Tool
            AddString(DiagramControlStringId.DiagramCommand_StartDragToolAlternate, "开始备用拖动工具"); //Start Drag Tool Alternate
            AddString(DiagramControlStringId.DiagramCommand_SetZoom, "设置缩放"); //Setting Zoom
            AddString(DiagramControlStringId.DiagramCommand_Cancel, "取消"); //Cancel
            AddString(DiagramControlStringId.RibbonPage_Insert, "插入"); //Insert
            AddString(DiagramControlStringId.RibbonPageGroup_DiagramParts, "图表部件"); //Diagram Parts
            AddString(DiagramControlStringId.DiagramCommand_InsertImage, "图片"); //Picture
            AddString(DiagramControlStringId.DiagramCommand_InsertImage_Description, "从您的计算机或其他连接的计算机插入图片。");
            AddString(DiagramControlStringId.DiagramCommand_LoadImage, "更改图片");
            AddString(DiagramControlStringId.DiagramCommand_LoadImage_Description, "打开要在项目中显示的图像文件。");
            AddString(DiagramControlStringId.DiagramCommand_ShowContainerHeader, "显示标题");
            AddString(DiagramControlStringId.DiagramCommand_ShowContainerHeader_Description, "显示/隐藏容器标题");
            AddString(DiagramControlStringId.DiagramCommand_CollapseSelectedContainers, "折叠容器");
            AddString(DiagramControlStringId.DiagramCommand_CollapseSelectedContainers_Description, "折叠/展开图表中选择的容器");
            AddString(DiagramControlStringId.RibbonPage_FormatContainer, "格式");
            AddString(DiagramControlStringId.RibbonPage_FormatImage, "格式");
            AddString(DiagramControlStringId.RibbonPageCategory_ContainerTools, "容器工具");
            AddString(DiagramControlStringId.RibbonPageCategory_ImageTools, "图像工具");
            AddString(DiagramControlStringId.DiagramCommand_MoveSelection_Left, "向左移动选择");
            AddString(DiagramControlStringId.DiagramCommand_MoveSelection_Up, "向上移动选择");
            AddString(DiagramControlStringId.DiagramCommand_MoveSelection_Right, "向右移动选择");
            AddString(DiagramControlStringId.DiagramCommand_MoveSelection_Down, "向下移动选择");
            AddString(DiagramControlStringId.DiagramCommand_SetVerticalAlignment_Top, "顶部对齐");
            AddString(DiagramControlStringId.DiagramCommand_SetVerticalAlignment_Top_Description, "将文本对齐到文本块的顶部。");
            AddString(DiagramControlStringId.DiagramCommand_SetVerticalAlignment_Center, "居中对齐");
            AddString(DiagramControlStringId.DiagramCommand_SetVerticalAlignment_Center_Description, "使文本在文本块的顶部和底部之间居中对齐。");
            AddString(DiagramControlStringId.DiagramCommand_SetVerticalAlignment_Bottom, "底部对齐");
            AddString(DiagramControlStringId.DiagramCommand_SetVerticalAlignment_Bottom_Description, "将文本对齐到文本块的底部。");
            AddString(DiagramControlStringId.DiagramCommand_SetHorizontalAlignment_Left, "左对齐");
            AddString(DiagramControlStringId.DiagramCommand_SetHorizontalAlignment_Left_Description, "将内容对齐到左侧。");
            AddString(DiagramControlStringId.DiagramCommand_SetHorizontalAlignment_Center, "居中对齐");
            AddString(DiagramControlStringId.DiagramCommand_SetHorizontalAlignment_Center_Description, "使内容居中。");
            AddString(DiagramControlStringId.DiagramCommand_SetHorizontalAlignment_Right, "右对齐");
            AddString(DiagramControlStringId.DiagramCommand_SetHorizontalAlignment_Right_Description, "将内容对齐到右侧。");
            AddString(DiagramControlStringId.DiagramCommand_SetHorizontalAlignment_Justify, "两端对齐");
            AddString(DiagramControlStringId.DiagramCommand_SetHorizontalAlignment_Justify_Description, "在边距之间均匀分配文本。");
            AddString(DiagramControlStringId.ReLayout, "重新布局页面");
            AddString(DiagramControlStringId.ReLayout_Description, "通过允许软件重新定位元素来布局图表。");
            AddString(DiagramControlStringId.ReLayoutTree, "层次结构");
            AddString(DiagramControlStringId.DiagramCommand_TreeLayout_BufferSize, "缓冲区大小");
            AddString(DiagramControlStringId.DiagramCommand_TreeLayout_Left, "从右到左");
            AddString(DiagramControlStringId.DiagramCommand_TreeLayout_Up, "从下到上");
            AddString(DiagramControlStringId.DiagramCommand_TreeLayout_Right, "从左到右");
            AddString(DiagramControlStringId.DiagramCommand_TreeLayout_Down, "从上到下");
            AddString(DiagramControlStringId.ReLayoutTipOverTreeHeader, "倾斜");
            AddString(DiagramControlStringId.DiagramCommand_TipOverTreeLayout_RightToLeft, "从右到左");
            AddString(DiagramControlStringId.DiagramCommand_TipOverTreeLayout_LeftToRight, "从左到右");
            AddString(DiagramControlStringId.ReLayoutMindMapTreeHeader, "思维导图");
            AddString(DiagramControlStringId.DiagramCommand_MindMapTreeLayout_Horizontal, "水平");
            AddString(DiagramControlStringId.DiagramCommand_MindMapTreeLayout_Vertical, "垂直");
            AddString(DiagramControlStringId.ReLayoutSugiyama, "分层");
            AddString(DiagramControlStringId.DiagramCommand_SugiyamaLayout_Left, "从右到左");
            AddString(DiagramControlStringId.DiagramCommand_SugiyamaLayout_Up, "从下到上");
            AddString(DiagramControlStringId.DiagramCommand_SugiyamaLayout_Right, "从左到右");
            AddString(DiagramControlStringId.DiagramCommand_SugiyamaLayout_Down, "从上到下");
            AddString(DiagramControlStringId.ReLayoutCircularHeader, "环形");
            AddString(DiagramControlStringId.DiagramCommand_CircularLayout, "环形");
            AddString(DiagramControlStringId.ReLayoutParts, "重新布局下属");
            AddString(DiagramControlStringId.ReLayoutParts_Description, "重新布置根项或所选项的下属项。");
            AddString(DiagramControlStringId.ReLayoutPartsTreeHeader, "层次结构");
            AddString(DiagramControlStringId.DiagramCommand_TreeLayoutForSubordinates_RightToLeft, "从右到左");
            AddString(DiagramControlStringId.DiagramCommand_TreeLayoutForSubordinates_BottomToTop, "从下到上");
            AddString(DiagramControlStringId.DiagramCommand_TreeLayoutForSubordinates_LeftToRight, "从左到右");
            AddString(DiagramControlStringId.DiagramCommand_TreeLayoutForSubordinates_TopToBottom, "从上到下");
            AddString(DiagramControlStringId.ReLayoutPartsTipOverTreeHeader, "倾斜");
            AddString(DiagramControlStringId.DiagramCommand_TipOverTreeLayoutForSubordinates_RightToLeft, "从右到左");
            AddString(DiagramControlStringId.DiagramCommand_TipOverTreeLayoutForSubordinates_LeftToRight, "从左到右");
            AddString(DiagramControlStringId.ReLayoutPartsMindMapTreeHeader, "思维导图");
            AddString(DiagramControlStringId.DiagramCommand_MindMapTreeLayoutForSubordinates_Horizontal, "水平");
            AddString(DiagramControlStringId.DiagramCommand_MindMapTreeLayoutForSubordinates_Vertical, "垂直");
            AddString(DiagramControlStringId.ChangeConnectorType, "连接器");
            AddString(DiagramControlStringId.ChangeConnectorType_Description, "更改图表中连接器的外观。");
            AddString(DiagramControlStringId.DiagramCommand_ChangeConnectorType_Curved, "曲线");
            AddString(DiagramControlStringId.DiagramCommand_ChangeConnectorType_RightAngle, "直角");
            AddString(DiagramControlStringId.DiagramCommand_ChangeConnectorType_Straight, "直线");
            AddString(DiagramControlStringId.DiagramCommand_ChangeConnectorType_OrgChart, "组织结构图");
            AddString(DiagramControlStringId.PrintMenu, "打印");
            AddString(DiagramControlStringId.PrintMenu_Description, "打印此图表");
            AddString(DiagramControlStringId.DiagramCommand_Print, "打印");
            AddString(DiagramControlStringId.DiagramCommand_Print_Description, "在打印之前选择打印机、打印份数和其他打印选项。");
            AddString(DiagramControlStringId.DiagramCommand_QuickPrint, "快速打印");
            AddString(DiagramControlStringId.DiagramCommand_QuickPrint_Description, "将文档直接发送到默认打印机，无需更改。");
            AddString(DiagramControlStringId.DiagramCommand_ShowPrintPreview, "打印预览");
            AddString(DiagramControlStringId.DiagramCommand_ShowPrintPreview_Description, "在打印之前预览并进行更改");
            AddString(DiagramControlStringId.ShowRulers, "标尺");
            AddString(DiagramControlStringId.ShowRulers_Description, "查看用于测量和对齐文档中对象的标尺。");
            AddString(DiagramControlStringId.ShowGrid, "网格");
            AddString(DiagramControlStringId.ShowGrid_Description, "网格线使您可以轻松地将对象与文本、其他对象或特定位置对齐。");
            AddString(DiagramControlStringId.ShowPageBreaks, "分页符");
            AddString(DiagramControlStringId.ShowPageBreaks_Description, "打开分页符以查看文档的每个页面将打印什么内容。");
            AddString(DiagramControlStringId.Panes, "窗格");
            AddString(DiagramControlStringId.Panes_Description, "显示窗格以查看形状和形状数据。");
            AddString(DiagramControlStringId.ShapesPanel, "形状面板");
            AddString(DiagramControlStringId.ShapesPanel_Description, "显示形状面板。");
            AddString(DiagramControlStringId.PropertiesPanel, "属性面板");
            AddString(DiagramControlStringId.PropertiesPanel_Description, "显示属性面板。");
            AddString(DiagramControlStringId.ShapeStyles, "形状样式");
            AddString(DiagramControlStringId.Themes, "主题");
            AddString(DiagramControlStringId.ContainerStyles, "容器样式");
            AddString(DiagramControlStringId.FontFamily, "字体");
            AddString(DiagramControlStringId.FontFamily_Description, "为文本选择新字体。");
            AddString(DiagramControlStringId.FontSize, "字号");
            AddString(DiagramControlStringId.FontSize_Description, "更改文本的大小。");
            AddString(DiagramControlStringId.FontSize_OutOfRangeErrorMessage, "字号必须在 {0} 和 {1} 之间。");
            AddString(DiagramControlStringId.FontSize_NonNumericErrorMessage, "指定的字号无效。");
            AddString(DiagramControlStringId.ForegroundColor, "字体颜色");
            AddString(DiagramControlStringId.ForegroundColor_Description, "更改文本的颜色。");
            AddString(DiagramControlStringId.BackgroundColor, "背景");
            AddString(DiagramControlStringId.BackgroundColor_Description, "更改背景颜色。");
            AddString(DiagramControlStringId.StrokeColor, "描边");
            AddString(DiagramControlStringId.StrokeColor_Description, "更改描边颜色。");
            AddString(DiagramControlStringId.ImageToolsRotate, "旋转");
            AddString(DiagramControlStringId.ImageToolsRotate_Description, "旋转或翻转所选图像。");
            AddString(DiagramControlStringId.DiagramCommand_FlipImage_Horizontal, "水平翻转");
            AddString(DiagramControlStringId.DiagramCommand_FlipImage_Horizontal_Description, "水平翻转所选图像。");
            AddString(DiagramControlStringId.DiagramCommand_FlipImage_Vertical, "垂直翻转");
            AddString(DiagramControlStringId.DiagramCommand_FlipImage_Vertical_Description, "垂直翻转所选图像。");
            AddString(DiagramControlStringId.DiagramCommand_Rotate_Left90, "逆时针旋转90度");
            AddString(DiagramControlStringId.DiagramCommand_Rotate_Left90_Description, "向左旋转所选项。");
            AddString(DiagramControlStringId.DiagramCommand_Rotate_Right90, "顺时针旋转90度");
            AddString(DiagramControlStringId.DiagramCommand_Rotate_Right90_Description, "向右旋转所选项。");
            AddString(DiagramControlStringId.DiagramDesigner_SaveChangesConfirmation, "是否应用更改？");
            AddString(DiagramControlStringId.DiagramCommand_SelectTool_PointerTool, "指针工具");
            AddString(DiagramControlStringId.DiagramCommand_SelectTool_PointerTool_Description, "选择、移动和调整对象的大小。");
            AddString(DiagramControlStringId.DiagramCommand_SelectTool_ConnectorTool, "连接器");
            AddString(DiagramControlStringId.DiagramCommand_SelectTool_ConnectorTool_Description, "在对象之间绘制连接器。");
            AddString(DiagramControlStringId.DiagramCommand_SelectTool_RectangleTool, "矩形");
            AddString(DiagramControlStringId.DiagramCommand_SelectTool_RectangleTool_Description, "拖动以绘制矩形。");
            AddString(DiagramControlStringId.DiagramCommand_SelectTool_EllipseTool, "椭圆");
            AddString(DiagramControlStringId.DiagramCommand_SelectTool_EllipseTool_Description, "拖动以绘制椭圆。");
            AddString(DiagramControlStringId.DiagramCommand_SelectTool_RightTriangleTool, "直角三角形");
            AddString(DiagramControlStringId.DiagramCommand_SelectTool_RightTriangleTool_Description, "拖动以绘制直角三角形。");
            AddString(DiagramControlStringId.DiagramCommand_SelectTool_HexagonTool, "六边形");
            AddString(DiagramControlStringId.DiagramCommand_SelectTool_HexagonTool_Description, "拖动以绘制六边形。");
            AddString(DiagramControlStringId.DiagramCommand_SelectTool_PanTool, "平移工具");
            AddString(DiagramControlStringId.DiagramCommand_SelectTool_PanTool_Description, "拖动以在画布上平移。");
            AddString(DiagramControlStringId.DiagramCommand_SelectTool_TextTool, "文本工具");
            AddString(DiagramControlStringId.DiagramCommand_SelectTool_TextTool_Description, "添加文本形状或选择现有文本。");
            AddString(DiagramControlStringId.PageSize_Width, "宽度");
            AddString(DiagramControlStringId.PageSize_Height, "高度");
            AddString(DiagramControlStringId.TabHeader_PageSize, "页面大小");
            AddString(DiagramControlStringId.Region_PageSize, "页面大小");
            AddString(DiagramControlStringId.Region_PageOrientation, "页面方向");
            AddString(DiagramControlStringId.Selector_PredefinedSize, "预定义大小");
            AddString(DiagramControlStringId.Selector_CustomSize, "自定义大小");
            AddString(DiagramControlStringId.Region_PageMargin, "页边距");
            AddString(DiagramControlStringId.PageMargin_Left, "左侧");
            AddString(DiagramControlStringId.PageMargin_Top, "上侧");
            AddString(DiagramControlStringId.PageMargin_Right, "右侧");
            AddString(DiagramControlStringId.PageMargin_Bottom, "下侧");
            AddString(DiagramControlStringId.TabHeader_LayoutAndRouting, "布局和路由");
            AddString(DiagramControlStringId.LayoutAndRoutingGroupSuperTip_Caption, "布局和路由");
            AddString(DiagramControlStringId.LayoutAndRoutingGroupSuperTip_Description, "在对话框中显示布局和路由选项卡。");
            AddString(DiagramControlStringId.Region_LineJumps, "线条跳跃");
            AddString(DiagramControlStringId.LineJump_LinesSelector, "添加线条跳跃到");
            AddString(DiagramControlStringId.LineJump_StyleSelector, "线条跳跃样式");
            AddString(DiagramControlStringId.LineJump_HeightSetter, "线条跳跃高度");
            AddString(DiagramControlStringId.LineJump_WidthSetter, "线条跳跃宽度");
            AddString(DiagramControlStringId.LineJump_None, "无");
            AddString(DiagramControlStringId.LineJump_HorizontalLines, "水平线条");
            AddString(DiagramControlStringId.LineJump_VerticalLines, "垂直线条");
            AddString(DiagramControlStringId.LineJump_Bow, "弯曲");
            AddString(DiagramControlStringId.LineJump_Gap, "间隙");
            AddString(DiagramControlStringId.LineJump_Square, "正方形");
            AddString(DiagramControlStringId.LineJump_TwoSides, "2边");
            AddString(DiagramControlStringId.LineJump_ThreeSides, "3边");
            AddString(DiagramControlStringId.LineJump_FourSides, "4边");
            AddString(DiagramControlStringId.LineJump_FiveSides, "5边");
            AddString(DiagramControlStringId.LineJump_SixSides, "6边");
            AddString(DiagramControlStringId.LineJump_SevenSides, "7边");
            AddString(DiagramControlStringId.DashType_Solid, "实线");
            AddString(DiagramControlStringId.DashType_Dash, "虚线");
            AddString(DiagramControlStringId.DashType_Dot, "点线");
            AddString(DiagramControlStringId.DashType_DashDot, "虚线点");
            AddString(DiagramControlStringId.DashType_DashDotDot, "虚线点点");
            AddString(DiagramControlStringId.DashType_DashDashDot, "双虚线点");
            AddString(DiagramControlStringId.DashType_LongDashShortDash, "长虚线短虚线");
            AddString(DiagramControlStringId.DashType_LongDashShortDashShortDash, "长虚线短虚线短虚线");
            AddString(DiagramControlStringId.DashType_HalfDash, "半虚线");
            AddString(DiagramControlStringId.DashType_HalfDot, "半点线");
            AddString(DiagramControlStringId.ImageFlipMode_None, "无");
            AddString(DiagramControlStringId.ImageFlipMode_Horizontal, "水平翻转");
            AddString(DiagramControlStringId.ImageFlipMode_Vertical, "垂直翻转");
            AddString(DiagramControlStringId.ImageFlipMode_Both, "水平和垂直翻转");
            AddString(DiagramControlStringId.ImageStretchMode_Uniform, "等比缩放");
            AddString(DiagramControlStringId.ImageStretchMode_UniformToFill, "填充并保持原始宽高比");
            AddString(DiagramControlStringId.ImageStretchMode_Stretch, "拉伸以填充区域");
            AddString(DiagramControlStringId.ImageToolsStretchMode, "设置拉伸模式");
            AddString(DiagramControlStringId.ImageToolsStretchMode_Description, "控制如何调整图像以填充其分配的空间。");
            AddString(DiagramControlStringId.DiagramCommand_SetSelectedImagesStretchMode_Uniform, "等比缩放");
            AddString(DiagramControlStringId.DiagramCommand_SetSelectedImagesStretchMode_Uniform_Description, "保持源图像的宽高比。");
            AddString(DiagramControlStringId.DiagramCommand_SetSelectedImagesStretchMode_UniformToFill, "填充并保持原始宽高比");
            AddString(DiagramControlStringId.DiagramCommand_SetSelectedImagesStretchMode_UniformToFill_Description, "填充图像项目，同时保持源图像的本机宽高比。如果其宽高比不同，则裁剪图像。");
            AddString(DiagramControlStringId.DiagramCommand_SetSelectedImagesStretchMode_Stretch, "拉伸以填充区域");
            AddString(DiagramControlStringId.DiagramCommand_SetSelectedImagesStretchMode_Stretch_Description, "拉伸源图像以填充图表图像项。");
            AddString(DiagramControlStringId.DiagramCommand_ResetSelectedImages, "重置图像");
            AddString(DiagramControlStringId.DiagramCommand_ResetSelectedImages_Description, "更改项目的大小，使其与源图像的大小相匹配。");
            AddString(DiagramControlStringId.ImageToolsSetImageScale, "设置图像缩放比例");
            AddString(DiagramControlStringId.ImageToolsSetImageScale_Description, "指定图像缩放比例。");
            AddString(DiagramControlStringId.ImageToolsSetImageScale_0_25, "25 %");
            AddString(DiagramControlStringId.ImageToolsSetImageScale_0_5, "50 %");
            AddString(DiagramControlStringId.ImageToolsSetImageScale_0_75, "75 %");
            AddString(DiagramControlStringId.ImageToolsSetImageScale_1, "100 %");
            AddString(DiagramControlStringId.ImageToolsSetImageScale_1_5, "150 %");
            AddString(DiagramControlStringId.ImageToolsSetImageScale_2, "200 %");
            AddString(DiagramControlStringId.ImageToolsSetImageScale_4, "400 %");
            AddString(DiagramControlStringId.ContainerPadding_P0, "0 px");
            AddString(DiagramControlStringId.ContainerPadding_P4, "4 px");
            AddString(DiagramControlStringId.ContainerPadding_P8, "8 px");
            AddString(DiagramControlStringId.ContainerPadding_P12, "12 px");
            AddString(DiagramControlStringId.ContainerPadding_P16, "16 px");
            AddString(DiagramControlStringId.ContainerPadding_P24, "24 px");
            AddString(DiagramControlStringId.ContainerPadding_P32, "32 px");
            AddString(DiagramControlStringId.ContainerHeaderPadding_P0, "0 px");
            AddString(DiagramControlStringId.ContainerHeaderPadding_P4, "4 px");
            AddString(DiagramControlStringId.ContainerHeaderPadding_P8, "8 px");
            AddString(DiagramControlStringId.ContainerHeaderPadding_P12, "12 px");
            AddString(DiagramControlStringId.ContainerHeaderPadding_P16, "16 px");
            AddString(DiagramControlStringId.ContainerHeaderPadding_P24, "24 px");
            AddString(DiagramControlStringId.ContainerHeaderPadding_P32, "32 px");
            AddString(DiagramControlStringId.StatusBarWidth, "宽度");
            AddString(DiagramControlStringId.StatusBarHeight, "高度");
            AddString(DiagramControlStringId.StatusBarAngle, "角度");
            AddString(DiagramControlStringId.StatusBarZoomEditor, "缩放");
            AddString(DiagramControlStringId.StatusBarZoomEditor_Description, "更改缩放比例。");
            AddString(DiagramControlStringId.PrintPreview_Title, "预览");
            AddString(DiagramControlStringId.PrintPreview_Zoom, "缩放");
            AddString(DiagramControlStringId.PrintPreview_Zoom_Description, "更改文档预览的当前缩放比例。");
            AddString(DiagramControlStringId.PrintPreview_ZoomSelector, "缩放选择器");
            AddString(DiagramControlStringId.PrintPreview_FitToMaxPagesAcrossHeader, "横向最多页数");
            AddString(DiagramControlStringId.PrintPreview_FitToMaxPagesAcrossSelector, "适应横向最多页数选择器");
            AddString(DiagramControlStringId.PrintPreview_Print, "打印");
            AddString(DiagramControlStringId.PrintPreview_Close, "关闭");
            AddString(DiagramControlStringId.PrintPreview_Close_Description, "关闭预览。");
            AddString(DiagramControlStringId.PrintPreview_BestFit, "最佳匹配");
            AddString(DiagramControlStringId.PrintPreview_BestFit_Description, "在预览中设置最佳缩放和相邻页数。");
            AddString(DiagramControlStringId.PrintPreview_PageOfPagesDisplayFormat, "第 {0} 页，共 {1} 页");
            AddString(DiagramControlStringId.PrintPreview_Scale, "缩放比例");
            AddString(DiagramControlStringId.PrintPreview_Scale_Description, "将文档内容拉伸或缩小到其实际大小的百分比。");
            AddString(DiagramControlStringId.PrintPreview_Scale_Dialog_Title, "缩放比例");
            AddString(DiagramControlStringId.PrintPreview_Scale_Dialog_BeginAdjustLabel, "调整为");
            AddString(DiagramControlStringId.PrintPreview_Scale_Dialog_EndAdjustLabel, "普通大小");
            AddString(DiagramControlStringId.PrintPreview_Scale_Dialog_BeginFitLabel, "适应");
            AddString(DiagramControlStringId.PrintPreview_Scale_Dialog_EndFitLabel, "页至");
            AddString(DiagramControlStringId.PrintPreview_Scale_Dialog_ValidationError, "值超出范围");
            AddString(DiagramControlStringId.DiagramNotification_DefaultCaption, "Diagram 设计师");
            AddString(DiagramControlStringId.DiagramNotification_ApplyPageSettings, "是否要将新页面设置应用于图表？");
            AddString(DiagramControlStringId.DefaultDocumentName, "文档");
            AddString(DiagramControlStringId.DocumentFormat_XmlFiles, "XML 文件");
            AddString(DiagramControlStringId.DocumentFormat_AllFiles, "所有文件");
            AddString(DiagramControlStringId.DocumentLoadErrorMessage, "无法加载指定的文件");
            AddString(DiagramControlStringId.DocumentSaveErrorMessage, "无法保存指定的文件");
            AddString(DiagramControlStringId.ImageLoadErrorMessage, "无法加载指定的文件");
            AddString(DiagramControlStringId.ExportAs, "导出为...");
            AddString(DiagramControlStringId.ExportAs_Description, "将图表导出为PNG或JPEG等各种文件格式");
            AddString(DiagramControlStringId.DiagramCommand_ExportDiagram_JPEG, "JPEG 文件交换格式");
            AddString(DiagramControlStringId.DiagramCommand_ExportDiagram_JPEG_Description, "将图表保存为JPEG图像，压缩效果较好，且图像质量损失很小。");
            AddString(DiagramControlStringId.DiagramCommand_ExportDiagram_BMP, "Windows 位图");
            AddString(DiagramControlStringId.DiagramCommand_ExportDiagram_BMP_Description, "将图表保存为位图图像文件，由于缺乏压缩，需要更多的磁盘空间。");
            AddString(DiagramControlStringId.DiagramCommand_ExportDiagram_PNG, "可移植网络图形");
            AddString(DiagramControlStringId.DiagramCommand_ExportDiagram_PNG_Description, "将图表保存为PNG图像，具有高质量，并且如果图表具有完全均匀颜色区域，则占用非常少的空间。");
            AddString(DiagramControlStringId.DiagramCommand_ExportDiagram_GIF, "图形交换格式");
            AddString(DiagramControlStringId.DiagramCommand_ExportDiagram_GIF_Description, "将图表保存为GIF图像，紧凑但是如果图表的颜色超过了256种，则会降低质量。");
            AddString(DiagramControlStringId.DiagramCommand_ExportToPdf, "可移植文档格式");
            AddString(DiagramControlStringId.DiagramCommand_ExportToPdf_Description, "将图表保存为单页PDF文档。");
            AddString(DiagramControlStringId.DiagramCommand_ExportToSvg, "可缩放矢量图形");
            AddString(DiagramControlStringId.DiagramCommand_ExportToSvg_Description, "将图表保存为SVG格式，该格式使用基于XML的语言描述矢量图形。");
            AddString(DiagramControlStringId.InsertImage_DialogFilter, "所有图片");
            AddString(DiagramControlStringId.ClipboardPasteErrorMessage, "无法从剪贴板粘贴项目");
            AddString(DiagramControlStringId.DocumentDisplayFormat_Modified, "{0}*");
            AddString(DiagramControlStringId.SaveFileAsDialogTitle, "另存为");
            AddString(DiagramControlStringId.OpenFileDialogTitle, "打开文件");
            AddString(DiagramControlStringId.BindingEditorDialogTitle, "项数据绑定编辑器");
            AddString(DiagramControlStringId.CreateRibbonDesignerActionListCommand, "创建功能区菜单");
            AddString(DiagramControlStringId.CreateDockingDesignerActionListCommand, "创建工具箱和属性网格");
            AddString(DiagramControlStringId.CreatePanAndZoomDesignerActionListCommand, "创建平移和缩放面板");
            AddString(DiagramControlStringId.MessageAddCommandConstructorError, "在 {0} 类中找不到带有 DiagramControl 类型参数的构造函数");
            AddString(DiagramControlStringId.PropertyGridView_Alphabetical, "按字母顺序");
            AddString(DiagramControlStringId.PropertyGridView_Categorized, "分组显示");
            AddString(DiagramControlStringId.PropertyGridOption_None, "（无）");
            AddString(DiagramControlStringId.Category_Layout, "布局");
            AddString(DiagramControlStringId.Category_Appearance, "外观");
            AddString(DiagramControlStringId.Category_Behavior, "行为");
            AddString(DiagramControlStringId.Category_Options, "选项");
            AddString(DiagramControlStringId.Category_Common, "常用");
            AddString(DiagramControlStringId.Category_Data, "数据");
            AddString(DiagramControlStringId.Category_DiagramPropertyChanged, "图表属性更改");
            AddString(DiagramControlStringId.Category_DiagramDocument, "图表文档");
            AddString(DiagramControlStringId.Category_DiagramItems, "图表项目");
            AddString(DiagramControlStringId.Category_DiagramPaint, "图表绘制");
            AddString(DiagramControlStringId.Category_SizeAndPosition, "尺寸和位置");
            AddString(DiagramControlStringId.Category_Export, "导出");
            AddString(DiagramControlStringId.Category_ExpandAndCollapse, "展开和折叠");
            AddString(DiagramControlStringId.Category_Protection, "保护");
            AddString(DiagramControlStringId.Panel_PanAndZoom_Name, "平移和缩放");
            AddString(DiagramControlStringId.PanAndZoomPanel, "平移和缩放");
            AddString(DiagramControlStringId.PanAndZoomPanel_Description, "显示平移和缩放窗口。");
            AddString(DiagramControlStringId.PanAndZoomPanel_SingleAmp, "平移和缩放");
            AddString(DiagramControlStringId.PanAndZoomPanel_SingleAmp_Description, "显示平移和缩放窗口。");
            AddString(DiagramControlStringId.Validation_Size, "“{0}”值应大于或等于{1}。");
            AddString(DiagramControlStringId.ExportDiagram_ExportFailed, "导出失败");
            AddString(DiagramControlStringId.ExportDiagram_ExportFailedMessage, "无法导出图表，因为生成的图像太大。");
            AddString(DiagramControlStringId.ExportDiagram_ExportFailed_UnsupportedFormat_Message, "尝试使用不支持的文件扩展名保存图表内容。");
            AddString(DiagramControlStringId.OpenFile_UnknownItemKindMessage, "图表包含一个未知项：“{0}”。");
            AddString(DiagramControlStringId.PropertiesPanel_Angle, "角度");
            AddString(DiagramControlStringId.PropertiesPanel_BackgroundColor, "背景色");
            AddString(DiagramControlStringId.PropertiesPanel_BeginArrow, "起点箭头");
            AddString(DiagramControlStringId.PropertiesPanel_BeginArrowSize, "起点箭头大小");
            AddString(DiagramControlStringId.PropertiesPanel_BeginLabelArrowOffset, "起点标签箭头偏移量");
            AddString(DiagramControlStringId.PropertiesPanel_BeginLabelConnectorOffset, "起点标签连接器偏移量");
            AddString(DiagramControlStringId.PropertiesPanel_BeginLeftLabel, "起点左标签");
            AddString(DiagramControlStringId.PropertiesPanel_BeginRightLabel, "起点右标签");
            AddString(DiagramControlStringId.PropertiesPanel_BeginX, "起点X坐标");
            AddString(DiagramControlStringId.PropertiesPanel_BeginY, "起点Y坐标");
            AddString(DiagramControlStringId.PropertiesPanel_BorderBrush, "边框画刷");
            AddString(DiagramControlStringId.PropertiesPanel_BorderThickness, "边框厚度");
            AddString(DiagramControlStringId.PropertiesPanel_CanvasSizeMode, "画布大小模式");
            AddString(DiagramControlStringId.PropertiesPanel_Content, "文本内容");
            AddString(DiagramControlStringId.PropertiesPanel_ContentBackground, "内容背景");
            AddString(DiagramControlStringId.PropertiesPanel_CornerRadius, "圆角半径");
            AddString(DiagramControlStringId.PropertiesPanel_EndArrow, "终点箭头");
            AddString(DiagramControlStringId.PropertiesPanel_EndArrowSize, "终点箭头大小");
            AddString(DiagramControlStringId.PropertiesPanel_EndLabelArrowOffset, "终点标签箭头偏移量");
            AddString(DiagramControlStringId.PropertiesPanel_EndLabelConnectorOffset, "终点标签连接器偏移量");
            AddString(DiagramControlStringId.PropertiesPanel_EndLeftLabel, "终点左标签");
            AddString(DiagramControlStringId.PropertiesPanel_EndRightLabel, "终点右标签");
            AddString(DiagramControlStringId.PropertiesPanel_EndX, "终点X坐标");
            AddString(DiagramControlStringId.PropertiesPanel_EndY, "终点Y坐标");
            AddString(DiagramControlStringId.PropertiesPanel_FlipMode, "翻转");
            AddString(DiagramControlStringId.PropertiesPanel_ForegroundColor, "前景色");
            AddString(DiagramControlStringId.PropertiesPanel_Header, "标题文本");
            AddString(DiagramControlStringId.PropertiesPanel_HeaderPadding, "标题边距");
            AddString(DiagramControlStringId.PropertiesPanel_Height, "高度");
            AddString(DiagramControlStringId.PropertiesPanel_Landscape, "横向");
            AddString(DiagramControlStringId.PropertiesPanel_LineJumpPlacement, "线路跳跃位置");
            AddString(DiagramControlStringId.PropertiesPanel_LineJumpSize, "线路跳跃大小");
            AddString(DiagramControlStringId.PropertiesPanel_LineJumpStyle, "线路跳跃样式");
            AddString(DiagramControlStringId.PropertiesPanel_Orientation, "方向");
            AddString(DiagramControlStringId.PropertiesPanel_Padding, "内边距");
            AddString(DiagramControlStringId.PropertiesPanel_PageSize, "页面大小");
            AddString(DiagramControlStringId.PropertiesPanel_PaperKind, "纸张类型");
            AddString(DiagramControlStringId.PropertiesPanel_SelectedStencils, "已选形状");
            AddString(DiagramControlStringId.PropertiesPanel_ShowGrid, "显示网格");
            AddString(DiagramControlStringId.PropertiesPanel_ShowHeader, "显示标题栏");
            AddString(DiagramControlStringId.PropertiesPanel_ShowRulers, "标尺");
            AddString(DiagramControlStringId.PropertiesPanel_StretchMode, "拉伸模式");
            AddString(DiagramControlStringId.PropertiesPanel_StrokeColor, "描边颜色");
            AddString(DiagramControlStringId.PropertiesPanel_StrokeDashArray, "描边样式");
            AddString(DiagramControlStringId.PropertiesPanel_StrokeThickness, "描边厚度");
            AddString(DiagramControlStringId.PropertiesPanel_Theme, "主题");
            AddString(DiagramControlStringId.PropertiesPanel_Type, "类型");
            AddString(DiagramControlStringId.PropertiesPanel_Width, "宽度");
            AddString(DiagramControlStringId.PropertiesPanel_X, "X");
            AddString(DiagramControlStringId.PropertiesPanel_Y, "Y");
            AddString(DiagramControlStringId.PropertiesPanel_Left, "左侧");
            AddString(DiagramControlStringId.PropertiesPanel_Top, "顶部");
            AddString(DiagramControlStringId.PropertiesPanel_Right, "右侧");
            AddString(DiagramControlStringId.PropertiesPanel_Bottom, "底部");
            AddString(DiagramControlStringId.PropertiesPanel_TopLeft, "左上角");
            AddString(DiagramControlStringId.PropertiesPanel_TopRight, "右上角");
            AddString(DiagramControlStringId.PropertiesPanel_BottomRight, "右下角");
            AddString(DiagramControlStringId.PropertiesPanel_BottomLeft, "左下角");
            AddString(DiagramControlStringId.PropertiesPanel_MeasureUnit, "测量单位");
            AddString(DiagramControlStringId.PropertiesPanel_ShowMeasureUnit, "显示测量单位");
            AddString(DiagramControlStringId.DiagramDoubleCollection_EmptyFormat, "空");
        }

        protected override void PopulateStringTable()
        {
            AddStrings();
        }

    }
}
