using System;
using System.IO;
using System.Diagnostics;


public class main
{
	public static void Main(string[] arguments)
	{
		string function = arguments[0];
		string execution_directory = Directory.GetCurrentDirectory() + "\\";
		string compile_file_path = execution_directory + "graph.bat";
        string main_file_path = execution_directory + "graph.cs";
		string[] compile_file_contents = {	"csc -out:o.exe -main:graph -reference:\"C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\System.Windows.Forms.dll\" -reference:\"C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\System.Collections.dll\" graph.cs",
											"o"};
		string[] main_file_contents = { "using System;",
										"using System.Drawing;",
										"using System.Windows.Forms;",
										"using System.Threading.Tasks;",
										"using System.Collections.Generic;",
										"",
										"public class graph : Form",
										"{",
										"    public graph()",
										"    {",
										"        this.Size = new Size(500, 500);",
										"        this.StartPosition = FormStartPosition.CenterScreen;",
										"        this.MaximumSize = new Size(500, 500);",
										"        this.MinimumSize = new Size(500, 500);",
										"        //this.Load += new EventHandler(this.graph_Load);",
										"        this.Paint += new PaintEventHandler(this.graph_Paint);",
										"    }",
										"",
										"    private void graph_Paint(object sender, PaintEventArgs graph_event)   ",
										"    {  ",
										"        //base.OnPaint(graph_event);",
										"        Graphics setup_graph = graph_event.Graphics;",
										"        PointF[] coordinates = get_points(-499, 498);",
										"        setup_graph.DrawLines(new Pen(Color.Black), coordinates);",
										"        setup_graph.Dispose();",
										"    }",
										"",
										"    public PointF[] get_points(int x_intercept_one, int x_intercept_two)",
										"    {",
										"        int length_of_coordinate_array = (int)(Math.Sqrt(Math.Pow(x_intercept_two-x_intercept_one, 2)));",
										"",
										"        if (length_of_coordinate_array%2 != 0)",
										"        {",
										"            length_of_coordinate_array++;",
										"        }",
										"",
										"        PointF[] coordinates = new PointF[length_of_coordinate_array];",
										"",
										"        //Console.WriteLine(coordinates.ToString());",
										"",
										"        int x = x_intercept_one;",
										"",
										"        for(int i = 0; i < coordinates.Length; i++)",
										"        {",
										"            coordinates[i] = new PointF(x, -(float)(" + function + "));",
										"            x++;",
										"            //Console.WriteLine(coordinates[i].ToString());",
										"        }",
										"",
										"        return fit_to_graph(coordinates);",
										"    }",
										"",
										"    public PointF[] fit_to_graph(PointF[] coordinates)",
										"    {",
										"        PointF[] translated_coordinates = new PointF[coordinates.Length];",
										"",
										"        for(int i = 0; i < coordinates.Length; i++)",
										"        {",
										"            //if()",
										"            //{",
										"                if(coordinates[i].X <= 0 && coordinates[i].Y <= 0)",
										"                {",
										"                    translated_coordinates[i] = new PointF(this.Width/2 + coordinates[i].X, this.Height/2 + coordinates[i].Y);",
										"                    //Console.WriteLine(translated_coordinates[i].ToString());",
										"                }",
										"",
										"                else if(coordinates[i].X >= 0 && coordinates[i].Y <= 0)",
										"                {",
										"                    translated_coordinates[i] = new PointF(this.Width/2 + coordinates[i].X, this.Height/2 + coordinates[i].Y);",
										"                    //Console.WriteLine(translated_coordinates[i].ToString());",
										"                }",
										"",
										"                else if(coordinates[i].X <= 0 && coordinates[i].Y >= 0)",
										"                {",
										"                    translated_coordinates[i] = new PointF(this.Width/2 + coordinates[i].X, this.Height/2 + coordinates[i].Y);",
										"                    //Console.WriteLine(translated_coordinates[i].ToString());",
										"                }",
										"",
										"                else if(coordinates[i].X >= 0 && coordinates[i].Y >= 0)",
										"                {",
										"                    translated_coordinates[i] = new PointF(this.Width/2 + coordinates[i].X, this.Height/2 + coordinates[i].Y);",
										"                    //Console.WriteLine(translated_coordinates[i].ToString());",
										"                }",
										"                //Console.WriteLine(translated_coordinates[i].ToString());",
										"            //}",
										"        }",
										"",
										"        return translated_coordinates;",
										"    }",
										"",
										"    [STAThread]",
										"    public static void Main()",
										"    {",
										"      Application.EnableVisualStyles();",
										"      Application.Run(new graph());",
										"    }",
										"}"};
		string path_for_start_one = "graph.bat";

		File.WriteAllLines(compile_file_path, compile_file_contents);
		File.WriteAllLines(main_file_path, main_file_contents);
		
		try
		{
			Process.Start(path_for_start_one);
		}
		catch(Exception e)
		{
			Console.WriteLine(e.ToString());
		}
	}
}