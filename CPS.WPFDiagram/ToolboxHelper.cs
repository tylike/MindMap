using DevExpress.Diagram.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace CPS.WPFDiagram
{
    public static class ToolboxHelper
    {
        const string 线条颜色 = "black";
        #region Input Parameter Group
        public static void CreateInputParameter(this DiagramStencil stencil)
        {
            var symbols = new Dictionary<string, string>
            {
                { "S" ,"DCS Point"},
                { "G", "Global Expression"},
                { "M","Manual Input" },
                { "I","Internal State" },
                { "C","Numberic Constant" }
            };
            foreach (var symbol in symbols)
            {
                string name = "InputParameter_" + symbol.Value;
                var shape = stencil.CreateShape
                (
                    InputParameterShape(symbol.Key),
                    name,
                    symbol.Value, new Size(130, 37.5),
                    Points(Point(1, 0.5, false))
                );
            }
        }
        static string smallCss = $@"
    <style type='text/css'>
        .ls{{
            stroke: {线条颜色};stroke-width:2px;
        }}
    </style>
";
        static string InputParameterShape(string symbol)
        {
            //代表图形的顶点位置,不为0则说明有缩进
            var 左缩 = 0;
            var 上缩 = 0;

            var 长方形宽 = 150;
            var 长方形半高 = 25;
            var 三角形宽 = 25;
            //在下面的svg字符串中,结果是：
            //左侧是一个长方形，接着是一个不封闭的长方形，右侧是一个三角形。
            //需要在左侧的长方形中显示一个字符,使用symbol指定的字符

            var svg = $@"
<svg width='{长方形宽 + 三角形宽 + 左缩}' height='{长方形半高 * 2 + 上缩}' xmlns='http://www.w3.org/2000/svg'>
{smallCss}
	<g>
        <!--上方横线-->
		<line id='topLine' {cssClass} x1='{左缩}' y1='{上缩}' x2='{长方形宽}' y2='{上缩}'/>
        <!--上方斜线形如:\-->
		<line id='topArray' {cssClass} x1='{长方形宽 + 左缩}' y1='{上缩}' x2='{长方形宽 + 三角形宽 + 左缩}' y2='{三角形宽 + 上缩}'/>
        <!--下方斜线形如:/-->
		<line id='bottomArray' {cssClass} x1='{长方形宽 + 三角形宽 + 左缩}' y1='{三角形宽 + 上缩}' y2='{长方形半高 * 2 + 上缩}' x2='{长方形宽 + 左缩}'/>
        <!--下方横线-->
		<line id='bottomLine' {cssClass} x1='{长方形宽 + 左缩}'  y1='{长方形半高 * 2 + 上缩}' x2='{左缩}' y2='{长方形半高 * 2 + 上缩}'/>
        <!--左侧竖线-->
		<line id='leftLine' {cssClass} x1='{左缩}' y1='{上缩}' y2='{长方形半高 * 2 + 上缩}' x2='{左缩}'/>
        <!--中间竖线-->
		<line id='middleLine' {cssClass} x1='{左缩 + 30}' y2='{长方形半高 * 2 + 上缩}' x2='{30 + 左缩}'  y1='{上缩}' />
        <text x='{左缩 + 10}' y='{上缩 + 长方形半高 + 5}' fill='{线条颜色}'>{symbol}</text>
	</g>
</svg>";
            //将svg代码转换为xaml代码

            return svg;
        }
        #endregion

        #region Operator Group
        static string Operator_CompareToConstant()
        {
            var 宽 = 120;
            var 高 = 100;
            var left = 20;

            var svg = $@"<svg width='{宽 + 40}' height='{高}' xmlns='http://www.w3.org/2000/svg'>
{smallCss}
<rect x='{left}' y='0' width='{宽}' height='{高}' {cssClass} fill='none'/>
<line x1='{0}' y1='{50}' x2='{20}' y2='{50}' {cssClass} />
<line x1='{140}' y1='{50}' x2='{160}' y2='{50}' {cssClass}/>
</svg>";
            return svg;
        }
        static string Operator_Operator()
        {
            var 宽 = 120;
            var 高 = 100;
            var left = 20;

            var svg = $@"<svg width='{宽 + 40}' height='{高}' xmlns='http://www.w3.org/2000/svg'>
{smallCss}
<rect x='{left}' y='0' width='{宽}' height='{高}' fill='none' {cssClass}/>
<line x1='{0}' y1='{20}' x2='{20}' y2='{20}' {cssClass}/>
<line x1='{0}' y1='{80}' x2='{20}' y2='{80}' {cssClass}/>
<line x1='{140}' y1='{50}' x2='{160}' y2='{50}' {cssClass}/>
</svg>";
            return svg;
        }
        static string Operator_AND()
        {
            var svg = $@"<?xml version='1.0'?>
<svg width='195' height='100' xmlns='http://www.w3.org/2000/svg' xmlns:svg='http://www.w3.org/2000/svg' preserveAspectRatio='xMidYMid meet' version='1.0'>
{smallCss}
 <g class='layer'>
	 <path d='		   
		   M 20 0
		   L 120 0
           A 50 50, 0, 0, 1, 120 100
		   L 20 100
		   L 20 0
		   M 0 20
		   L 20 20
		   M 0 80
		   L 20 80
		   M 170 50
		   L 195 50
           ' {cssClass} fill='none'/>
	 <!--
	 M 100 0
	 path d 参数说明:
	 A rx ry x-axis-rotation large-arc-flag sweep-flag x y
	 rx: x轴半径
	 ry: y轴半径
	 x-axis-rotation: 椭圆的旋转角度
	 large-arc-flag: 0:小于180度, 1:大于180度
	 sweep-flag: 0:逆时针, 1:顺时针
	 x y: 终点坐标	 
	 
	 L x y: 直线
	 M x y: 移动到坐标
	 
	 -->
	 <text x='40' y='70' font-size='50'>AND</text>
 </g>
</svg>";
            return svg;
        }
        static string bigCss = $@"
    <style type='text/css'>
        .ls{{
            stroke: {线条颜色};stroke-width:8px;
        }}
    </style>
";
        static string cssClass = " class='ls' ";
        static string Operator_OR()
        {

            var svg = $@"
<svg width='531' height='320' xmlns='http://www.w3.org/2000/svg' style='vector-effect: non-scaling-stroke;'>
{bigCss}
    <!--上面大弧线-->
  <g transform='matrix(1,0,0,1,310,152) ' id='svg_4'>
   <path class='ls' d='m -246,-142 q290,-30 410,150' fill='none' id='svg_5'/>
  </g>
  <!--下面大弧线-->
  <g  transform='matrix(1,0,0,1,310,305) ' id='svg_6'>
   <path class='ls' d='m 164,-142 q-110,180 -410,150' fill='none' id='svg_7'/>
  </g>
  <!--左上弧线-->
  <g  transform='matrix(1,0,0,1,310,152) ' id='svg_8'>
   <path class='ls' d='m -156,8 q0,-140 -90,-150' fill='none' id='svg_9'/>
  </g>
  <!--左下弧线-->
  <g  transform='matrix(1,0,0,1,310,305) ' id='svg_10'>
   <path class='ls' d='m -246,8 q90,0 90,-150' fill='none' id='svg_11'/>
  </g>
  <!--左上横线-->
  <g  transform='matrix(2,0,0,1.5,392,278) ' id='svg_16'>
   <path class='ls' d='m -195,-144 l 68,0' fill='none' id='svg_17'/>
  </g>
  <!--左下横线-->
  <g  transform='matrix(2,0,0,1,214,407) ' id='svg_18'>
   <path class='ls' d='m -104,-150 l67,0' fill='none' id='svg_19'/>
  </g>
  <!--最右边的横线-->
  <g  transform='matrix(1,0,0,1,720,305) ' id='svg_20'>
   <path class='ls' d='m -246,-142 l62,0' fill='none' id='svg_21'/>
  </g>
</svg>
";
            //将上面的svg代码转换为xaml
            

            return svg;
        }
        static string Operator_XOR()
        {
            var svg = $@"
<svg width='580' height='320' xmlns='http://www.w3.org/2000/svg'>
{bigCss}
	<g id='svg_4' transform='matrix(1,0,0,1,310,150) '>
		<path {cssClass} id='svg_5' fill='none' d='m -198,-142 q 290,-30 410,150'/>
	</g>
	<g id='svg_6' transform='matrix(1,0,0,1,310,300) '>
		<path {cssClass} id='svg_7'  fill='none' d='m 212,-142 q -110,180 -410,150'/>
	</g>
	<g id='svg_8' transform='matrix(1,0,0,1,310,150) '>
		<path {cssClass} id='svg_9'  fill='none' d='m-108,8q0,-140 -90,-150'/>
	</g>
	<g id='svg_10' transform='matrix(1,0,0,1,310,300) '>
		<path {cssClass} id='svg_11'  fill='none' d='m-198,8q90,0 90,-150'/>
	</g>
	<g id='svg_12' transform='matrix(1,0,0,1,220,160) '>
		<path {cssClass} id='svg_13'  fill='none' d='m-108,0q0,-140 -90,-150'/>
	</g>
	<g id='svg_14' transform='matrix(1,0,0,1,220,310) '>
		<path {cssClass} id='svg_15'  fill='none' d='m-198,0q90,0 90,-150'/>
	</g>
	<!--左上横线-->
	<g id='svg_16' transform='matrix(1,0,0,1,200,200) '>
		<path {cssClass} id='svg_17'  fill='none' d='m-198,-150l68,0'/>
	</g>
	<!--左下横线-->
	<g id='svg_18' transform='matrix(1,0,0,1,200,400) '>
		<path {cssClass} id='svg_19'  fill='none' d='m-198,-150l67,0'/>
	</g>
	<!--最右边的横线-->
	<g id='svg_20' transform='matrix(1,0,0,1,720,300) '>
		<path {cssClass} id='svg_21'  fill='none' d='m-198,-142l62,0'/>
	</g>
</svg>
";
            return svg;
        }
        static string Operator_Exp()
        {
            var 宽 = 120;
            var 高 = 100;
            var left = 20;

            var svg = $@"<svg width='{宽 + 40}' height='{高}' xmlns='http://www.w3.org/2000/svg'>
{smallCss}
<rect x='{left}' y='0' width='{宽}' height='{高}' {cssClass} fill='none'/>

<line x1='{0}' y1='{20}' x2='{20}' y2='{20}' {cssClass}/>
<line x1='{0}' y1='{80}' x2='{20}' y2='{80}' {cssClass}/>
<line x1='{140}' y1='{50}' x2='{160}' y2='{50}' {cssClass}/>
<text x='25' y='80' fill='{线条颜色}'>Y</text>
<text x='110' y='50' fill='{线条颜色}'>X</text>
</svg>";
            return svg;
        }
        static string Operator_NOT(bool showText = true)
        {
            var text = "";
            var x = 120;
            if (showText)
            {
                text = $@"
<circle cx='123' cy='50' r='3' fill='none'  stroke='{线条颜色}'></circle>
<text x='30' y='65' font-size='30'>NOT</text>";
                x = 126;
            }

            var svg = $@"<?xml version='1.0'?>
<svg width='195' height='100' xmlns='http://www.w3.org/2000/svg' xmlns:svg='http://www.w3.org/2000/svg' preserveAspectRatio='xMidYMid meet' version='1.0'>
{smallCss}
 <g class='layer'>
	 <path d='		   
		   M 20 0
		   L 120 50
           L 20 100
		   L 20 0
		   M 0 20
		   L 20 20
		   M 0 80
		   L 20 80
		   M {x} 50
		   L 195 50
           ' {cssClass} fill='none'/>
	 {text}
 </g>
</svg>";
            return svg;
        }
        public static void CreateOperatorGroup(this DiagramStencil toolboxGroup_Operator)
        {
            #region CompareToConstant
            toolboxGroup_Operator.CreateShape(
                Operator_CompareToConstant(),
                nameof(Operator_CompareToConstant),
                "CompareToConstant"
                , new Size(80, 50),
                Points(Point(0, 0.5, true), Point(1, 0.5, false))
                );
            #endregion

            #region Operator
            toolboxGroup_Operator.CreateShape(
                Operator_Operator(),
                nameof(Operator_Operator),
                "Operator",
                new Size(80, 50),
                Points(Point(0, 0.2, true), Point(0, 0.8, true), Point(1, 0.5, false))
                );
            #endregion

            #region And
            toolboxGroup_Operator.CreateShape(
                Operator_AND(),
                nameof(Operator_AND),
                "And",
                new Size(80, 50),
                Points(Point(0, 0.2, true), Point(0, 0.8, true), Point(1, 0.5, false))
                );
            #endregion

            #region Or
            toolboxGroup_Operator.CreateShape(
                Operator_OR(),
                nameof(Operator_OR),
                "OR",
                new Size(80, 50),
                Points(Point(0, 0.2, true), Point(0, 0.8, true), Point(1, 0.5, false))
                );
            #endregion

            #region XOR
            toolboxGroup_Operator.CreateShape
                (
                    Operator_XOR(),
                    nameof(Operator_XOR),
                    "XOR",
                    new Size(80, 50),
                    Points(Point(0, 0.2, true), Point(0, 0.8, true), Point(1, 0.5, false))
                );
            #endregion

            #region NOT
            toolboxGroup_Operator.CreateShape
                (
                    Operator_NOT(),
                    nameof(Operator_NOT),
                    "NOT",
                    new Size(80, 50),
                    Points(Point(0, 0.2, true), Point(0, 0.8, true), Point(1, 0.5, false))
                );
            #endregion

            #region Unary Minus
            toolboxGroup_Operator.CreateShape
                (
                    Operator_NOT(false),
                    "Unary Minus",
                    "",
                    new Size(80, 50),
                    Points(Point(0, 0.2, true), Point(0, 0.8, true))
                );
            #endregion

            #region Exp
            toolboxGroup_Operator.CreateShape
            (
                Operator_Exp(),
                nameof(Operator_Exp),
                "Exp",
                new Size(80, 50),
                Points(Point(0, 0.2, true), Point(0, 0.8, true), Point(1, 0.5, false))
            );

            #endregion        
        }
        #endregion

        #region Function
        static string Function(string functionName, bool haveTowInputPoint = false)
        {
            //这个图形与Operator_CompareToConstant一样,不同点只在右下角是一个小缺角样式的
            var inputLine = "M 0 50 L 20 50";
            if (haveTowInputPoint)
            {
                inputLine = "M 0 20 L 20 20 M 0 80 L 20 80";
            }
            var svg = $@"<?xml version='1.0'?>
<svg width='195' height='100' xmlns='http://www.w3.org/2000/svg' xmlns:svg='http://www.w3.org/2000/svg' preserveAspectRatio='xMidYMid meet' version='1.0'>
{smallCss} 
<g class='layer'>
	 <path d='		   
		   M 20 0
		   L 120 0
		   L 120 80
		   L 100 100
		   L 20 100
		   L 20 0
		   M 120 50
		   L 195 50
{inputLine}
           ' {cssClass} fill='none'/>
	 <text x='30' y='65' font-size='30'>{functionName}</text>
 </g>
</svg>";
            return svg;
        }
        public static void CreateFunction(
            this DiagramStencil toolboxGroup_Function, 
            string functionName, 
            bool haveTwoInputPoint = false,
            string svgString = null,
            bool hasOutput = true
            )
        {
            var inputPoint = new List<ConnectPoint>();
            if (haveTwoInputPoint)
            {
                inputPoint.Add(Point(0, 0.2, true));
                inputPoint.Add(Point(0, 0.8, true));
            }
            else
            {
                inputPoint.Add(Point(0, 0.5, true));
            }

            if (hasOutput)
            {
                inputPoint.Add(Point(1, 0.5, false));
            }

            if(string.IsNullOrEmpty(svgString))
            {
                svgString = Function(functionName, haveTwoInputPoint);
            }

            toolboxGroup_Function.CreateShape(
                 svgString,
                 $"Function_{functionName}",
                 functionName,
                 new Size(80, 50),
                 inputPoint
                 );
        }

        public static string Function_NoEval()
        {
            var svg = $@"<?xml version='1.0'?>
<svg width='70' fill='black' height='40' xmlns='http://www.w3.org/2000/svg' xmlns:svg='http://www.w3.org/2000/svg' preserveAspectRatio='xMidYMid meet' version='1.0'>
{smallCss}
	<g class='layer'>
		<ellipse cx='45' cy='20' fill='#ffffff' rx='10' ry='10' {cssClass}/>
		
		<line fill='none' x1='20' y1='40' x2='70'  y2='0' {cssClass}/>

		<line fill='none' x1='0' y1='10' x2='20'  y2='10' {cssClass}/>

		<line fill='none' x1='0' y1='30' x2='20' y2='30' {cssClass}/>

		<rect x='20' y='0' height='40' width='50' fill='none' {cssClass}/>
	</g>
</svg>
";
            return svg;
        }
        #endregion

        #region 快速创建
        static ConnectPoint Point(double x, double y, bool input)
        {
            return new ConnectPoint()
            {
                Category = input ? ConnectPointCategory.Input : ConnectPointCategory.Output,
                Location = new Point(x, y)
            };
        }
        static List<ConnectPoint> Points(params ConnectPoint[] points)
        {
            return points.ToList();
        }
        public static Dictionary<string, List<ConnectPoint>> PointCaches = new Dictionary<string, List<ConnectPoint>>();
        public static List<ConnectPoint> GetPoints(this ShapeDescription self)
        {
            if (!PointCaches.ContainsKey(self.Id))
                return null;
            
            return PointCaches[self.Id];
        }
        public static ShapeDescription CreateShape(this DiagramStencil group,
            string svg, string id, string caption,
            Size defaultSize,
            List<ConnectPoint> connectionPoints
            )
        {
            using (var stream = svg.ToStream())
            {
                var shape = ShapeDescription.CreateSvgShape(id, caption, stream)
                            .Update(getDefaultSize: () => defaultSize);
                //.Update(getConnectionPoints: getConnectionPoints);
                if (!PointCaches.ContainsKey(id))
                {
                    PointCaches.Add(id, connectionPoints);
                }
                else
                {
                    throw new Exception("可能是重复了!");
                }
                group.RegisterShape(shape);
                return shape;
            }
        }

        public static Stream ToStream(this string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(text));
            return ms;
        }
        #endregion
    }
}
