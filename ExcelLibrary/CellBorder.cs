using Microsoft.Office.Interop.Excel;

namespace ExcelLibrary
{

	/// <summary>
	///		This class defines information about a border that will be applied to a range of cells.
	/// </summary>
	public class CellBorder
	{

		#region Public Properties

		/// <summary>
		///		Gets or sets this border's index.
		/// </summary>
		public XlBordersIndex BorderIndex { get; set; }

		/// <summary>
		///		Gets or sets this border's color.
		/// </summary>
		public XlRgbColor? Color { get; set; }

		/// <summary>
		///		Gets or sets this border's weight.
		/// </summary>
		public XlBorderWeight Weight { get; set; }

		#endregion	// Public Properties

		#region Constructors

		/// <summary>
		///		CellBorder constructor.
		/// </summary>
		/// 
		/// <param name="borderIndex">
		///		This border's index.
		///	</param>
		///	
		/// <param name="color">
		///		This border's color.
		///	</param>
		///	
		/// <param name="weight">
		///		This border's weight.
		/// </param>
		public CellBorder(XlBordersIndex borderIndex, XlBorderWeight weight = XlBorderWeight.xlMedium, XlRgbColor? color = null)
		{
			this.BorderIndex = borderIndex;
			this.Color = color;
			this.Weight = weight;
		}

		#endregion	// Constructors

	}

}
