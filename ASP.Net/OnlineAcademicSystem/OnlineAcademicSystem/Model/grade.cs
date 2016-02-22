using System;
namespace OnlineAcademicSystem.Model
{
	/// <summary>
	/// grade:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class grade
	{
		public grade()
		{}
		#region Model
		private string _grade_id;
		private string _grade_name;
		/// <summary>
		/// 
		/// </summary>
		public string grade_id
		{
			set{ _grade_id=value;}
			get{return _grade_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string grade_name
		{
			set{ _grade_name=value;}
			get{return _grade_name;}
		}
		#endregion Model

	}
}

